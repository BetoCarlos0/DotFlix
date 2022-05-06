using Dotflix.Models;
using Dotflix.Models.Contracts;
using Dotflix.Models.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dotflix.Data.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await _movieRepository.GetAllAsync();
        }

        public async Task<Movie> GetByIdAsync(Guid id)
        {
            return await _movieRepository.GetByIdAsync(id);
        }

        public async Task<Movie> AddAsync(Movie movie)
        {
            return await _movieRepository.AddAsync(movie);
        }

        public async Task<Movie> UpdateAsync(Movie movie) 
        {
            return await _movieRepository.UpdateAsync(movie);
        }

        public async Task<bool> DeleteId(Guid id)
        {
            return await _movieRepository.DeleteId(id);
        }
    }
}
