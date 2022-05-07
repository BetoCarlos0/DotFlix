using ApiDotflixTest.ControllerTests;
using Dotflix.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiDotflixTest.ControllerTests
{
    public class LanguageControllerTest : BaseLanguageControllerTest
    {
        private static readonly List<Language> _lang = new List<Language>()
        {
            new Language
            {
                LanguageId = new Guid("a6e7fc8b-b836-4c14-b804-38f60152542f"),
                Name = "Portugês"
            },
            new Language
            {
                LanguageId = new Guid("d78610d4-5041-4b8a-bb70-6f605b7a141d"),
                Name = "Inglês"
            }
        };

        [Fact, Trait("Language", "GetLanguage")]
        public async Task GetAllLanguage_Whencalled_ReturnOk()
        {
            //arrange act
            //var lang = await _languageController.GetAllLanguages();

            //assert
            var result = lang.Result;
            Assert.IsType<OkObjectResult>(result);
        }
        
        [Fact, Trait("Language", "GetLanguage")]
        public async Task GetLanguageById_WhenCalled_ReturnOk()
        {
            //arrange
            Guid id = new Guid("a6e7fc8b-b836-4c14-b804-38f60152542f");
            var getLang = _lang.FirstOrDefault(x => x.LanguageId == id);
            _mockService.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(getLang);

            //act
            var lang = await _languageController.GetLanguage(id);

            //assert
            var result = lang.Result;
            var actionValue = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(id, ((Language)actionValue.Value).LanguageId);
            Assert.IsType<OkObjectResult>(result);
        }
        
        [Fact, Trait("Language", "GetLanguage")]
        public async Task GetLanguageById_WhenCalled_ReturnNotFound()
        {
            //arrange
            Guid id = new Guid("dd376a06-e466-4596-9769-ddcc5fe14664");
            var getLang = _lang.FirstOrDefault(x => x.LanguageId == id);
            _mockService.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(getLang);

            //act
            var lang = await _languageController.GetLanguage(id);

            //assert
            var result = lang.Result;
            Assert.IsType<NotFoundObjectResult>(result);
        }
        
        [Fact, Trait("Language", "PostLanguage")]
        public async Task CreateLanguage_DuplicateName_ReturnBadRequest()
        {
            //arrange
            var newLang = new Language
            {
                LanguageId = new Guid("c9db8681-a670-4750-a839-f75f9e85d0f5"),
                Name = "Portugês"
            };
            _mockService.Setup(x => x.AddAsync(newLang)).ReturnsAsync(newLang);

            //act
            var movie = await _languageController.CreateLanguage(newLang);

            //assert
            var result = movie.Result;
            Assert.IsType<BadRequestObjectResult>(result);
        }
        /*
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
        }*/
    }
}
