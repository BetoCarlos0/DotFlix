using Dotflix.Models;
using Dotflix.Models.Contracts;
using Dotflix.Models.Contracts.Services;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<Language> GetByIdAsync(Guid id)
        {
            return await _languageRepository.GetByIdAsync(id);
        }

        public async Task<bool> AddAsync(Language language)
        {
            var getLanguage = await _languageRepository.GetByNameAsync(language.Name);

            if (getLanguage != null)
                throw new DbUpdateException($"{getLanguage.Name} já existente");

            await _languageRepository.AddAsync(language);

            return true;
        }

        public async Task<Language> UpdateAsync(Language language)
        {
            return await _languageRepository.UpdateAsync(language);
        }
        public async Task<bool> DeleteId(Guid id)
        {
            return await _languageRepository.DeleteId(id);
        }
    }
}
