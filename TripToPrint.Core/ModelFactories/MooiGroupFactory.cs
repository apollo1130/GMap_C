﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using TripToPrint.Core.Models;

namespace TripToPrint.Core.ModelFactories
{
    public interface IMooiGroupFactory
    {
        List<MooiGroup> CreateList(IEnumerable<KmlPlacemark> placemarks);
    }

    public class MooiGroupFactory : IMooiGroupFactory
    {
        private const int MIN_GROUP_COUNT = 4;
        private const int MAX_GROUP_COUNT = 8;
        private const double MIN_DIST_TO_NEIGHBOR_IN_KM = 0.75d;
        //private const double COEF_ROOM_OVER_AVG_DISTANCE = 1.2; // 20%
        //private const double COEF_ROOM_OVER_MAX_DISTANCE = 1.5; // 50%

        public List<MooiGroup> CreateList(IEnumerable<KmlPlacemark> placemarks)
        {
            var groups = new List<MooiGroup>();

            var placemarksConverted = placemarks.Select(ConvertKmlPlacemarkToMooiPlacemark).ToList();

            if (placemarksConverted.Count <= MIN_GROUP_COUNT)
            {
                return CreateSingleGroup(placemarksConverted);
            }

            var placemarksWithNeighbors = GetPlacemarksWithNeighbors(placemarksConverted).ToList();
            var placemarksWithNeighborsLookup = placemarksWithNeighbors.ToDictionary(x => x.Placemark);

            MooiGroup currentGroup = new MooiGroup();
            groups.Add(currentGroup);

            var placemarksToProcess = placemarksWithNeighbors.ToList();
            while (placemarksToProcess.Any())
            {
                var startingPoint = placemarksToProcess[0];
                placemarksToProcess.RemoveAt(0);

                // Skip if the placemark has been added to any group before
                if (groups.Any(g => g.Placemarks.Any(p => p == startingPoint.Placemark)))
                {
                    continue;
                }

                currentGroup.Placemarks.Add(startingPoint.Placemark);

                // Add its closest neighbor to current group
                if (!groups.Any(g => g.Placemarks.Any(p => p == startingPoint.NeighborWithMinDistance.Placemark)))
                {
                    currentGroup.Placemarks.Add(startingPoint.NeighborWithMinDistance.Placemark);
                }

                foreach (var pm in placemarksToProcess.Skip(1).ToList())
                {
                    if (currentGroup.Placemarks.Any(x => x == pm.Placemark || x == pm.NeighborWithMinDistance.Placemark))
                    {
                        if (currentGroup.Placemarks.Count >= MIN_GROUP_COUNT)
                        {
                            /*var linkToFirst = placemarksLookup[currentGroup.Placemarks[0]]
                                .neighbors.First(x => x.placemark == pm.placemark);*/
                            var maxDistanceAmongAddedPlacemarks = placemarksWithNeighborsLookup[currentGroup.Placemarks[0]]
                                .Neighbors.Where(x => currentGroup.Placemarks.Any(y => y == x.Placemark))
                                .Select(x => x.AllowedDistance)
                                .Max();

                            if (pm.NeighborWithMinDistance.Distance > maxDistanceAmongAddedPlacemarks) // * COEF_ROOM_OVER_MAX_DISTANCE)
                            {
                                continue;
                            }
                        }

                        currentGroup.Placemarks.Add(pm.Placemark);
                        placemarksToProcess.Remove(pm);
                    }

                    if (currentGroup.Placemarks.Count == MAX_GROUP_COUNT)
                    {
                        break;
                    }
                }

                currentGroup = new MooiGroup();
                groups.Add(currentGroup);

                //placemarksToProcess = placemarksToProcess.Where(x => !currentGroup.Placemarks.Any(y => y == x.placemark || y == x.minDist.placemark)).ToList();
            }

            // Trim out the last group which is always empty
            groups = groups.Where(x => x.Placemarks.Count > 0).ToList();

            MergeGroups(groups);

            return groups;
        }

        public MooiPlacemark ConvertKmlPlacemarkToMooiPlacemark(KmlPlacemark kmlPlacemark)
        {
            var description = ReorderImagesInContent(kmlPlacemark.Description);
            description = FilterContent(description);

            return new MooiPlacemark
            {
                Name = kmlPlacemark.Name,
                Description = description,
                Coordinate = kmlPlacemark.Coordinate,
                IconPath = kmlPlacemark.IconPath
            };
        }

        public List<MooiGroup> CreateSingleGroup(List<MooiPlacemark> placemarks)
        {
            var group = new MooiGroup();
            foreach (var pm in placemarks)
            {
                pm.Group = group;
                group.Placemarks.Add(pm);
            }

            return new List<MooiGroup> { group };
        }

        public virtual IEnumerable<PlacemarkWithNeighbors> GetPlacemarksWithNeighbors(IList<MooiPlacemark> placemarks)
        {
            return from placemark in placemarks
                   let neighbors = from neighbor in placemarks.Except(new[] { placemark })
                                   let dist = placemark.Coordinate.GetDistanceTo(neighbor.Coordinate)
                                   let allowedDistCoef = Math.Exp(1 / Math.Max(MIN_DIST_TO_NEIGHBOR_IN_KM, dist / 1000d))
                                   orderby dist
                                   select new PlacemarkNeighbor
                                   {
                                       Placemark = neighbor,
                                       Distance = dist,
                                       AllowedDistance = Math.Max(MIN_DIST_TO_NEIGHBOR_IN_KM * 1000, allowedDistCoef * dist)
                                   }
                   let minDist = neighbors.First()
                   orderby minDist.Distance
                   select new PlacemarkWithNeighbors
                   {
                       Placemark = placemark,
                       Neighbors = neighbors,
                       NeighborWithMinDistance = minDist
                   };
        }

        public void MergeGroups(List<MooiGroup> groups)
        {
            while (true)
            {
                var groupToMerge = groups.FirstOrDefault(x => x.Placemarks.Count < MIN_GROUP_COUNT);
                if (groupToMerge == null)
                    break;

                var groupForMerge = (from forMergeCandidate in groups.Except(new[] { groupToMerge })
                                     where forMergeCandidate.Placemarks.Count + groupToMerge.Placemarks.Count <= MAX_GROUP_COUNT
                                     let minDist = (from pm1 in forMergeCandidate.Placemarks
                                                    from pm2 in groupToMerge.Placemarks
                                                    select DistanceBetweenPlacemarks(pm1, pm2)).Min()
                                     orderby minDist
                                     select forMergeCandidate).FirstOrDefault();

                if (groupForMerge == null)
                {
                    break;
                }

                foreach (var pm in groupToMerge.Placemarks)
                {
                    pm.Group = groupForMerge;
                    groupForMerge.Placemarks.Add(pm);
                }

                groups.Remove(groupToMerge);
            }
        }

        private string FilterContent(string content)
        {
            if (string.IsNullOrEmpty(content))
                return content;

            // Strip consecutive br's
            content = Regex.Replace(content, @"(<br>){2,}", "<br>");

            // Remove br's which go after images
            content = Regex.Replace(content, @"/><br>", "/>");

            // Remove br's which go before images
            //content = Regex.Replace(content, @"<br><img", "<img");

            // Remove image sizes
            content = Regex.Replace(content, @"\s*(height|width)=['""](\d+|auto)['""]", "");

            return content;
        }

        private string ReorderImagesInContent(string content)
        {
            if (string.IsNullOrEmpty(content))
                return content;

            var foundImages = new List<string>();
            content = Regex.Replace(content, @"<img.+?>", m => {
                foundImages.Add(m.Value);
                return string.Empty;
            });

            return string.Join(string.Empty, foundImages.Concat(new[] { content }));
        }

        private double DistanceBetweenPlacemarks(IHaveCoordinate placemark1, IHaveCoordinate placemark2)
        {
            return placemark1.Coordinate.GetDistanceTo(placemark2.Coordinate);
        }

        public class PlacemarkNeighbor
        {
            public MooiPlacemark Placemark { get; set; }
            public double Distance { get; set; }
            public double AllowedDistance { get; set; }
        }

        public class PlacemarkWithNeighbors
        {
            public MooiPlacemark Placemark { get; set; }
            public IEnumerable<PlacemarkNeighbor> Neighbors { get; set; }
            public PlacemarkNeighbor NeighborWithMinDistance { get; set; }
        }
    }
}
