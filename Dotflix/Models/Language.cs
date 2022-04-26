using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Dotflix.Models
{
    public class Language
    {
        [Required]
        public int LanguageId { get; set; }

        [Required]
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<MovieLanguage> MovieLanguages { get; set; }
    }
}
