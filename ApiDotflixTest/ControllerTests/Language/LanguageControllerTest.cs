using Dotflix.Controllers;
using Dotflix.Models;
using Dotflix.Models.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ApiDotflixTest.ControllerTests
{
    public class LanguageControllerTest
    {
        [Fact, Trait("Language", "GetLanguage")]
        public async Task GetAllLanguage_Whencalled_ReturnOk()
        {
            //arrange
            var mockService = new Mock<ILanguageService>();
            mockService.Setup(x => x.GetAllAsync());
            var languageController = new LanguageController(mockService.Object);

            //act
            var lang = await languageController.GetAllLanguages();

            //assert
            var result = lang.Result;
            Assert.IsType<OkObjectResult>(result);
        }
        
        [Fact, Trait("Language", "GetLanguage")]
        public async Task GetLanguageById_WhenCalled_ReturnOk()
        {
            //arrange
            Guid id = new Guid("c9db8681-a670-4750-a839-f75f9e85d0f5");
            var getLang = new Language
            {
                LanguageId = id,
                Name = "Português"
            };
            var mockService = new Mock<ILanguageService>();
            mockService.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(getLang);
            var languageController = new LanguageController(mockService.Object);

            //act
            var lang = await languageController.GetLanguage(id);

            //assert
            var result = lang.Result;
            var actionValue = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(id, ((Language)actionValue.Value).LanguageId);
            Assert.IsType<OkObjectResult>(result);
        }
        
        [Fact, Trait("Language", "GetLanguage")]
        public async Task GetLanguageById_WhenCalled_NotFound()
        {
            //arrange
            Guid id = new Guid("c9db8681-a670-4750-a839-f75f9e85d0f4");
            var getLang = new Language
            {
                LanguageId = id,
                Name = "Português"
            };
            var mockService = new Mock<ILanguageService>();
            mockService.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ThrowsAsync(new DbUpdateException());
            var languageController = new LanguageController(mockService.Object);

            //act
            var lang = await languageController.GetLanguage(id);

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
                Name = "Português"
            };
            var mockService = new Mock<ILanguageService>();
            mockService.Setup(x => x.AddAsync(It.IsAny<Language>())).ThrowsAsync(new DbUpdateException());
            var languageController = new LanguageController(mockService.Object);

            //act
            var result = await languageController.CreateLanguage(newLang);

            //assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
        
        [Fact, Trait("Language", "PostLanguage")]
        public async Task CreateLanguage_WhenCalled_ReturnCreated()
        {
            //arrange
            var newLang = new Language
            {
                Name = "teste"
            };
            var mockService = new Mock<ILanguageService>();
            mockService.Setup(x => x.AddAsync(It.IsAny<Language>()));
            var languageController = new LanguageController(mockService.Object);

            //act
            var result = await languageController.CreateLanguage(newLang);

            //assert
            Assert.IsType<CreatedAtActionResult>(result);
        }
        
        [Fact, Trait("language", "PostLanguage")]
        public async Task CreateLanguage_FieldNull_ReturnBadRequest()
        {
            //arrange
            var newLang = new Language
            {
                Name = null
            };
            var mockService = new Mock<ILanguageService>();
            mockService.Setup(x => x.AddAsync(It.IsAny<Language>()));

            var languageController = new LanguageController(mockService.Object);
            languageController.ModelState.AddModelError("name", "Required");

            //act
            var result = await languageController.CreateLanguage(newLang);

            //assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
        
        [Fact, Trait("Language", "PutLanguage")]
        public async Task UpdateLanguage_WhenCalled_ReturnOk()
        {
            //arrange
            var id = new Guid("ed4ddfd9-24d7-44e6-807f-6aceaf071146");
            var newLang = new Language
            {
                LanguageId = new Guid("ed4ddfd9-24d7-44e6-807f-6aceaf071146"),
                Name = "teste"
            };
            var mockService = new Mock<ILanguageService>();
            mockService.Setup(x => x.UpdateAsync(It.IsAny<Language>()));

            var languageController = new LanguageController(mockService.Object);

            //act
            var result = await languageController.UpdateLanguage(id, newLang);

            //assert
            Assert.IsType<OkObjectResult>(result);
        }
        
        [Fact, Trait("Language", "PutLanguage")]
        public async Task UpdateLanguage_CompareId_ReturnBadRequest()
        {
            //arrange
            var id = new Guid("ed4ddfd9-24d7-44e6-807f-6aceaf071146");
            var newLang = new Language
            {
                LanguageId = new Guid("866e8eab-296e-4d82-b877-8ff96a5209c6"),
                Name = "teste"
            };
            var mockService = new Mock<ILanguageService>();
            mockService.Setup(x => x.UpdateAsync(It.IsAny<Language>()));
            var languageController = new LanguageController(mockService.Object);

            //act
            var result = await languageController.UpdateLanguage(id, newLang);

            //assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact, Trait("Language", "PutLanguage")]
        public async Task UpdateLanguage_DuplicateName_ReturnBadRequest()
        {
            //arrange
            var id = new Guid("c9db8681-a670-4750-a839-f75f9e85d0f5");
            var newLang = new Language
            {
                LanguageId = new Guid("c9db8681-a670-4750-a839-f75f9e85d0f5"),
                Name = "Inglês"
            };
            var mockService = new Mock<ILanguageService>();
            mockService.Setup(x => x.UpdateAsync(It.IsAny<Language>())).ThrowsAsync(new DbUpdateException());

            var languageController = new LanguageController(mockService.Object);

            //act
            var result = await languageController.UpdateLanguage(id, newLang);

            //assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact, Trait("Language", "PutLanguage")]
        public async Task UpdateLanguage_InvalidId_ReturnBadRequest()
        {
            //arrange
            Guid id = new Guid("ed4ddfd9-24d7-44e6-807f-6aceaf071146");
            var newLang = new Language
            {
                LanguageId = new Guid("ed4ddfd9-24d7-44e6-807f-6aceaf071146"),
                Name = "Inglês"
            };
            var mockService = new Mock<ILanguageService>();
            mockService.Setup(x => x.UpdateAsync(It.IsAny<Language>())).ThrowsAsync(new DbUpdateException());

            var languageController = new LanguageController(mockService.Object);

            //act
            var result = await languageController.UpdateLanguage(id, newLang);

            //assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact, Trait("Language", "DeleteLanguage")]
        public async Task DeleteLanguage_InvalidId_ReturnBadRequest()
        {
            //arrange
            var id = new Guid("ed4ddfd9-24d7-44e6-807f-6aceaf071146");

            var mockService = new Mock<ILanguageService>();
            mockService.Setup(x => x.DeleteId(It.IsAny<Guid>())).ThrowsAsync(new DbUpdateException());

            var languageController = new LanguageController(mockService.Object);

            //act
            var result = await languageController.Delete(id);

            //assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact, Trait("Language", "DeleteLanguage")]
        public async Task DeleteLanguage_WhenCalled_ReturnOk()
        {
            //arrange
            var id = new Guid("c9db8681-a670-4750-a839-f75f9e85d0f5");

            var mockService = new Mock<ILanguageService>();
            mockService.Setup(x => x.DeleteId(It.IsAny<Guid>())).ReturnsAsync(true);

            var languageController = new LanguageController(mockService.Object);

            //act
            var result = await languageController.Delete(id);

            //assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
