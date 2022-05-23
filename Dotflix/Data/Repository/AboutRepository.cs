using ApiDotflix.Entities;
using ApiDotflix.Entities.Models;
using ApiDotflix.Entities.Models.Contracts.Repositories;
using ApiDotflix.Entities.Models.Dtos;
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

            //var about = MappingInputAbout(aboutDto);

            //_dbContext.Entry(about).State = EntityState.Modified;

            getAbout.Languages = about.Languages;
            getAbout.Keywords = about.Keywords;
            getAbout.Genres = about.Genres;
            getAbout.RoadMaps = about.RoadMaps;
            getAbout.Casts = about.Casts;
            getAbout.MovieId = about.MovieId;
            getAbout.DirectorId = about.DirectorId;

            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
