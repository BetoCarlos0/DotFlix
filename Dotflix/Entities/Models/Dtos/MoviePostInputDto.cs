using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ApiDotflix.Entities.Models.Dtos
{
    public class MoviePostInputDto
    {
        [JsonIgnore]
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Sinopse { get; set; }
        public string Image { get; set; }
        public string AgeGroup { get; set; }      // faixa etária
        public int Relevance { get; set; }        // relevância
        public string ReleaseData { get; set; } // data lançamento
        public string RunTime { get; set; }
        public AboutDto About { get; set; }
    }

    public class AboutDto
    {
        [JsonIgnore]
        public int AboutId { get; set; }
        [JsonIgnore]
        public int MovieId { get; set; }
        public int DirectorId { get; set; }

        public List<BaseEntityDto>? RoadMaps { get; set; }
        public List<BaseEntityDto> Casts { get; set; }
        public List<BaseEntityDto> Genres { get; set; }
        public List<BaseEntityDto>? Keywords { get; set; }
        public List<BaseEntityDto> Languages { get; set; }
    }
    public class BaseEntityDto
    {
        public int Id { get; set; }
    }
}
