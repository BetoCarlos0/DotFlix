using System.Text.Json.Serialization;

namespace ApiDotflix.Entities.Models
{
    public class BaseEntityManyToMany// : IBaseEntityManyToMany
    {
        public int Id { get; set; }
        [JsonIgnore]
        public int AboutId { get; set; }

        [JsonIgnore]
        public About About { get; set; }
        [JsonIgnore]
        public BaseEntity SonEntity { get; set; }
    }
}
