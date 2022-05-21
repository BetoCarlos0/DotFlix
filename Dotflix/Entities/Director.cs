using ApiDotflix.Entities.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ApiDotflix.Entities
{
    public class Director : BaseEntity
    {
        [JsonIgnore]
        public IEnumerable<About> About { get; set; }
    }
}
