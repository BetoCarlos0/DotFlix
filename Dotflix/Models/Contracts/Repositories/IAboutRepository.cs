using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiDotflix.Models.Contracts
{
    public interface IAboutRepository
    {
        //Task<IEnumerable<About>> GetAllAsync();
        Task<About> GetByIdAsync(int id);
        //Task<bool> AddAsync(About movie);
        Task<bool> UpdateAsync(About movie);
        //Task<bool> DeleteId(int id);
    }
}
