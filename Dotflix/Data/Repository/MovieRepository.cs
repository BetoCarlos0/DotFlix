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
            //var movies = from movie in _dbContext.Movie select new MovieDto()
            //{
            //    MovieId = movie.MovieId,
            //    Title = movie.Title,
            //    RunTime = movie.RunTime,
            //    Image = movie.Image,
            //    AgeGroup = movie.AgeGroup,
            //    Relevance = movie.Relevance
            //};

            //return movies.AsEnumerable();

            return await _dbContext.Movie
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Movie> GetByIdAsync(Guid id)
        {
            var getMovie = await _dbContext.Movie
                .Include(x => x.MovieLanguages)
                    .ThenInclude(x => x.Language)
                .FirstOrDefaultAsync(x => x.MovieId.Equals(id));

            if (getMovie == null)
                throw new DbUpdateException("Id não encontrado");

            return getMovie;
        }

        public async Task<Movie> GetByNameAsync(string name)
        {
            return await _dbContext.Movie.
                FirstOrDefaultAsync(x => x.Title.Equals(name));
        }

        public async Task<bool> AddAsync(Movie movie)
        {
            await _dbContext.Movie.AddAsync(movie);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(Movie movie)
        {
            var getMovie = await _dbContext.Movie
                .Include(x => x.MovieLanguages)
                    .ThenInclude(x => x.Language)
                .FirstOrDefaultAsync(x => x.MovieId.Equals(movie.MovieId));

            if (getMovie == null) return false;

            getMovie.Image = movie.Image;
            getMovie.Title = movie.Title;
            getMovie.Sinopse = movie.Sinopse;
            getMovie.Relevance = movie.Relevance;
            getMovie.ReleaseData = movie.ReleaseData;
            getMovie.RunTime = movie.RunTime;
            getMovie.AgeGroup = movie.AgeGroup;
            getMovie.MovieLanguages = movie.MovieLanguages;

            await _dbContext.SaveChangesAsync();

            return true;
        }
        public async Task<bool> DeleteId(Guid id)
        {
            var getMovie = await _dbContext.Movie
                .FindAsync(id);

            if (getMovie == null)
                throw new DbUpdateException("Id não existe");

            _dbContext.Movie.Remove(getMovie);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
