namespace Dotflix.Models
{
    public class MovieLanguage
    {
        public int LanguageId { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public Language Language { get; set; } 
    }
}
