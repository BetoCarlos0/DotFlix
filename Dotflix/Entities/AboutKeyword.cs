using ApiDotflix.Entities.Models;
using System.Text.Json.Serialization;

namespace ApiDotflix.Entities
{
    public class AboutKeyword// : BaseEntityManyToMany
    {
        public int KeywordId { get; set; }
        public int AboutId { get; set; }

        [JsonIgnore]
        public About About { get; set; }
        public Keyword Keyword { get; set; }
    }
}
