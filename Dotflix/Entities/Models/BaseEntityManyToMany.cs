using System.Text.Json.Serialization;

namespace ApiDotflix.Entities.Models
{
    public class BaseEntityManyToMany<T> : IBaseEntityManyToMany<T> where T : BaseEntity
    {
        public int Id { get; set; }
        //[JsonIgnore]
        public int AboutId { get; set; }

        [JsonIgnore]
        public About About { get; set; }
        //[JsonIgnore]
        public T SonEntity { get; set; }
    }
}
