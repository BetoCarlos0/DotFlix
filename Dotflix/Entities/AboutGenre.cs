using ApiDotflix.Entities.Models;
using System.Text.Json.Serialization;

namespace ApiDotflix.Entities
{
    public class AboutGenre// : BaseEntityManyToMany
    {
        public int AboutId { get; set; }
        public int GenreId { get; set; }

        [JsonIgnore]
        public About About { get; set; }
        public Genre Genre { get; set; }
    }
}
