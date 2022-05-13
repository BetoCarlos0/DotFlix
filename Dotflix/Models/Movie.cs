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
        public Guid MovieId { get; set; }

        [Required(ErrorMessage = "Título obrigatório")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Título menor que 5 caracteres")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Sinopse obrigatória")]
        [StringLength(250, MinimumLength = 5, ErrorMessage = "Sinopse menor que 5 caracteres")]
        public string Sinopse { get; set; }

        [Required(ErrorMessage = "Imagem obrigatória")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Faixa etária obrigatória")]
        [StringLength(2, MinimumLength = 1, ErrorMessage = "Faixa etária inválida")]
        public string AgeGroup { get; set; }      // faixa etária

        [Required(ErrorMessage = "Relevância do filme obrigatório")]
        [Range(0, 100, ErrorMessage = "Porcentagem inválida")]
        public int Relevance { get; set; }        // relevância

        [Required(ErrorMessage = "Data de lançamento obrigaório")]
        [RegularExpression(@"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[13-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$"
            ,ErrorMessage = "Data Inválida")]
        public string ReleaseData { get; set; } // data lançamento

        [Required(ErrorMessage = "Tempo do Filme obrigatório")]
        [RegularExpression(@"^([01234]{1}):([012345]\d):([012345]\d)", ErrorMessage = "Tempo inválido")]
        public string RunTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd:MM:yyyy}")]
        public string Cadastro { get; set; }

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

        public void DataCadastro()
        {
            Cadastro = DateTime.Now.Date.ToString();
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
