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

        [Required(ErrorMessage = "Id do Gênero obrigatório")]
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<AboutGenre> AboutGenres { get; set; }

        [Required(ErrorMessage = "Id do Idioma obrigatório")]
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<AboutLanguage> AboutLanguages { get; set; }

        [Required(ErrorMessage = "Id da palavra chave obrigatório")]
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<AboutKeyword> AboutKeywords { get; set; }

        [NotMapped]
        [JsonProperty(ObjectCreationHandling = ObjectCreationHandling.Replace)]
        public IEnumerable<Genre> Genres
        {
            get => AboutGenres.Select(x => x.Genre);
            set => AboutGenres = value.Select(y => new AboutGenre()
            {
                GenreId = y.GenreId,
            }).ToList();
        }

        [NotMapped]
        [JsonProperty(ObjectCreationHandling = ObjectCreationHandling.Replace)]
        public IEnumerable<Keyword> Keywords
        {
            get => AboutKeywords.Select(x => x.Keyword);
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
                LanguageId = y.LanguageId,
            }).ToList();
        }
    }
}
