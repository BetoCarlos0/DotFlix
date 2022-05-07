using Dotflix.Controllers;
using Dotflix.Data.Services;
using Dotflix.Models;
using Dotflix.Models.Contracts;
using Dotflix.Models.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
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
        private static new readonly List<Movie> _movies = new List<Movie>()
        {
            new Movie
            {
                MovieId = new Guid("d495e18e-3a41-404d-bdb6-d71196699811"),
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
                        MovieId = new Guid("d495e18e-3a41-404d-bdb6-d71196699811"),
                        LanguageId = new Guid("c9db8681-a670-4750-a839-f75f9e85d0f5"),
                        Language = new Language(){
                            LanguageId = new Guid("c9db8681-a670-4750-a839-f75f9e85d0f5"),
                            Name = "portugues"
                        }
                    }
                }
            },
            new Movie
            {
                MovieId = new Guid("58edeefa-ce6e-4248-90ae-47fcf38313ab"),
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
                        MovieId = new Guid("58edeefa-ce6e-4248-90ae-47fcf38313ab"),
                        LanguageId = new Guid("c9db8681-a670-4750-a839-f75f9e85d0f5"),
                        Language = new Language(){
                            LanguageId = new Guid("c9db8681-a670-4750-a839-f75f9e85d0f5"),
                            Name = "portugues"
                        }
                    },
                    new MovieLanguage()
                    {
                        MovieId = new Guid("58edeefa-ce6e-4248-90ae-47fcf38313ab"),
                        LanguageId = new Guid("b84c7cce-f651-4a0d-98ab-8dc13a7898a9"),
                        Language = new Language(){
                            LanguageId = new Guid("b84c7cce-f651-4a0d-98ab-8dc13a7898a9"),
                            Name = "Ingles"
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
            Guid id = new Guid("58edeefa-ce6e-4248-90ae-47fcf38313ab");
            var getMovie = _movies.FirstOrDefault(x => x.MovieId == id);
            _mockService.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(getMovie);

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
            Guid id = new Guid("dd376a06-e466-4596-9769-ddcc5fe14664");
            var getMovie = _movies.FirstOrDefault(x => x.MovieId == id);
            _mockService.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(getMovie);

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
                MovieId = new Guid("38d8444f-5eb8-442c-bbd4-1b62bf7d1c68"),
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
                        LanguageId = new Guid("c9db8681-a670-4750-a839-f75f9e85d0f5")
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
                MovieId = new Guid("dd376a06-e466-4596-9769-ddcc5fe14664"),
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
                        LanguageId = new Guid("c9db8681-a670-4750-a839-f75f9e85d0f5")
                    }
                }
            };
            Guid guidResult;
            _mockService.Setup(x => x.AddAsync(newMovie)).ReturnsAsync(newMovie);

            //act
            var result = await _movieController.CreateMovie(newMovie);

            //assert
            //Assert.Equal("dd376a06-e466-4596-9769-ddcc5fe14664", newMovie.MovieId);
            Assert.True(Guid.TryParse("dd376a06-e466-4596-9769-ddcc5fe14664", out guidResult));
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
                MovieId = new Guid("dd376a06-e466-4596-9769-ddcc5fe14664"),
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
                        LanguageId = new Guid("c9db8681-a670-4750-a839-f75f9e85d0f5")
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
                MovieId = new Guid("dd376a06-e466-4596-9769-ddcc5fe14664"),
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
                        LanguageId = new Guid("c9db8681-a670-4750-a839-f75f9e85d0f5")
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
            Guid id = new Guid();
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
                        LanguageId = new Guid("c9db8681-a670-4750-a839-f75f9e85d0f5")
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
            Guid id = new Guid();
            var updateMovie = new Movie
            {
                MovieId = new Guid(),
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
                        LanguageId = new Guid("c9db8681-a670-4750-a839-f75f9e85d0f5")
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
            Guid id = new Guid("dd376a06-e466-4596-9769-ddcc5fe14664");
            _mockService.Setup(x => x.DeleteId(It.IsAny<Guid>())).ReturnsAsync(false);

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
            Guid id = new Guid("dd376a06-e466-4596-9769-ddcc5fe14664");
            _mockService.Setup(x => x.DeleteId(It.IsAny<Guid>())).ReturnsAsync(true);

            //act
            var movie = await _movieController.Delete(id);

            //assert
            Assert.IsType<OkResult>(movie);
        }
    }
}
