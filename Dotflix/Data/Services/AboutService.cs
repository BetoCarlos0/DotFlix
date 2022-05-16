using ApiDotflix.Entities;
using ApiDotflix.Entities.Models.Contracts.Repositories;
using ApiDotflix.Entities.Models.Contracts.Services;
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

        public async Task<About> GetByIdAsync(int id)
        {
            return await _aboutRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(About about) 
        {
            return await _aboutRepository.UpdateAsync(about);
        }
    }
}
