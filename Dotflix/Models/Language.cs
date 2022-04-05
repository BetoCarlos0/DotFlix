using System.Collections.Generic;

namespace Dotflix.Models
{
    public class Language
    {
        public int LanguageId { get; set; }
        public string Name { get; set; }
        public int MovieId { get; set; }
        //public Movie Movie { get; set; }
    }
}
