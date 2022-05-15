namespace ApiDotflix.Entities
{
    public class AboutGenre
    {
        public int AboutId { get; set; }
        public int GenreId { get; set; }

        public About About { get; set; }
        public Genre Genre { get; set; }
    }
}
