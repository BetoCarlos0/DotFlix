using System.Collections.Generic;

namespace ApiDotflix.Entities.Models.Dtos
{
    public class AboutOutputDto
    {
        public int AboutId { get; set; }

        public int MovieId { get; set; }

        public Director Director { get; set; }

        public IEnumerable<Cast> Casts { get; set; }

        public IEnumerable<RoadMap> RoadMaps { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public IEnumerable<Language> Languages { get; set; }

        public IEnumerable<Keyword> Keywords { get; set; }
    }
}
