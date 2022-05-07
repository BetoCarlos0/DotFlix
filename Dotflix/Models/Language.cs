using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Dotflix.Models
{
    public class Language
    {
        [Required]
        public Guid LanguageId { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Apenas Letras")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Idioma menor que 3 caracteres")]
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<MovieLanguage> MovieLanguages { get; set; }
    }
}
