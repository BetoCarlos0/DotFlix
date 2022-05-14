using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiDotflix.Models.Contracts.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDto>> GetAllAsync();
        Task<Movie> GetByIdAsync(int id);
        Task<Movie> GetByNameAsync(string name);
        Task<bool> AddAsync(Movie movie);
        Task<bool> UpdateAsync(Movie movie);
        Task<bool> DeleteId(int id);
    }
}
