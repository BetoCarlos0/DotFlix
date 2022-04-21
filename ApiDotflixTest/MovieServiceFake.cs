using Dotflix.Models;
using Dotflix.Models.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDotflixTest
{
    public class MovieServiceFake
    {
        /*private readonly List<Movie> _movie;

        public MovieServiceFake()
        {
            _movie = new List<Movie>()
            {
                new Movie()
                {
                    MovieId = 1, AgeGroup = "0", Image = "img2", ReleaseData = new DateTime(2021, 5, 10),
                    RunTime = new DateTime(2021, 5, 10, 15, 20, 20), Sinopse = "uma sinopse", Title = "um filme", Relevance = 45,
                    Languages = new List<Language>(){
                        new Language(){
                            LanguageId = 1, Name = "portugues"
                        }
                    }
                },
                new Movie()
                {
                    MovieId = 2, AgeGroup = "10", Image = "img1", ReleaseData = new DateTime(2021, 5, 10),
                    RunTime = new DateTime(2021, 5, 10, 15, 20, 20), Sinopse = "outra sinopse", Title = "outro filme", Relevance = 15,
                    Languages = new List<Language>(){
                        new Language(){
                            LanguageId = 1, Name = "portugues"
                        },
                        new Language(){
                            LanguageId = 2, Name = "ingles"
                        }
                    }
                }
            };
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return _movie;
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            return _movie.FirstOrDefault(x => x.MovieId == id);
        }

        public async Task<Movie> AddAsync(Movie movie)
        {
            var getLast = _movie.Last();
            movie.MovieId = getLast.MovieId + 1;
            _movie.Add(movie);
            return movie;
        }

        public async Task<Movie> UpdateAsync(Movie movie)
        {
            var getMovie = _movie.FirstOrDefault(x => x.MovieId == movie.MovieId);

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

                return getMovie;
            }
            return null;
        }
        public async Task<Movie> DeleteId(int id)
        {
            var getMovie = _movie.FirstOrDefault(x => x.MovieId == id);

            if (getMovie != null)
            {
                _movie.Remove(getMovie);
            }
            return null;
        }*/
    }    
}
