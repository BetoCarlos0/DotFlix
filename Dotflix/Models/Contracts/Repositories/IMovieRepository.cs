using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiDotflix.Models.Contracts
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllAsync();
        Task<Movie> GetByIdAsync(int id);
        Task<Movie> GetByNameAsync(string name);
        Task<bool> AddAsync(Movie movie);
        Task<bool> UpdateAsync(Movie movie);
        Task<bool> DeleteId(int id);
    }
}
