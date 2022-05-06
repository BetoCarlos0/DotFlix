using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dotflix.Models.Contracts
{
    public interface ILanguageRepository
    {
        Task<IEnumerable<Language>> GetAllAsync();
        Task<Language> GetByIdAsync(Guid id);
        Task<Language> AddAsync(Language movie);
        Task<Language> UpdateAsync(Language movie);
        Task<bool> DeleteId(Guid id);
    }
}
