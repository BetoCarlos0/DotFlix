using ApiDotflix.Models;
using ApiDotflix.Models.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiDotflix.Data.Repository
{
    public class KeywordRepository : IKeywordRepository
    {
        private readonly DotflixDbContext _dbContext;

        public KeywordRepository(DotflixDbContext dotflixDbContext)
        {
            _dbContext = dotflixDbContext;
        }

        public async Task<IEnumerable<Keyword>> GetAllAsync()
        {
            return await _dbContext.Keyword
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Keyword> GetByIdAsync(int id)
        {
            var getKeyword = await _dbContext.Keyword.FindAsync(id);

            if (getKeyword == null)
                throw new DbUpdateException("Id não encontrado");

            return getKeyword;
        }

        public async Task<Keyword> GetByNameAsync(string name)
        {
            return await _dbContext.Keyword.FirstOrDefaultAsync(x => x.Name.Equals(name));
        }

        public async Task<bool> AddAsync(Keyword keyword)
        {
            await _dbContext.Keyword.AddAsync(keyword);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(Keyword keyword)
        {
            var getKeyword = await _dbContext.Keyword.FirstOrDefaultAsync(x => x.KeywordId.Equals(keyword.KeywordId));

            if (getKeyword != null)
                getKeyword.Name = keyword.Name;
            else
                throw new DbUpdateException("Id não existe");

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteId(int id)
        {
            var getKeyword = await _dbContext.Keyword
                .FindAsync(id);

            if (getKeyword == null)
                throw new DbUpdateException("Id não existe");

            _dbContext.Remove(getKeyword);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}
