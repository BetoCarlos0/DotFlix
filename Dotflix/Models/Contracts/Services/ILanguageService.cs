using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dotflix.Models.Contracts.Services
{
    public interface ILanguageService
    {
        Task<IEnumerable<Language>> GetAllAsync();
        Task<Language> GetByIdAsync(int id);
        Task<Language> AddAsync(Language movie);
        Task<Language> UpdateAsync(Language movie);
        Task<Language> DeleteId(int id);
    }
}
