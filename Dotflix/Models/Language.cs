using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Dotflix.Models
{
    public class Language
    {
        public int LanguageId { get; set; }
        public string Name { get; set; }
        public ICollection<MovieLanguage> MovieLanguages { get; set; }
    }
}
