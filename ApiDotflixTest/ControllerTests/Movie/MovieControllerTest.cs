using Dotflix.Controllers;
using Dotflix.Data.Services;
using Dotflix.Models;
using Dotflix.Models.Contracts;
using Dotflix.Models.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [Fact, Trait("Movie", "GetMovie")]
        public async Task GetAllMovies_Whencalled_ReturnOk()
        {
            //arrange
            var mockService = new Mock<IMovieService>();
            mockService.Setup(x => x.GetAllAsync());
            var movieController = new MovieController(mockService.Object);

            //act
            var movie = await movieController.GetAllMovies();

            //assert
            var result = movie.Result;
            Assert.IsType<OkObjectResult>(result);
        }
        
        [Fact, Trait("Movie", "GetMovie")]
        public async Task GetMovieById_WhenCalled_ReturnOk()
        {
            //arrange
            var id = new Guid("d495e18e-3a41-404d-bdb6-d71196699811");
            
            var mockService = new Mock<IMovieService>();
            mockService.Setup(x => x.GetByIdAsync(It.IsAny<Guid>()));
            var movieController = new MovieController(mockService.Object);

            //act
            var movie = await movieController.GetMovie(id);

            //assert
            var result = movie.Result;
            Assert.IsType<OkObjectResult>(result);
        }
        
        [Fact, Trait("Movie", "GetMovie")]
        public async Task GetMovieById_WhenCalled_ReturnNotFound()
        {
            var id = new Guid("d495e18e-3a41-404d-bdb6-d71196699812");

            var mockService = new Mock<IMovieService>();
            mockService.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ThrowsAsync(new DbUpdateException());
            var movieController = new MovieController(mockService.Object);

            //act
            var movie = await movieController.GetMovie(id);

            //assert
            var result = movie.Result;
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact, Trait("Movie", "CreateMovie")]
        public async Task CreateMovie_DuplicateTitle_ReturnBadRequest()
        {
            //arrange
            var newMovie = new Movie
            {
                MovieId = new Guid("0140adbe-eac0-4e7e-8b85-126181ed456b"),
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
            var mockService = new Mock<IMovieService>();
            mockService.Setup(x => x.AddAsync(It.IsAny<Movie>())).ThrowsAsync(new DbUpdateException());
            var movieController = new MovieController(mockService.Object);

            //act
            var movie = await movieController.CreateMovie(newMovie);

            //assert
            var result = movie;
            Assert.IsType<BadRequestObjectResult>(movie);
        }
        
        [Fact, Trait("Movie", "PostMovie")]
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
            var mockService = new Mock<IMovieService>();
            mockService.Setup(x => x.AddAsync(It.IsAny<Movie>()));
            var movieController = new MovieController(mockService.Object);

            //act
            var movie = await movieController.CreateMovie(newMovie);

            //assert
            var result = movie;
            Assert.IsType<CreatedAtActionResult>(movie);
        }
        
        [Fact, Trait("Movie", "PostMovie")]
        public async Task CreateMovie_FieldNull_ReturnBadRequest()
        {
            //arrange
            var newMovie = new Movie
            {
                MovieId = new Guid("0140adbe-eac0-4e7e-8b85-126181ed456b"),
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
            var mockService = new Mock<IMovieService>();
            mockService.Setup(x => x.AddAsync(It.IsAny<Movie>()));
            var movieController = new MovieController(mockService.Object);
            movieController.ModelState.AddModelError("Title", "Required");

            //act
            var movie = await movieController.CreateMovie(newMovie);

            //assert
            Assert.IsType<BadRequestObjectResult>(movie);
        }
        
        [Fact, Trait("Movie", "PutMovie")]
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
            var mockService = new Mock<IMovieService>();
            mockService.Setup(x => x.UpdateAsync(It.IsAny<Movie>()));
            var movieController = new MovieController(mockService.Object);

            //act
            var movie = await movieController.UpdateMovie(id, updateMovie);

            //assert
            Assert.IsType<OkObjectResult>(movie);
        }
        
        [Fact, Trait("Movie", "PutMovie")]
        public async Task UpdateMovie_CompareId_ReturnBadRequest()
        {
            //arrange
            Guid id = new Guid("d495e18e-3a41-404d-bdb6-d71196699812");
            var updateMovie = new Movie
            {
                MovieId = new Guid("d495e18e-3a41-404d-bdb6-d71196699811"),
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
            var mockService = new Mock<IMovieService>();
            mockService.Setup(x => x.UpdateAsync(It.IsAny<Movie>()));
            var movieController = new MovieController(mockService.Object);

            //act
            var movie = await movieController.UpdateMovie(id, updateMovie);

            //assert
            Assert.IsType<BadRequestObjectResult>(movie);
        }
        
        [Fact, Trait("Movie", "UpdateMovie")]
        public async Task UpdateMovie_DuplicateTitle_ReturnBadRequest()
        {
            //arrange
            Guid id = new Guid("d495e18e-3a41-404d-bdb6-d71196699811");
            var updateMovie = new Movie
            {
                MovieId = new Guid("d495e18e-3a41-404d-bdb6-d71196699811"),
                Title = "outro filme",
                AgeGroup = "0",
                Image = "img2",
                ReleaseData = new DateTime(2021, 5, 10),
                RunTime = new DateTime(2021, 5, 10, 15, 20, 20),
                Sinopse = "uma sinopse",
                Relevance = 45,
                Languages = new List<Language>()
                {
                    new Language()
                    {
                        LanguageId = new Guid("c9db8681-a670-4750-a839-f75f9e85d0f5")
                    }
                }
            };
            var mockService = new Mock<IMovieService>();
            mockService.Setup(x => x.UpdateAsync(It.IsAny<Movie>())).ThrowsAsync(new DbUpdateException());
            var movieController = new MovieController(mockService.Object);

            //act
            var movie = await movieController.UpdateMovie(id, updateMovie);

            //assert
            Assert.IsType<BadRequestObjectResult>(movie);
        }
        
        [Fact, Trait("Movie", "DeleteMovie")]
        public async Task DeleteMovie_WhenCalled_ReturnOk()
        {
            //arrange
            Guid id = new Guid("d495e18e-3a41-404d-bdb6-d71196699811");
            var mockService = new Mock<IMovieService>();
            mockService.Setup(x => x.DeleteId(It.IsAny<Guid>()));
            var movieController = new MovieController(mockService.Object);

            //act
            var movie = await movieController.Delete(id);

            //assert
            Assert.IsType<OkObjectResult>(movie);
        }
        
        [Fact, Trait("Movie", "DeleteMovie")]
        public async Task DeleteMovie_WhenCalled_ReturnNotFound()
        {
            //arrange
            Guid id = new Guid("d495e18e-3a41-404d-bdb6-d71196699812");
            var mockService = new Mock<IMovieService>();
            mockService.Setup(x => x.DeleteId(It.IsAny<Guid>())).ThrowsAsync(new DbUpdateException());
            var movieController = new MovieController(mockService.Object);

            //act
            var movie = await movieController.Delete(id);

            //assert
            Assert.IsType<NotFoundObjectResult>(movie);
        }
    }
}
