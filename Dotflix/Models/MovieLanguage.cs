using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Dotflix.Models
{
    public class MovieLanguage
    {
        public Guid LanguageId { get; set; }

        public Guid MovieId { get; set; }

        public Movie Movie { get; set; }
        public Language Language { get; set; } 
    }
}
