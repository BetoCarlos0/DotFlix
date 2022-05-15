using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiDotflix.Entities.Models.Contracts
{
    public interface IAboutRepository
    {
        Task<About> GetByIdAsync(int id);
        Task<bool> UpdateAsync(About movie);
    }
}
