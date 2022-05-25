using ApiDotflix.Entities.Models;
using System.Text.Json.Serialization;

namespace ApiDotflix.Entities
{
    public class AboutRoadMap// : BaseEntityManyToMany
    {
        public int RoadMapId { get; set; }
        public int AboutId { get; set; }

        [JsonIgnore]
        public About About { get; set; }
        public RoadMap RoadMap { get; set; }
    }
}
