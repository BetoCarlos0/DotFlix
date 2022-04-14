using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dotflix.Models.Contracts.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieOutput>> GetAllAsync();
        Task<MovieOutput> GetByIdAsync(int id);
        Task<Movie> AddAsync(Movie movie);
        Task<Movie> UpdateAsync(Movie movie);
        Task<Movie> DeleteId(int id);
    }
}
