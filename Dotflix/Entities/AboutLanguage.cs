namespace ApiDotflix.Entities
{
    public class AboutLanguage
    {
        public int AboutId { get; set; }
        public int LanguageId { get; set; }

        public About About { get; set; }
        public Language Language { get; set; }
    }
}
