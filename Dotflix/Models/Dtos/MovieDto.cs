using System;

namespace ApiDotflix.Models
{
    public class MovieDto
    {
        public int MovieId { get; set; }

        public string Title { get; set; }

        public string Image { get; set; }

        public string AgeGroup { get; set; }      // faixa etária

        public int Relevance { get; set; }        // relevância

        public string RunTime { get; set; }
    }
}
