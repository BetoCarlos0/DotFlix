using ApiDotflix.Controllers;
using ApiDotflix.Data.Services;
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
        /*[Fact, Trait("Movie", "GetMovie")]
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
            int id = 100;
            
            var mockService = new Mock<IMovieService>();
            mockService.Setup(x => x.GetByIdAsync(It.IsAny<int>()));
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
            int id = 102;

            var mockService = new Mock<IMovieService>();
            mockService.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ThrowsAsync(new DbUpdateException());
            var movieController = new MovieController(mockService.Object);

            //act
            var movie = await movieController.GetMovie(id);

            //assert
            var result = movie.Result;
            Assert.IsType<NotFoundObjectResult>(result);
        }
        /*
        [Fact, Trait("Movie", "CreateMovie")]
        public async Task CreateMovie_DuplicateTitle_ReturnBadRequest()
        {
            //arrange
            var newMovie = new Movie
            {
                MovieId = 100,
                Title = "um filme",
                Sinopse = "um filme de teste",
                Image = "imgTeste",
                AgeGroup = "14",
                ReleaseData = new DateTime(2010, 2, 20).Date.ToString("dd/MM/yyyy"),
                Relevance = 10,
                RunTime = new DateTime(2021, 5, 10, 02, 20, 30).ToString("H:mm:ss"),
                MovieLanguages = new List<MovieLanguage>()
                {
                    new MovieLanguage()
                    {
                        LanguageId = 100
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
                MovieId = 100,
                Title = "novo filme",
                Sinopse = "um filme de teste",
                Image = "imgTeste",
                AgeGroup = "14",
                ReleaseData = new DateTime(2010, 2, 20).ToString("dd/MM/yyyy"),
                Relevance = 10,
                RunTime = new DateTime(2021, 5, 10, 15, 20, 20).ToString("H:mm:ss"),
                MovieLanguages = new List<MovieLanguage>()
                {
                    new MovieLanguage()
                    {
                        LanguageId = 100
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
                MovieId = 100,
                Title = null,
                Sinopse = "um filme de teste",
                AgeGroup = "14",
                ReleaseData = new DateTime(2010, 2, 20).ToString("dd/MM/yyyy"),
                Relevance = 10,
                RunTime = new DateTime(2021, 5, 10, 15, 20, 20).ToString("H:mm:ss"),
                MovieLanguages = new List<MovieLanguage>()
                {
                    new MovieLanguage()
                    {
                        LanguageId = 100
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
            int id = 100;
            var updateMovie = new Movie
            {
                MovieId = id,
                AgeGroup = "0",
                Image = "img2",
                ReleaseData = new DateTime(2021, 5, 10).ToString("dd/MM/yyyy"),
                RunTime = new DateTime(2021, 5, 10, 15, 20, 20).ToString("H:mm:ss"),
                Sinopse = "uma sinopse",
                Title = "um filme",
                Relevance = 45,
                Languages = new List<Language1>()
                {
                    new Language1()
                    {
                        LanguageId = 100
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
            int id = 100;
            var updateMovie = new Movie
            {
                MovieId = 102,
                AgeGroup = "0",
                Image = "img2",
                ReleaseData = new DateTime(2021, 5, 10).ToString("dd/MM/yyyy"),
                RunTime = new DateTime(2021, 5, 10, 15, 20, 20).ToString("H:mm:ss"),
                Sinopse = "uma sinopse",
                Title = "um filme",
                Relevance = 45,
                Languages = new List<Language1>()
                {
                    new Language1()
                    {
                        LanguageId = 100
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
            int id = 100;
            var updateMovie = new Movie
            {
                MovieId = 100,
                Title = "outro filme",
                AgeGroup = "0",
                Image = "img2",
                ReleaseData = new DateTime(2021, 5, 10).ToString("dd/MM/yyyy"),
                RunTime = new DateTime(2021, 5, 10, 15, 20, 20).ToString("H:mm:ss"),
                Sinopse = "uma sinopse",
                Relevance = 45,
                Languages = new List<Language1>()
                {
                    new Language1()
                    {
                        LanguageId = 100
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
            int id = 100;
            var mockService = new Mock<IMovieService>();
            mockService.Setup(x => x.DeleteId(It.IsAny<int>()));
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
            int id = 102;
            var mockService = new Mock<IMovieService>();
            mockService.Setup(x => x.DeleteId(It.IsAny<int>())).ThrowsAsync(new DbUpdateException());
            var movieController = new MovieController(mockService.Object);

            //act
            var movie = await movieController.Delete(id);

            //assert
            Assert.IsType<NotFoundObjectResult>(movie);
        }*/
    }
}
