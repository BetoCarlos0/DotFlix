using ApiDotflix.Entities.Models.Contracts.Repositories;
using ApiDotflix.Entities.Models.Contracts.Services;
using ApiDotflix.Entities.Models.Dtos;
using System.Threading.Tasks;
using ApiDotflix.Mapping;

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

            var aboutDto = MappingEntities.MappingOutputAbout(about);

            return aboutDto;
        }

        public async Task<bool> UpdateAsync(AboutInputDto aboutDto) 
        {
            var about = MappingEntities.MappingInputAbout(aboutDto);

            return await _aboutRepository.UpdateAsync(about);
        }
    }
}
