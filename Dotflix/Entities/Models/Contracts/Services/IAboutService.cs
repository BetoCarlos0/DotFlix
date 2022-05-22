using ApiDotflix.Entities.Models.Dtos;
using System;
using System.Threading.Tasks;

namespace ApiDotflix.Entities.Models.Contracts.Services
{
    public interface IAboutService
    {
        Task<AboutOutputDto> GetByIdAsync(int id);
        Task<bool> UpdateAsync(About movie);
    }
}
