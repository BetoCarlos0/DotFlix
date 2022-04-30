using Dotflix.Controllers;
using Dotflix.Data.Services;
using Dotflix.Models;
using Dotflix.Models.Contracts;
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
    public class MovieControllerTest : BaseControllerTest
    {
        private static new readonly List<Movie> _movies = new List<Movie>()
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

        public MovieControllerTest() : base(new List<Movie>(_movies))
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
        public async Task GetMovieById_WhenCalled_ReturnNotFound()
        {
            //arrange
            int id = 3;
            var getMovie = _movies.FirstOrDefault(x => x.MovieId == id);
            _mockService.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(getMovie);

            //act
            var movie = await _movieController.GetMovie(id);

            //assert
            var result = movie.Result;
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        [Trait("Movie", "PostMovie")]
        public async Task CreateMovie_DuplicateTitle_ReturnBadRequest()
        {
            //arrange
            var newMovie = new Movie
            {
                MovieId = 2,
                Title = "um filme",
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
            _mockService.Setup(x => x.AddAsync(newMovie)).ReturnsAsync(_movies[0]);

            //act
            var movie = await _movieController.CreateMovie(newMovie);

            //assert
            var result = movie;
            Assert.IsType<BadRequestObjectResult>(movie);
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
            _mockService.Setup(x => x.AddAsync(newMovie)).ReturnsAsync(newMovie);

            //act
            var result = await _movieController.CreateMovie(newMovie);

            //assert
            Assert.Equal(3, newMovie.MovieId);
            Assert.Equal(new DateTime(2021, 5, 10, 15, 20, 20), newMovie.RunTime);
            Assert.Equal(new DateTime(2010, 2, 20), newMovie.ReleaseData);
            Assert.IsType<CreatedAtActionResult>(result);
        }
        
        [Fact]
        [Trait("Movie", "PostMovie")]
        public async Task CreateMovie_FieldNull_ReturnBadRequest()
        {
            //arrange
            var newMovie = new Movie
            {
                MovieId = 0,
                Title = null,
                Sinopse = "um filme de teste",
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
            _mockService.Setup(x => x.AddAsync(newMovie));

            _movieController.ModelState.AddModelError("Title", "Required");

            //act
            var result = await _movieController.CreateMovie(newMovie);

            //assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        [Trait("Movie", "PostMovie")]
        public async Task CreateMovie_CompareType_ResponseHasCreatedMovie()
        {
            //arrange
            var newMovie = new Movie
            {
                MovieId = 0,
                Title = "titulo",
                Sinopse = "um filme de teste",
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
            var result = await _movieController.CreateMovie(newMovie) as CreatedAtActionResult;
            var movie = result.Value as Movie;

            //assert
            Assert.IsType<CreatedAtActionResult>(result);
            Assert.IsType<Movie>(movie);
        }

        [Fact]
        [Trait("Movie", "PutMovie")]
        public async Task UpdateMovie_WhenCalled_ReturnOk()
        {
            //arrange
            int id = 2104;
            var updateMovie = new Movie
            {
                MovieId = id,
                AgeGroup = "0",
                Image = "img2",
                ReleaseData = new DateTime(2021, 5, 10),
                RunTime = new DateTime(2021, 5, 10, 15, 20, 20),
                Sinopse = "uma sinopse",
                Title = "um filme",
                Relevance = 45,
                Languages = new List<Language>()
                {
                    new Language()
                    {
                        LanguageId = 2104
                    }
                }
            };
            var getMovie = await _movieController.GetMovie(id);
            _mockService.Setup(x => x.UpdateAsync(updateMovie)).ReturnsAsync(updateMovie);

            //act
            var movie = await _movieController.UpdateMovie(id, updateMovie);

            //assert
            var result = movie.Result;
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        [Trait("Movie", "PutMovie")]
        public async Task UpdateMovie_CompareId_ReturnBadRequest()
        {
            //arrange
            int id = 2104;
            var updateMovie = new Movie
            {
                MovieId = 2105,
                AgeGroup = "0",
                Image = "img2",
                ReleaseData = new DateTime(2021, 5, 10),
                RunTime = new DateTime(2021, 5, 10, 15, 20, 20),
                Sinopse = "uma sinopse",
                Title = "um filme",
                Relevance = 45,
                Languages = new List<Language>()
                {
                    new Language()
                    {
                        LanguageId = 2104
                    }
                }
            };
            var getMovie = await _movieController.GetMovie(id);
            _mockService.Setup(x => x.UpdateAsync(updateMovie)).ReturnsAsync(updateMovie);

            //act
            var movie = await _movieController.UpdateMovie(id, updateMovie);

            //assert
            var result = movie.Result;
            Assert.IsType<BadRequestObjectResult>(result);
        }
        
        [Fact]
        [Trait("Movie", "DeleteMovie")]
        public async Task DeleteMovie_WhenCalled_ReturnNotFound()
        {
            //arrange
            int id = 2112;
            _mockService.Setup(x => x.DeleteId(It.IsAny<int>())).ReturnsAsync(false);

            //act
            var movie = await _movieController.Delete(id);

            //assert
            Assert.IsType<BadRequestResult>(movie);
        }

        [Fact]
        [Trait("Movie", "DeleteMovie")]
        public async Task DeleteMovie_WhenCalled_ReturnOk()
        {
            //arrange
            int id = 2104;
            _mockService.Setup(x => x.DeleteId(It.IsAny<int>())).ReturnsAsync(true);

            //act
            var movie = await _movieController.Delete(id);

            //assert
            Assert.IsType<OkResult>(movie);
        }
    }
}
