using System.Text.Json.Serialization;

namespace Dotflix.Models
{
    public class MovieLanguage
    {
        //[JsonIgnore]
        public int LanguageId { get; set; }
        //[JsonIgnore]
        public int MovieId { get; set; }

        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonIgnore]
        public virtual Movie Movie { get; set; }

        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public virtual Language Language { get; set; } 
    }
}
