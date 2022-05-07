using Dotflix.Models;
using Dotflix.Models.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await _dbContext.Movie
                .Include(x => x.MovieLanguages)
                    .ThenInclude(x => x.Language)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Movie> GetByIdAsync(Guid id)
        {
            return await _dbContext.Movie
                .Include(x => x.MovieLanguages)
                    .ThenInclude(x => x.Language)
                .FirstOrDefaultAsync(x => x.MovieId.Equals(id));
        }
        public async Task<Movie> AddAsync(Movie movie)
        {
            var getMovie = await _dbContext.Movie.FirstOrDefaultAsync(x => x.Title.Equals(movie.Title));

            if (getMovie == null)
            {
                return null;
            }
            else
            {
                return getMovie;
            }
            var result = await _dbContext.Movie.AddAsync(movie);
            await _dbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Movie> UpdateAsync(Movie movie)
        {
            var getMovie = await _dbContext.Movie
                .Include(x => x.MovieLanguages)
                    .ThenInclude(x => x.Language)
                .FirstOrDefaultAsync(x => x.MovieId.Equals(movie.MovieId));

            if (getMovie == null) return null;

            getMovie.Image = movie.Image;
            getMovie.Title = movie.Title;
            getMovie.Sinopse = movie.Sinopse;
            getMovie.Relevance = movie.Relevance;
            getMovie.ReleaseData = movie.ReleaseData;
            getMovie.RunTime = movie.RunTime;
            getMovie.AgeGroup = movie.AgeGroup;
            getMovie.MovieLanguages = movie.MovieLanguages;

            await _dbContext.SaveChangesAsync();

            return getMovie;
        }
        public async Task<bool> DeleteId(Guid id)
        {
            var getMovie = await _dbContext.Movie
                .FirstOrDefaultAsync(e => e.MovieId == id);

            if (getMovie != null)
            {
                _dbContext.Movie.Remove(getMovie);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            return false;
        }
    }
}
