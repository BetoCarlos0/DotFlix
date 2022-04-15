using System.Text.Json.Serialization;

namespace Dotflix.Models
{
    public class MovieLanguage
    {
        public int LanguageId { get; set; }
        public int MovieId { get; set; }

        //[JsonIgnore]
        public Movie Movie { get; set; }
        public Language Language { get; set; } 
    }
}
