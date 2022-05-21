using ApiDotflix.Entities;
using ApiDotflix.Entities.Models.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ApiDotflix.Data.Repository
{
    public class AboutRepository : IAboutRepository
    {
        private readonly DotflixDbContext _dbContext;

        public AboutRepository(DotflixDbContext dotflixDbContext)
        {
            _dbContext = dotflixDbContext;
        }

        public async Task<About> GetByIdAsync(int id)
        {
            var getKeyword = await _dbContext.About
                .Include(x => x.AboutKeywords)
                    .ThenInclude(x => x.Keyword)
                .Include(x => x.AboutLanguages)
                    .ThenInclude(x => x.Language)
                .Include(x => x.AboutGenres)
                    .ThenInclude(x => x.Genre)
                .Include(x => x.AboutCasts)
                    .ThenInclude(x => x.Cast)
                .Include(x => x.AboutRoadMaps)
                    .ThenInclude(x => x.RoadMap)
                .Include(x => x.Director)
                .FirstOrDefaultAsync(x => x.AboutId.Equals(id));

            if (getKeyword == null)
                throw new DbUpdateException("Id não encontrado");

            return getKeyword;
        }

        public async Task<bool> UpdateAsync(About about)
        {
            var getAbout = await _dbContext.About
                .Include(x => x.AboutKeywords)
                    .ThenInclude(x => x.Keyword)
                .Include(x => x.AboutLanguages)
                    .ThenInclude(x => x.Language)
                .Include(x => x.AboutGenres)
                    .ThenInclude(x => x.Genre)
                .Include(x => x.AboutCasts)
                    .ThenInclude(x => x.Cast)
                .Include(x => x.AboutRoadMaps)
                    .ThenInclude(x => x.RoadMap)
                .FirstOrDefaultAsync(x => x.AboutId.Equals(about.AboutId));

            if (getAbout == null) return false;

            getAbout.AboutKeywords = about.AboutKeywords;
            getAbout.AboutLanguages = about.AboutLanguages;
            getAbout.AboutGenres = about.AboutGenres;

            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
