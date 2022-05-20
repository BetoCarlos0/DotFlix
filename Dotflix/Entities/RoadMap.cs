using ApiDotflix.Entities.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ApiDotflix.Entities
{
    public class RoadMap : BaseEntity
    {
        [JsonIgnore]
        public IEnumerable<AboutRoadMap> AboutRoadMap { get; set; }
    }
}
