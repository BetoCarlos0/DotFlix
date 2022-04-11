using System.Collections.Generic;

namespace Dotflix.Models
{
    public class MovieData
    {
        public IEnumerable<Movie> Movie { get; set; }
        public IEnumerable<MovieLanguage> MovieLanguage { get; set; }
        public IEnumerable<Language> Language { get; set; }
    }
}
