using System.Collections.Generic;

namespace Dotflix.Models
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Movie> Movie { get; set; }
    }
}
