using ApiDotflix.Entities;

namespace ApiDotflix.Data.Repository
{
    public class KeywordRepository : BaseRepository<Keyword>
    {
        public KeywordRepository(DotflixDbContext dotflixDbContext) : base(dotflixDbContext)
        {
        }
    }
}
