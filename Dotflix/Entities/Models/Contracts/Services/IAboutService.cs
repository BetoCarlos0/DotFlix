using System;
using System.Threading.Tasks;

namespace ApiDotflix.Entities.Models.Contracts.Services
{
    public interface IAboutService
    {
        Task<About> GetByIdAsync(int id);
        Task<bool> UpdateAsync(About movie);
    }
}
