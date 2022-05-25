using ApiDotflix.Entities.Models;
using System.Text.Json.Serialization;

namespace ApiDotflix.Entities
{
    public class AboutLanguage// : BaseEntityManyToMany
    {
        public int LanguageId { get; set; }
        public int AboutId { get; set; }

        [JsonIgnore]
        public About About { get; set; }
        public Language Language { get; set; }
    }
}
