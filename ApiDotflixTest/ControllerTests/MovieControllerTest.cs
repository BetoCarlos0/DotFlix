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
                Languages = new List<Language>(){
                    new Language(){
                        LanguageId = 1, Name = "portugues"
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

        public MovieControllerTest() : base(new List<Movie>(movies))
        {
        }

        [Fact]
        public async Task GetAllMovies_Whencalled_ReturnOk()
        {
            //arrange act
            var movies = await _movieController.GetAllMovies();

            //assert
            var result = movies.Result;
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetMovieById_WhenCalled_ReturnOk()
        {
            //arrange
            int id = 1;
            var getMovie = _movies.FirstOrDefault(x => x.MovieId == id);

            _mockService.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(getMovie);

            //act
            var movie = await _movieController.GetMovie(id);

            //assert
            var result = movie.Result;
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
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
    }
}
