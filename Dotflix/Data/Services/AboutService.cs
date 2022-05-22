using ApiDotflix.Entities;
using ApiDotflix.Entities.Models.Contracts.Repositories;
using ApiDotflix.Entities.Models.Contracts.Services;
using ApiDotflix.Entities.Models.Dtos;
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

            var aboutDto = new AboutOutputDto
            {
                AboutId = about.AboutId,
                MovieId = about.MovieId,
                Director = about.Director,
                Keywords = about.Keywords,
                Languages = about.Languages,
                Genres = about.Genres,
                RoadMaps = about.RoadMaps,
                Casts = about.Casts,
            };

            return aboutDto;
        }

        public async Task<bool> UpdateAsync(AboutPutInputDto aboutDto) 
        {
            return await _aboutRepository.UpdateAsync(aboutDto);
        }
    }
}
