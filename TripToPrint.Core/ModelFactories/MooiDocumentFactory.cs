using System.Collections.Generic;
using System.Linq;
using TripToPrint.Core.Models;

namespace TripToPrint.Core.ModelFactories
{
    public interface IMooiDocumentFactory
    {
        MooiDocument Create(KmlDocument kmlDocument, Dictionary<KmlPlacemark, DiscoveredPlace> discoveredPlacePerPlacemark, string reportTempPath);
    }

    public class MooiDocumentFactory : IMooiDocumentFactory
    {
        private readonly IMooiGroupFactory _mooiGroupFactory;

        public MooiDocumentFactory(IMooiGroupFactory mooiGroupFactory)
        {
            _mooiGroupFactory = mooiGroupFactory;
        }

        public MooiDocument Create(KmlDocument kmlDocument, Dictionary<KmlPlacemark, DiscoveredPlace> discoveredPlacePerPlacemark, string reportTempPath)
        {
            var model = new MooiDocument {
                Title = kmlDocument.Title,
                Description = kmlDocument.Description
            };

            var foldersWithPlacemarks = kmlDocument.Folders.Where(x => x.Placemarks.Any());

            foreach (var folder in foldersWithPlacemarks)
            {
                var section = new MooiSection {
                    Document = model,
                    Name = folder.Name
                };
                model.Sections.Add(section);

                ExtractGroupsFromFolderIntoSection(folder, section, discoveredPlacePerPlacemark, reportTempPath);
            }

            return model;
        }

        private void ExtractGroupsFromFolderIntoSection(KmlFolder folder, MooiSection section, Dictionary<KmlPlacemark, DiscoveredPlace> discoveredPlacePerPlacemark, string reportTempPath)
        {
            var groups = _mooiGroupFactory.CreateList(folder, discoveredPlacePerPlacemark, reportTempPath);
            groups.ForEach(x => x.Section = section);
            section.Groups.AddRange(groups);
        }
    }
}
