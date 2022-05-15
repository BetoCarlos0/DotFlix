using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiDotflix.Entities.Models.Contracts
{
    public interface IGenreRepository
    {
        Task<IEnumerable<Genre>> GetAllAsync();
        Task<Genre> GetByIdAsync(int id);
        Task<Genre> GetByNameAsync(string name);
        Task<bool> AddAsync(Genre genre);
        Task<bool> UpdateAsync(Genre genre);
        Task<bool> DeleteId(int id);
    }
}
