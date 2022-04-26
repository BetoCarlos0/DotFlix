using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Dotflix.Models
{
    public class MovieLanguage
    {
        //[Required]
        public int LanguageId { get; set; }

        //[Required]
        public int MovieId { get; set; }

        //[JsonIgnore]
        public Movie Movie { get; set; }
        public Language Language { get; set; } 
    }
}
