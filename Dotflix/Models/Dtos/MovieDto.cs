using System;
using System.ComponentModel.DataAnnotations;

namespace Dotflix.Models
{
    public class MovieDto
    {
        public Guid MovieId { get; set; }

        public string Title { get; set; }

        public string Image { get; set; }

        public string AgeGroup { get; set; }      // faixa etária

        public int Relevance { get; set; }        // relevância

        public string RunTime { get; set; }
    }
}
