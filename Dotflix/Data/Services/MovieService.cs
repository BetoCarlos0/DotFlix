using ApiDotflix.Models;
using ApiDotflix.Models.Contracts;
using ApiDotflix.Models.Contracts.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiDotflix.Data.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<MovieDto>> GetAllAsync()
        {
            var movies = await _movieRepository.GetAllAsync();
            var movieDto = new List<MovieDto>();

            foreach(var movie in movies)
            {
                movieDto.Add(new MovieDto
                {
                    MovieId = movie.MovieId,
                    Title = movie.Title,
                    RunTime = movie.RunTime,
                    Image = movie.Image,
                    AgeGroup = movie.AgeGroup,
                    Relevance = movie.Relevance
                });

            }
            return movieDto;
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            return await _movieRepository.GetByIdAsync(id);
        }

        public async Task<Movie> GetByNameAsync(string name)
        {
            return await _movieRepository.GetByNameAsync(name);
        }

        public async Task<bool> AddAsync(Movie movie)
        {
            var getMovie = await _movieRepository.GetByNameAsync(movie.Title);

            if (getMovie == null)
                return await _movieRepository.AddAsync(movie);
            else
                throw new DbUpdateException($"{movie.Title} já existente");
        }

        public async Task<bool> UpdateAsync(Movie movie) 
        {
            var getMovie = await _movieRepository.GetByNameAsync(movie.Title);

            if (getMovie == null)
                return await _movieRepository.UpdateAsync(movie);

            if (getMovie.MovieId != movie.MovieId)
                throw new DbUpdateException($"{getMovie.Title} já existente");

            return true;
        }

        public async Task<bool> DeleteId(int id)
        {
            return await _movieRepository.DeleteId(id);
        }
    }
}
