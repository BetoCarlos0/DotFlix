using Dotflix.Models;
using Dotflix.Models.Contracts;
using Dotflix.Models.Contracts.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dotflix.Data.Services
{
    public class MovieService : IMovieService
    {
        /*private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }*/

        public Task<Movie> AddAsync(Movie movie)
        {
            //return _movieRepository.AddAsync(movie);
            throw new System.NotImplementedException();
        }

        public void DeleteId(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Movie>> GetAllAsync()
        {
            //return _movieRepository.GetAllAsync();
            throw new System.NotImplementedException();
        }

        public Task<Movie> GetByIdAsync(int id)
        {
            //return _movieRepository.GetByIdAsync(id);
            throw new System.NotImplementedException();
        }

        public void Update(Movie entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
