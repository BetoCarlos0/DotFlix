using ApiDotflix.Entities;
using ApiDotflix.Entities.Models;
using ApiDotflix.Entities.Models.Contracts.Repositories;
using ApiDotflix.Entities.Models.Contracts.Services;
using ApiDotflix.Entities.Models.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDotflix.Data.Services
{
    public class AboutService : IAboutService
    {
        private readonly IAboutRepository _aboutRepository;

        public AboutService(IAboutRepository aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }

        public async Task<AboutOutputDto> GetByIdAsync(int id)
        {
            var about = await _aboutRepository.GetByIdAsync(id);

            var aboutDto = MappingOutputAbout(about);
            
            return aboutDto;
        }

        public async Task<bool> UpdateAsync(AboutInputDto aboutDto) 
        {
            var about = MappingInputAbout(aboutDto);

            return await _aboutRepository.UpdateAsync(about);
        }
        
        private About MappingInputAbout(AboutInputDto aboutDto)
        {
            
            var about = new About
            {
                AboutId = aboutDto.AboutId,
                MovieId = aboutDto.MovieId,
                DirectorId = aboutDto.DirectorId,
            };            
            
            var aboutCast = new List<AboutCast>();
            foreach (var entity in aboutDto.Casts)
            {
                aboutCast.Add(new AboutCast() { CastId = entity.Id });
            }

            var aboutGenre = new List<AboutGenre>();
            foreach (var entity in aboutDto.Genres)
            {
                aboutGenre.Add(new AboutGenre() { GenreId = entity.Id });
            }

            var aboutKeyword = new List<AboutKeyword>();
            foreach (var entity in aboutDto.Keywords)
            {
                aboutKeyword.Add(new AboutKeyword() { KeywordId = entity.Id });
            }

            var aboutLanguage = new List<AboutLanguage>();
            foreach (var entity in aboutDto.Casts)
            {
                aboutLanguage.Add(new AboutLanguage() { LanguageId = entity.Id });
            }

            var aboutRoad = new List<AboutRoadMap>();
            foreach (var entity in aboutDto.Casts)
            {
                aboutRoad.Add(new AboutRoadMap() { RoadMapId = entity.Id });
            }

            about.AboutCasts = aboutCast;
            about.AboutGenres = aboutGenre;
            about.AboutKeywords = aboutKeyword;
            about.AboutLanguages = aboutLanguage;
            about.AboutRoadMaps = aboutRoad;

            return about;
        }
        
        private AboutOutputDto MappingOutputAbout(About about)
        {
            var aboutDto = new AboutOutputDto
            {
                AboutId = about.AboutId,
                MovieId = about.MovieId,
                Director = about.Director,
                Casts = MappingEntities(about.AboutCasts.Select(x => x.Cast)),
                Genres = MappingEntities(about.AboutGenres.Select(x => x.Genre)),
                Keywords = MappingEntities(about.AboutKeywords.Select(x => x.Keyword)),
                Languages = MappingEntities(about.AboutLanguages.Select(x => x.Language)),
                RoadMaps = MappingEntities(about.AboutRoadMaps.Select(x => x.RoadMap))
            };

            return aboutDto;
        }
        private IEnumerable<T> MappingEntities<T>(IEnumerable<T> entity) where T : BaseEntity, new()
        {
            var newEntity = new List<T>();
            if (entity != null)
            {
                foreach (var entities in entity)
                    newEntity.Add(new T() { Id = entities.Id, Name = entities.Name});
            }
            return newEntity;
        }
    }
}
