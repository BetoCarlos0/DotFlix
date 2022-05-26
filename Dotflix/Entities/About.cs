using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiDotflix.Entities
{
    public class About
    {
        public int AboutId { get; set; }

        public int MovieId { get; set; }

        [JsonIgnore]
        public Movie Movie { get; set; }

        [JsonIgnore]
        public int DirectorId { get; set; }

        public Director Director { get; set; }

        [Required(ErrorMessage = "Id do Elenco obrigatório")]
        public IEnumerable<AboutCast> AboutCasts { get; set; }

        [Required(ErrorMessage = "Id do Gênero obrigatório")]
        public IEnumerable<AboutGenre> AboutGenres { get; set; }

        public IEnumerable<AboutKeyword>? AboutKeywords { get; set; }

        [Required(ErrorMessage = "Id do Idioma obrigatório")]
        public IEnumerable<AboutLanguage> AboutLanguages { get; set; }

        public IEnumerable<AboutRoadMap>? AboutRoadMaps { get; set; }
    }
}
