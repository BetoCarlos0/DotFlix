namespace ApiDotflix.Entities
{
    public class AboutRoadMap
    {
        public int AboutId { get; set; }
        public int RoadMapId { get; set; }

        public About About { get; set; }
        public RoadMap RoadMap { get; set; }
    }
}
