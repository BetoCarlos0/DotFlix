using System;
using System.Collections.Generic;

namespace Dotflix.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string AgeGroup { get; set; }
        public string Budget { get; set; }  // Orçamento
        public string ReleaseData { get; set; }
        public string Relevance { get; set; }
        public string Revenue { get; set; } // Receita
        public DateTime RunTime { get; set; }
        public ICollection<Language> Language { get; set; }
        //public IEnumerable<MovieLanguage> MovieLanguages { get; set; }
        //public IEnumerable<About> Abouts { get; set; }
        //public IEnumerable<MovieKeyword> MovieKeywords { get; set; }
    }
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
}
