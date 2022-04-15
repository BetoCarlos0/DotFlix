using Dotflix.Models;
using Dotflix.Models.Contracts;
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

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            #region resultado alternativo
            //var viewMovie = new List<MovieOutput>();

            //var movies = await _dbContext.Movie
            //    .Include(x => x.MovieLanguages)
            //        .ThenInclude(x => x.Language)
            //    .AsNoTracking()
            //    .ToListAsync();

            //foreach (var movie in movies)
            //{
            //    var ViewLanguage = new List<LanguageOutput>();

            //    foreach (var lang in movie.MovieLanguages)
            //    {
            //        ViewLanguage.Add(new LanguageOutput
            //        {
            //            LanguageId = lang.Language.LanguageId,
            //            Name = lang.Language.Name
            //        });

            //    }

            //    viewMovie.Add(new MovieOutput
            //    {
            //        MovieId = movie.MovieId,
            //        Title = movie.Title,
            //        Image = movie.Image,
            //        Sinopse = movie.Sinopse,
            //        ReleaseData = movie.ReleaseData,
            //        Relevance = movie.Relevance,
            //        RunTime = movie.RunTime,
            //        AgeGroup = movie.AgeGroup,
            //        Languages = ViewLanguage
            //    }); ;
            //}

            //return viewMovie;
            #endregion

            return await _dbContext.Movie
                .Include(x => x.MovieLanguages)
                    .ThenInclude(x => x.Language)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            return await _dbContext.Movie
                .Include(x => x.MovieLanguages)
                    .ThenInclude(x => x.Language)
                .FirstOrDefaultAsync(x => x.MovieId == id);
        }
        public async Task<Movie> AddAsync(Movie movie)
        {
            var result = await _dbContext.Movie.AddAsync(movie);
            await _dbContext.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Movie> UpdateAsync(Movie movie)
        {
            var getMovie = await _dbContext.Movie
                .FirstOrDefaultAsync(e => e.MovieId == movie.MovieId);

            if (getMovie != null)
            {
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

            return null;
        }
        public async Task<Movie> DeleteId(int id)
        {
            var getMovie = await _dbContext.Movie
                .FirstOrDefaultAsync(e => e.MovieId == id);

            if (getMovie != null)
            {
                _dbContext.Movie.Remove(getMovie);
                await _dbContext.SaveChangesAsync();
                return getMovie;
            }
            return null;
        }
    }
}
