using System.Text.Json.Serialization;

namespace Dotflix.Models
{
    public class MovieLanguage
    {
        public int LanguageId { get; set; }
        public int MovieId { get; set; }

        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Movie Movie { get; set; }

        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Language Language { get; set; } 
    }
}
