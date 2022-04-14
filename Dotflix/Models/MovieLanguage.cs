using System.Text.Json.Serialization;

namespace Dotflix.Models
{
    public class MovieLanguage
    {
        public int LanguageId { get; set; }
        public int MovieId { get; set; }

        [JsonIgnore]
        public virtual Movie Movie { get; set; }
        public virtual Language Language { get; set; } 
    }
}
