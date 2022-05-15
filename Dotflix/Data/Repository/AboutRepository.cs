using ApiDotflix.Entities;
using ApiDotflix.Entities.Models.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
                .FirstOrDefaultAsync(x => x.MovieId.Equals(about.AboutId));

            if (getAbout == null) return false;

            getAbout.AboutKeywords = about.AboutKeywords;
            getAbout.AboutLanguages = about.AboutLanguages;
            getAbout.AboutGenres = about.AboutGenres;

            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
