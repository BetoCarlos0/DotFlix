using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ApiDotflix.Entities
{
    public class Language
    {
        public int LanguageId { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public IEnumerable<AboutLanguage> AboutLanguages { get; set; }
    }
}
