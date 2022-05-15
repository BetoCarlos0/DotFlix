﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiDotflix.Models
{
    public class Keyword
    {
        public int KeywordId { get; set; }

        [Required(ErrorMessage = "Nome Requerido")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Nome menor que 3 caracteres")]
        public string Name { get; set; }

        [JsonIgnore]
        public IEnumerable<AboutKeyword> AboutKeyword { get; set; }
    }
}
