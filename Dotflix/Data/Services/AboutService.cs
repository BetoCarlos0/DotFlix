using ApiDotflix.Models;
using ApiDotflix.Models.Contracts;
using ApiDotflix.Models.Contracts.Services;
using Microsoft.EntityFrameworkCore;
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
