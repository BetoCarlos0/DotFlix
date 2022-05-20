using ApiDotflix.Entities.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ApiDotflix.Entities
{
    public class Cast : BaseEntity
    {
        [JsonIgnore]
        public IEnumerable<AboutCast> AboutCast { get; set; }
    }
}
