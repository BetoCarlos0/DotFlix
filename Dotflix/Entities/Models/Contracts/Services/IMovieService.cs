using ApiDotflix.Entities.Models.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiDotflix.Entities.Models.Contracts.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieOutputDto>> GetAllAsync();
        Task<Movie> GetByIdAsync(int id);
        Task<Movie> GetByNameAsync(string name);
        Task<bool> AddAsync(MovieInputDto movie);
        Task<bool> UpdateAsync(Movie movie);
        Task<bool> DeleteId(int id);
    }
}
