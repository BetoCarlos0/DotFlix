using Dotflix.Models;
using Dotflix.Models.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDotflixTest
{
    public class MovieServiceFake// : IMovieService
    {
        /*private readonly List<Movie> _movies;

        public MovieServiceFake()
        {
            _movies = new List<Movie>
            {
                new Movie
                {
                    MovieId = 1,
                    AgeGroup = "0",
                    Image = "img2",
                    ReleaseData = new DateTime(2021, 5, 10),
                    RunTime = new DateTime(2021, 5, 10, 15, 20, 20),
                    Sinopse = "uma sinopse",
                    Title = "um filme",
                    Relevance = 45,
                    MovieLanguages = new List<MovieLanguage>()
                    {
                        new MovieLanguage()
                        {
                            LanguageId = 1,
                            MovieId = 1,
                            Language = new Language()
                            {
                                LanguageId = 1,
                                Name = "portugues"
                            }
                        }
                    }
                },
                new Movie
                {
                    MovieId = 2,
                    AgeGroup = "10",
                    Image = "img1",
                    ReleaseData = new DateTime(2021, 5, 10),
                    RunTime = new DateTime(2021, 5, 10, 15, 20, 20),
                    Sinopse = "outra sinopse",
                    Title = "outro filme",
                    Relevance = 15,
                    MovieLanguages = new List<MovieLanguage>()
                    {
                        new MovieLanguage()
                        {
                            LanguageId = 1,
                            MovieId = 2,
                            Language = new Language(){
                                LanguageId = 1, Name = "portugues"
                            }
                        },
                        new MovieLanguage()
                        {
                            LanguageId = 2,
                            MovieId = 2,
                            Language = new Language(){
                                LanguageId = 2, Name = "Ingles"
                            }
                        }
                    }
                }
            };
        }
        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return _movies;
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            return _movies.FirstOrDefault(x => x.MovieId == id);
        }

        public async Task AddAsync(Movie movie)
        {
            _movies.Add(movie);
        }

        public async Task UpdateAsync(Movie movie)
        {
            var getMovie = _movies.FirstOrDefault(x => x.MovieId == movie.MovieId);

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
            }
        }
        public async Task DeleteId(int id)
        {
            var getMovie = _movies.FirstOrDefault(x => x.MovieId == id);

            if (getMovie != null)
                _movies.Remove(getMovie);
        }*/
    }
}
