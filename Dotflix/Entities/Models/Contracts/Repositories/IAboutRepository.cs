using ApiDotflix.Entities.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiDotflix.Entities.Models.Contracts.Repositories
{
    public interface IAboutRepository
    {
        Task<About> GetByIdAsync(int id);
        Task<bool> UpdateAsync(AboutPutInputDto movie);
    }
}
