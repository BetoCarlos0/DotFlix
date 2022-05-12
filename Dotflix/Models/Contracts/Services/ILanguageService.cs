using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dotflix.Models.Contracts.Services
{
    public interface ILanguageService
    {
        Task<IEnumerable<Language>> GetAllAsync();
        Task<Language> GetByIdAsync(Guid id);
        Task<bool> AddAsync(Language movie);
        Task<Language> UpdateAsync(Language movie);
        Task<bool> DeleteId(Guid id);
    }
}
