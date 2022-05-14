using ApiDotflix.Models.Enum;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ApiDotflix.Models
{
    public class About
    {
        public int AboutId { get; set; }

        public int MovieId { get; set; }
        public IEnumerable<EnumValue> Language { get; set; }
        public Movie Movie { get; set; }

        [Required(ErrorMessage = "Id da palavra chave obrigatório")]
        [System.Text.Json.Serialization.JsonIgnore]
        public IEnumerable<AboutKeyword> AboutKeywords { get; set; }

        //public virtual ICollection<MovieLanguage> MovieLanguages { get; set; }

        [NotMapped]
        [JsonProperty(ObjectCreationHandling = ObjectCreationHandling.Replace)]
        public IEnumerable<Keyword> Keywords
        {
            get
            {
                if (AboutKeywords != null)
                    return AboutKeywords.Select(x => x.Keyword);
                return Enumerable.Empty<Keyword>();
            }

            set => AboutKeywords = value.Select(y => new AboutKeyword()
            {
                KeywordId = y.KeywordId,
            }).ToList();
        }
    }
}
