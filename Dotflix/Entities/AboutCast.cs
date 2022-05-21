namespace ApiDotflix.Entities
{
    public class AboutCast
    {
        public int AboutId { get; set; }
        public int CastId { get; set; }

        public About About { get; set; }
        public Cast Cast { get; set; }
    }
}
