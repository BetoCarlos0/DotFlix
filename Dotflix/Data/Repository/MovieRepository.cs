using Dotflix.Models;
using Dotflix.Models.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotflix.Data.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DotflixDbContext _dbContext;

        public MovieRepository(DotflixDbContext dotflixDbContext)
        {
            _dbContext = dotflixDbContext;
        }

        public async Task<Movie> AddAsync(Movie movie)
        {
            var result = await _dbContext.Movie.AddAsync(movie);
            await _dbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await _dbContext.Movie.ToListAsync();
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            return await _dbContext.Movie.FirstOrDefaultAsync(x => x.MovieId == id);
        }

        public void Update(Movie entity)
        {
            throw new System.NotImplementedException();
        }
        public void DeleteId(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
