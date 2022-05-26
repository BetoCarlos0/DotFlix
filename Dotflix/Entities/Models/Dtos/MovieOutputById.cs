using System.Collections.Generic;

namespace ApiDotflix.Entities.Models.Dtos
{
    public class MovieOutputById
    {
        public int MovieId { get; set; }

        public string Title { get; set; }

        public string Sinopse { get; set; }

        public string Image { get; set; }

        public AgeGroup AgeGroup { get; set; }      // faixa etária

        public int Relevance { get; set; }        // relevância

        public string ReleaseData { get; set; } // data lançamento

        public string RunTime { get; set; }

        public AboutOutputDto About { get; set; }
    }
}
