using System;

namespace ApiDotflix.Models
{
    public class AboutKeyword
    {
        public int AboutId { get; set; }

        public int KeywordId { get; set; }

        public About About { get; set; }
        public Keyword Keyword { get; set; }
    }
}
