namespace ApiDotflix.Entities.Models.Dtos
{
    public class MovieOutputDto
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public int Relevance { get; set; }        // relevância
        public string RunTime { get; set; }
        public AgeGroup AgeGroup { get; set; }      // faixa etária
    }
}
