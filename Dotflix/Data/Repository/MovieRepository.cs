using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using ApiDotflix.Entities;
using ApiDotflix.Entities.Models.Contracts;
using ApiDotflix.Entities.Models.Contracts.Repositories;
using ApiDotflix.Entities.Models.Dtos;
using ApiDotflix.Entities.Models;
using System.Linq;

namespace ApiDotflix.Data.Repository
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
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            var getMovie = await _dbContext.Movie
                .Include(x => x.About)
                    .ThenInclude(x => x.AboutKeywords)
                        .ThenInclude(x => x.Keyword)
                .Include(x => x.About)
                    .ThenInclude(x => x.AboutLanguages)
                        .ThenInclude(x => x.Language)
                .Include(x => x.About)
                    .ThenInclude(x => x.AboutCasts)
                        .ThenInclude(x => x.Cast)
                .Include(x => x.About)
                    .ThenInclude(x => x.AboutGenres)
                        .ThenInclude(x => x.Genre)
                .Include(x => x.About)
                    .ThenInclude(x => x.AboutRoadMaps)
                        .ThenInclude(x => x.RoadMap)
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
            if (!movie.About.Genres.Any())
                throw new DbUpdateException("Gênero Vazio");
            if (!movie.About.Languages.Any())
                throw new DbUpdateException("Idioma Vazio");
            if (!movie.About.Casts.Any())
                throw new DbUpdateException("Elenco Vazio");

            await _dbContext.Movie.AddAsync(movie);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(Movie movie)
        {
            var getMovie = await _dbContext.Movie
                .Include(x => x.About)
                    .ThenInclude(x => x.AboutKeywords)
                        .ThenInclude(x => x.Keyword)
                .Include(x => x.About)
                    .ThenInclude(x => x.AboutLanguages)
                        .ThenInclude(x => x.Language)
                .Include(x => x.About)
                    .ThenInclude(x => x.AboutCasts)
                        .ThenInclude(x => x.Cast)
                .Include(x => x.About)
                    .ThenInclude(x => x.AboutGenres)
                        .ThenInclude(x => x.Genre)
                .Include(x => x.About)
                    .ThenInclude(x => x.AboutRoadMaps)
                        .ThenInclude(x => x.RoadMap)
                .FirstOrDefaultAsync(x => x.MovieId.Equals(movie.MovieId));

            if (getMovie == null) return false;

            getMovie.Image = movie.Image;
            getMovie.Title = movie.Title;
            getMovie.Sinopse = movie.Sinopse;
            getMovie.Relevance = movie.Relevance;
            getMovie.ReleaseData = movie.ReleaseData;
            getMovie.RunTime = movie.RunTime;
            getMovie.AgeGroup = movie.AgeGroup;
            getMovie.About = movie.About;

            await _dbContext.SaveChangesAsync();

            return true;
        }
        public async Task<bool> DeleteId(int id)
        {
            var getMovie = await _dbContext.Movie
                .Include(x => x.About)
                .FirstOrDefaultAsync(x => x.MovieId.Equals(id));

            if (getMovie == null)
                throw new DbUpdateException("Id não existe");

            _dbContext.Movie.Remove(getMovie);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
