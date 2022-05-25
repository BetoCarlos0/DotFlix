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
                AboutCasts = MappingMToMEntities(aboutDto.Casts.Select(x => x.Id)),
                //Genres = MappingEntities(about.AboutGenres.Select(x => x.Genre)),
                //Keywords = MappingEntities(about.AboutKeywords.Select(x => x.Keyword)),
                //Languages = MappingEntities(about.AboutLanguages.Select(x => x.Language)),
                //RoadMaps = MappingEntities(about.AboutRoadMaps.Select(x => x.RoadMap))
            };
            about.AboutCasts.Select(x => x.CastId);
            
            var aboutCast = new List<AboutCast>();
            foreach (var entity in aboutDto.Casts)
            {
                aboutCast.Add(new AboutCast() { CastId = entity.Id });
            }
            about.AboutCasts = aboutCast;

            //about.AboutCasts.Concat(aboutCast);
            return about;
        }

        private IEnumerable<T> MappingMToMEntities<T>(IEnumerable<int> entity) where T : int, new()// where TEntity : BaseEntityDto
        {
            var newEntity = new List<T>();
            if (entity != null)
            {
                foreach (var entities in entity)
                    newEntity.Add(new T() {Id = entities.Id});
            }
            return newEntity;
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
