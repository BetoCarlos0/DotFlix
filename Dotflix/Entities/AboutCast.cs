using ApiDotflix.Entities.Models;
using System.Text.Json.Serialization;

namespace ApiDotflix.Entities
{
    public class AboutCast// : BaseEntityManyToMany
    {
        public int CastId { get; set; }
        public int AboutId { get; set; }

        [JsonIgnore]
        public About About { get; set; }
        [JsonIgnore]
        public Cast Cast { get; set; }
    }
}
