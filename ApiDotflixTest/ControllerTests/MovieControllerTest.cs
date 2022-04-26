using Dotflix.Controllers;
using Dotflix.Models;
using Dotflix.Models.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiDotflixTest.ControllerTests
{
    public class MovieControllerTest : BaseMovieControllerTest
    {
        private static List<Movie> movies = new List<Movie>
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
                        Language = new Language(){
                            LanguageId = 1, Name = "portugues"
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

        public MovieControllerTest() : base(new List<Movie>(movies))
        {
        }

        [Fact]
        [Trait("Movie", "GetMovie")]
        public async Task GetAllMovies_Whencalled_ReturnOk()
        {
            //arrange act
            var movies = await _movieController.GetAllMovies();

            //assert
            var result = movies.Result;
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        [Trait("Movie", "GetMovie")]
        public async Task GetMovieById_WhenCalled_ReturnOk()
        {
            //arrange
            int id = 2;
            var getMovie = _movies.FirstOrDefault(x => x.MovieId == id);
            _mockService.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(getMovie);

            //act
            var movie = await _movieController.GetMovie(id);

            //assert
            var result = movie.Result;
            var actionValue = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(id, ((Movie)actionValue.Value).MovieId);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        [Trait("Movie", "GetMovie")]
        public async Task GetMoviById_WhenCalled_ReturnBadRequest()
        {
            //arrange
            int id = -1;
            var getMovie = _movies.FirstOrDefault(x => x.MovieId == id);
            _mockService.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(getMovie);

            //act
            var movie = await _movieController.GetMovie(id);

            //assert
            var result = movie.Result;
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        [Trait("Movie", "GetMovie")]
        public async Task GetMoviById_WhenCalled_ReturnNotFound()
        {
            //arrange
            int id = 3;
            var getMovie = _movies.FirstOrDefault(x => x.MovieId == id);
            _mockService.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(getMovie);

            //act
            var movie = await _movieController.GetMovie(id);

            //assert
            var result = movie.Result;
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        [Trait("Movie", "PostMovie")]
        public async Task CreateMovie_WhenCalled_ReturnCreated()
        {
            //arrange
            var newMovie = new Movie
            {
                MovieId = 3,
                Title = "novo filme",
                Sinopse = "um filme de teste",
                Image = "imgTeste",
                AgeGroup = "14",
                ReleaseData = new DateTime(2010, 2, 20),
                Relevance = 10,
                RunTime = new DateTime(2021, 5, 10, 15, 20, 20),
                MovieLanguages = new List<MovieLanguage>()
                {
                    new MovieLanguage()
                    {
                        LanguageId = 1
                    }
                }
            };

            _mockService.Setup(x => x.AddAsync(It.IsAny<Movie>())).ReturnsAsync(newMovie);

            //act
            var result = await _movieController.CreateMovie(newMovie);

            //assert
            var actionResult = result.Result;
            Assert.Equal(3, newMovie.MovieId);
            Assert.Equal(new DateTime(2021, 5, 10, 15, 20, 20), newMovie.RunTime);
            Assert.Equal(new DateTime(2010, 2, 20), newMovie.ReleaseData);
            Assert.IsType<CreatedAtActionResult>(actionResult);
        }

        [Fact]
        [Trait("Movie", "PostMovie")]
        public async Task CreateMovie_FieldNull_ReturnBadRequest()
        {
            //arrange
            var newMovie = new Movie
            {
                MovieId = 0,
                Title = "novo filme",
                Sinopse = "um filme de teste",
                Image = null,
                AgeGroup = "14",
                ReleaseData = new DateTime(2010, 2, 20),
                Relevance = 10,
                RunTime = new DateTime(2021, 5, 10, 15, 20, 20),
                MovieLanguages = new List<MovieLanguage>()
                {
                    new MovieLanguage()
                    {
                        LanguageId = 1
                    }
                }
            };

            _mockService.Setup(x => x.AddAsync(newMovie)).ReturnsAsync(newMovie);

            //act
            var result = await _movieController.CreateMovie(newMovie);

            //assert
            var actionResult = result.Result;
            //var actionValue = Assert.IsType<BadRequestResult>(actionResult);
            //Assert.Null(newMovie.Languages);

            //ArgumentNullException exception = Assert.Throws<ArgumentNullException>(result);
            //Assert.Throws<ArgumentNullException>(result);
            //Assert.Equal("erro", exception.Message);
            Assert.IsType<ArgumentNullException>(actionResult);
        }
    }
}
