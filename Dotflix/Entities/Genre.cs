using ApiDotflix.Entities.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiDotflix.Entities
{
    public class Genre : BaseEntity
    {
        [JsonIgnore]
        public IEnumerable<AboutGenre> AboutGenre { get; set; }
    }
}
