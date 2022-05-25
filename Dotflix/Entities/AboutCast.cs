using ApiDotflix.Entities.Models;
using System.Text.Json.Serialization;

namespace ApiDotflix.Entities
{
    public class AboutCast// : BaseEntityManyToMany<Cast>
    {
        public int CastId { get; set; }
        public int AboutId { get; set; }

        [JsonIgnore]
        public About About { get; set; }
        public Cast Cast { get; set; }
    }
}
