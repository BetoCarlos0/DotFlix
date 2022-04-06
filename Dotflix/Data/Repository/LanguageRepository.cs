using Dotflix.Models;
using Dotflix.Models.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotflix.Data.Repository
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly DotflixDbContext _dbContext;

        public LanguageRepository(DotflixDbContext dotflixDbContext)
        {
            _dbContext = dotflixDbContext;
        }

        public async Task<IEnumerable<Language>> GetAllAsync()
        {
            return await _dbContext.Language.ToListAsync();
        }

        public async Task<Language> GetByIdAsync(int id)
        {
            return await _dbContext.Language.FirstOrDefaultAsync(x => x.LanguageId == id);
        }

        public async Task<Language> AddAsync(Language language)
        {
            var result = await _dbContext.Language.AddAsync(language);
            await _dbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Language> UpdateAsync(Language language)
        {
            var getLanguage = await _dbContext.Language.
                FirstOrDefaultAsync(x => x.LanguageId == language.LanguageId);
            
            if (getLanguage != null)
            {
                getLanguage = language;
                await _dbContext.SaveChangesAsync();

                return getLanguage;
            }

            return null;
        }

        public async Task<Language> DeleteId(int id)
        {
            var getLanguage = await _dbContext.Language.
                FirstOrDefaultAsync(x => x.LanguageId == id);

            if (getLanguage != null)
            {
                _dbContext.Remove(getLanguage);
                await _dbContext.SaveChangesAsync();

                return getLanguage;
            }

            return null;
        }
    }
}
