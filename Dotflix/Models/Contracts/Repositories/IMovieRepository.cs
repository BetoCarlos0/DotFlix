﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dotflix.Models.Contracts
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllAsync();
        Task<Movie> AddAsync(Movie movie);
        Task<Movie> GetByIdAsync(int id);
        Task<Movie> UpdateAsync(Movie movie);
        Task<Movie> DeleteId(int id);
    }
}