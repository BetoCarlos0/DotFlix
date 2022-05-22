using ApiDotflix.Entities;
using ApiDotflix.Entities.Models;
using ApiDotflix.Entities.Models.Contracts.Repositories;
using ApiDotflix.Entities.Models.Dtos;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> UpdateAsync(AboutPutInputDto aboutDto)
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
                .FirstOrDefaultAsync(x => x.AboutId.Equals(aboutDto.AboutId));

            if (getAbout == null) return false;

            var about = MappingInputAbout(aboutDto);

            getAbout.Keywords = about.Keywords;
            getAbout.Languages = about.Languages;
            getAbout.Genres = about.Genres;
            getAbout.RoadMaps = about.RoadMaps;
            getAbout.Casts = about.Casts;
            getAbout.MovieId = about.MovieId;
            getAbout.DirectorId = about.DirectorId;

            await _dbContext.SaveChangesAsync();

            return true;
        }
        private About MappingInputAbout(AboutPutInputDto aboutDto)
        {
            var about = new About();

            about.MovieId = aboutDto.MovieId;
            about.DirectorId = aboutDto.DirectorId;
            about.Languages = MappingListEntity<Language>(aboutDto.Languages);
            about.Keywords = MappingListEntity<Keyword>(aboutDto.Keywords);
            about.Casts = MappingListEntity<Cast>(aboutDto.Casts);
            about.Genres = MappingListEntity<Genre>(aboutDto.Genres);
            about.RoadMaps = MappingListEntity<RoadMap>(aboutDto.RoadMaps);



            return about;
        }

        private IEnumerable<T> MappingListEntity<T>(IEnumerable<BaseEntityDto> convertEntity) where T : BaseEntity, new()
        {
            var entity = new List<T>();

            if (convertEntity != null)
            {
                foreach (var convert in convertEntity)
                    entity.Add(new T() { Id = convert.Id });
            }

            return entity;
        }
    }
}
