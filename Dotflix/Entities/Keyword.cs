using ApiDotflix.Entities.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiDotflix.Entities
{
    public class Keyword : BaseEntity
    {
        [JsonIgnore]
        public IEnumerable<AboutKeyword> AboutKeyword { get; set; }
    }
}
