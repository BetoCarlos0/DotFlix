using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiDotflix.Entities.Models.Contracts.Services
{
    public interface IGenreService
    {
        Task<IEnumerable<Genre>> GetAllAsync();
        Task<Genre> GetByIdAsync(int id);
        Task<bool> AddAsync(Genre genre);
        Task<bool> UpdateAsync(Genre genre);
        Task<bool> DeleteId(int id);
    }
}
