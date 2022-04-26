using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;

namespace Dotflix.Models
{
    public class Movie
    {
        [Required]
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Título obrigatório")]
        [Display(Name = "Título")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Sinopse obrigatória")]
        public string Sinopse { get; set; }

        [Required(ErrorMessage = "Imagem obrigatória")]
        [JsonPropertyName("Imagem")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Faixa etária obrigatória")]
        public string AgeGroup { get; set; }      // faixa etária

        [Required(ErrorMessage = "Data de lançamento obrigaório")]
        public DateTime ReleaseData { get; set; } // data lançamento

        [Required(ErrorMessage = "Relevância do filme obrigatório")]
        public int Relevance { get; set; }        // relevância

        [Required(ErrorMessage = "Tempo do Filme obrigatório")]
        public DateTime RunTime { get; set; }

        [Required(ErrorMessage = "Id do Idioma obrigatório")]
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<MovieLanguage> MovieLanguages { get; set; }

        [NotMapped]
        [JsonProperty(ObjectCreationHandling = ObjectCreationHandling.Replace)]
        public IEnumerable<Language> Languages
        {
            get
            {
                if (MovieLanguages != null)
                    return MovieLanguages.Select(x => x.Language);
                return Enumerable.Empty<Language>();
            }

            set => MovieLanguages = value.Select(y => new MovieLanguage()
            {
                LanguageId = y.LanguageId,
            }).ToList();
        }
    }
}
//public IEnumerable<About> Abouts { get; set; }
//public IEnumerable<MovieKeyword> MovieKeywords { get; set; }
/*
public class MovieGenre
{
    public int GenreId { get; set; }
    public int MovieId { get; set; }
    public Movie Movie { get; set; }
    public Genre Genre { get; set; }
}
public class Genre
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<MovieGenre> MovieGenres { get; set; }
}

public class MovieKeyword
{
    public int MovieId { get; set; }
    public int KeywordId { get; set; }
    public Movie Movie { get; set; }
    public Keyword Keywords { get; set; }
}
public class Keyword
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<MovieKeyword> MovieKeyword { get; set; }
}

public class About // elenco
{
    public int Id { get; set; }
    public Info Deriction { get; set; }
    public Info Cast { get; set; } // elenco
    public IEnumerable<MovieGenre> MovieGenres { get; set; }
}
public class Info
{
    public int Id { get; set; }
    public string Name { get; set; }
}*/
