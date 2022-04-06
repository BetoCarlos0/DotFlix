using Dotflix.Models;
using Dotflix.Models.Contracts;
using Dotflix.Models.Contracts.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dotflix.Data.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguageService(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }

        public async Task<IEnumerable<Language>> GetAllAsync()
        {
            return await _languageRepository.GetAllAsync();
        }

        public async Task<Language> GetByIdAsync(int id)
        {
            return await _languageRepository.GetByIdAsync(id);
        }

        public async Task<Language> AddAsync(Language language)
        {
            return await _languageRepository.AddAsync(language);
        }

        public async Task<Language> UpdateAsync(Language language)
        {
            return await _languageRepository.UpdateAsync(language);
        }
        public async Task<Language> DeleteId(int id)
        {
            return await _languageRepository.DeleteId(id);
        }
    }
}
