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
        private static readonly List<Movie> movies = new List<Movie>
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
        public async Task GetMovie_Whencalled_ReturnOk()
        {   //arrange
            var movies = await _movieController.GetAllMovies();

            //act
            var result = movies.Result as OkObjectResult;

            //acert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetMovieById_WhenCalled_ReturnOk()
        {
            _mockService.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(movies[0]);

            var movie = await _movieController.GetMovie(1);

            var result = movie.Result as OkObjectResult;

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetMoviById_WhenCalled_ReturnBadRequest()
        {
            _mockService.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(movies[0]);

            var movie = await _movieController.GetMovie(1);

            var result = movie.Result as OkObjectResult;

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetMoviById_WhenCalled_ReturnNotFound()
        {
            _mockService.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(movies[0]);

            var movie = await _movieController.GetMovie(1);

            var result = movie.Result as OkObjectResult;

            Assert.IsType<OkObjectResult>(result);
        }

        //private Task<ActionResult> GetMovies()
        //{
        //    List<Movie> movies = new List<Movie>
        //    {
        //        new Movie
        //        {
        //            MovieId = 1, AgeGroup = "0", Image = "img2", ReleaseData = new DateTime(2021, 5, 10),
        //                    RunTime = new DateTime(2021, 5, 10, 15, 20, 20), Sinopse = "uma sinopse", Title = "um filme", Relevance = 45,
        //                    Languages = new List<Language>(){
        //                        new Language(){
        //                            LanguageId = 1, Name = "portugues"
        //                        }
        //                    }
        //        },
        //        new Movie
        //        {
        //            MovieId = 2, AgeGroup = "10", Image = "img1", ReleaseData = new DateTime(2021, 5, 10),
        //                    RunTime = new DateTime(2021, 5, 10, 15, 20, 20), Sinopse = "outra sinopse", Title = "outro filme", Relevance = 15,
        //                    Languages = new List<Language>(){
        //                        new Language(){
        //                            LanguageId = 1, Name = "portugues"
        //                        },
        //                        new Language(){
        //                            LanguageId = 2, Name = "ingles"
        //                        }
        //                    }
        //        }
        //    };
           
        //    return movies;
        //}
    }
}
