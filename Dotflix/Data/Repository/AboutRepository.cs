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

        public async Task<IEnumerable<About>> GetAllAsync()
        {
            return await _dbContext.About
                //.Include(x => x.Languages)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<About> GetByIdAsync(int id)
        {
            var getKeyword = await _dbContext.About
                .Include(x => x.AboutKeywords)
                    .ThenInclude(x => x.Keyword)
                .Include(x => x.AboutLanguages)
                    .ThenInclude(x => x.Language)
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
                .FirstOrDefaultAsync(x => x.MovieId.Equals(about.AboutId));

            if (getAbout == null) return false;

            getAbout.AboutKeywords = about.AboutKeywords;
            //getAbout. = movie.Title;
            //getAbout.Sinopse = movie.Sinopse;
            //getAbout.Relevance = movie.Relevance;
            //getAbout.ReleaseData = movie.ReleaseData;
            //getAbout.RunTime = movie.RunTime;
            //getAbout.AgeGroup = movie.AgeGroup;
            //getAbout.About = movie.About;
            //getMovie.MovieLanguages = movie.MovieLanguages;

            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
