namespace TripToPrint.ReportTuning.Dto
{
    public class MooiClusterDto
    {
        public string Id { get; set; }
        public string OverviewMapFilePath { get; set; }
        public bool IsRoute { get; set; }
        public MooiPlacemarkDto[] Placemarks { get; set; }
    }
}
