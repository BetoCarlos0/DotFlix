using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ApiDotflix.Entities
{
    public class About
    {
        public int AboutId { get; set; }

        public int MovieId { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public Movie Movie { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public int DirectorId { get; set; }

        public Director Director { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<AboutRoadMap>? AboutRoadMaps { get; set; }

        [Required(ErrorMessage = "Id do Elenco obrigatório")]
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<AboutCast> AboutCasts { get; set; }

        [Required(ErrorMessage = "Id do Gênero obrigatório")]
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<AboutGenre> AboutGenres { get; set; }

        [Required(ErrorMessage = "Id do Idioma obrigatório")]
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<AboutLanguage> AboutLanguages { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<AboutKeyword>? AboutKeywords { get; set; }

        [NotMapped]
        [JsonProperty(ObjectCreationHandling = ObjectCreationHandling.Replace)]
        public IEnumerable<RoadMap>? RoadMaps
        {
            get {
                if (AboutRoadMaps != null)
                    return AboutRoadMaps.Select(x => x.RoadMap);
                return Enumerable.Empty<RoadMap>();
            }
            set => AboutRoadMaps = value.Select(y => new AboutRoadMap()
            {
                RoadMapId = y.Id,
            }).ToList();
        }

        [NotMapped]
        [JsonProperty(ObjectCreationHandling = ObjectCreationHandling.Replace)]
        public IEnumerable<Cast> Casts
        {
            get => AboutCasts.Select(x => x.Cast);
            set => AboutCasts = value.Select(y => new AboutCast()
            {
                AboutId = y.Id,
            }).ToList();
        }

        [NotMapped]
        [JsonProperty(ObjectCreationHandling = ObjectCreationHandling.Replace)]
        public IEnumerable<Genre> Genres
        {
            get => AboutGenres.Select(x => x.Genre);
            set => AboutGenres = value.Select(y => new AboutGenre()
            {
                GenreId = y.Id,
            }).ToList();
        }

        [NotMapped]
        [JsonProperty(ObjectCreationHandling = ObjectCreationHandling.Replace)]
        public IEnumerable<Keyword>? Keywords
        {
            get
            {
                if (AboutKeywords != null)
                    return AboutKeywords.Select(x => x.Keyword);
                return Enumerable.Empty<Keyword>();
            }
            set => AboutKeywords = value.Select(y => new AboutKeyword()
            {
                KeywordId = y.Id,
            }).ToList();
        }

        [NotMapped]
        [JsonProperty(ObjectCreationHandling = ObjectCreationHandling.Replace)]
        public IEnumerable<Language> Languages
        {
            get => AboutLanguages.Select(x => x.Language);
            set => AboutLanguages = value.Select(y => new AboutLanguage()
            {
                LanguageId = y.Id,
            }).ToList();
        }
    }
}
