using ApiDotflix.Entities.Models.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiDotflix.Entities.Models.Contracts.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieOutputDto>> GetAllAsync();
        Task<MovieOutputById> GetByIdAsync(int id);
        Task<Movie> GetByNameAsync(string name);
        Task<bool> AddAsync(MoviePostInputDto movie);
        Task<bool> UpdateAsync(MoviePutInputDto movie);
        Task<bool> DeleteId(int id);
    }
}
