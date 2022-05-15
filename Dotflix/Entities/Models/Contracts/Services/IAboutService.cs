using System;
using System.Threading.Tasks;

namespace ApiDotflix.Entities.Models.Contracts.Services
{
    public interface IAboutService
    {
        //Task<IEnumerable<About>> GetAllAsync();
        Task<About> GetByIdAsync(int id);
        //Task<bool> AddAsync(About movie);
        Task<bool> UpdateAsync(About movie);
        //Task<bool> DeleteId(int id);
    }
}
