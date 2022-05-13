using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dotflix.Models.Contracts
{
    public interface ILanguageRepository
    {
        Task<IEnumerable<Language>> GetAllAsync();
        Task<Language> GetByIdAsync(Guid id);
        Task<Language> GetByNameAsync(string name);
        Task<bool> AddAsync(Language language);
        Task<bool> UpdateAsync(Language language);
        Task<bool> DeleteId(Guid id);
    }
}
