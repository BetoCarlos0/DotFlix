using System.Collections.Generic;

namespace Dotflix.Models
{
    public class MovieIndexData
    {
        public IEnumerable<Movie> Movies { get; set; }
        public IEnumerable<Language> Languages { get; set; }
    }
}
