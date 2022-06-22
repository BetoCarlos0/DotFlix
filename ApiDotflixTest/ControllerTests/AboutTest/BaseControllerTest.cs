using ApiDotflix.Controllers;
using ApiDotflix.Entities;
using ApiDotflix.Entities.Models.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ApiDotflixTest.ControllerTests
{
    public class BaseControllerTest
    {
        // TESTES COM BASE NA ENTIDADE KEYWORD PARA FINS DE TESTES NAS DEMAIS ENTIDADES (ROADMAP, GENRE, CAST, DIRECTOR)
        // POIS TODOS ERDAM DA MESMA CONTROLLER/REPOSITORY GENÉRICAS

        [Fact, Trait("BaseEntities", "GetEntities")]
        public async Task GetAllLanguage_Whencalled_ReturnOk()
        {
            //arrange
            var mockRepository = new Mock<IBaseRepository<Keyword>>();
            mockRepository.Setup(x => x.GetAllAsync());
            var baseController = new BaseController<Keyword>(mockRepository.Object);

            //act
            var lang = await baseController.GetAllAsync();

            //assert
            var result = lang.Result;
            Assert.IsType<OkObjectResult>(result);
        }
        
        [Fact, Trait("BaseEntities", "GetEntity")]
        public async Task GetLanguageById_WhenCalled_ReturnOk()
        {
            //arrange
            int id = 100;
            var getLang = new Keyword
            {
                Id = id,
                Name = "Português"
            };
            var mockRepository = new Mock<IBaseRepository<Keyword>>();
            mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(getLang);
            var baseController = new BaseController<Keyword>(mockRepository.Object);

            //act
            var lang = await baseController.GetById(id);

            //assert
            var result = lang.Result;
            var actionValue = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(id, ((Keyword)actionValue.Value).Id);
            Assert.IsType<OkObjectResult>(result);
        }
        
        [Fact, Trait("BaseEntities", "GetEntity")]
        public async Task GetLanguageById_WhenCalled_NotFound()
        {
            //arrange
            int id = 102;
            var getLang = new Keyword
            {
                Id = id,
                Name = "Português"
            };
            var mockRepository = new Mock<IBaseRepository<Keyword>>();
            mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ThrowsAsync(new DbUpdateException());
            var baseController = new BaseController<Keyword>(mockRepository.Object);

            //act
            var lang = await baseController.GetById(id);

            //assert
            var result = lang.Result;
            Assert.IsType<NotFoundObjectResult>(result);
        }
        
        [Fact, Trait("BaseEntities", "PostEntity")]
        public async Task CreateLanguage_DuplicateName_ReturnBadRequest()
        {
            //arrange
            var newLang = new Keyword
            {
                Name = "Português"
            };
            var mockRepository = new Mock<IBaseRepository<Keyword>>();
            mockRepository.Setup(x => x.AddAsync(It.IsAny<Keyword>())).ThrowsAsync(new DbUpdateException());
            var baseController = new BaseController<Keyword>(mockRepository.Object);

            //act
            var result = await baseController.CreateAsync(newLang);

            //assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
        
        [Fact, Trait("BaseEntities", "PostEntity")]
        public async Task CreateLanguage_WhenCalled_ReturnCreated()
        {
            //arrange
            var newLang = new Keyword
            {
                Name = "teste"
            };
            var mockRepository = new Mock<IBaseRepository<Keyword>>();
            mockRepository.Setup(x => x.AddAsync(It.IsAny<Keyword>()));
            var keywordController = new BaseController<Keyword>(mockRepository.Object);

            //act
            var result = await keywordController.CreateAsync(newLang);

            //assert
            Assert.IsType<CreatedAtActionResult>(result);
        }
        
        [Fact, Trait("BaseEntities", "PostEntity")]
        public async Task CreateLanguage_FieldNull_ReturnBadRequest()
        {
            //arrange
            var newLang = new Keyword
            {
                Name = null
            };
            var mockRepository = new Mock<IBaseRepository<Keyword>>();
            mockRepository.Setup(x => x.AddAsync(It.IsAny<Keyword>()));

            var keywordController = new BaseController<Keyword>(mockRepository.Object);
            keywordController.ModelState.AddModelError("name", "Required");

            //act
            var result = await keywordController.CreateAsync(newLang);

            //assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
        
        [Fact, Trait("BaseEntities", "PutEntity")]
        public async Task UpdateLanguage_WhenCalled_ReturnOk()
        {
            //arrange
            var newLang = new Keyword
            {
                Id = 100,
                Name = "teste"
            };
            var mockRepository = new Mock<IBaseRepository<Keyword>>();
            mockRepository.Setup(x => x.UpdateAsync(It.IsAny<Keyword>()));

            var baseController = new BaseController<Keyword>(mockRepository.Object);

            //act
            var result = await baseController.UpdateAsync(newLang);

            //assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact, Trait("BaseEntities", "PutEntity")]
        public async Task UpdateLanguage_DuplicateName_ReturnBadRequest()
        {
            //arrange
            var newLang = new Keyword
            {
                Id = 101,
                Name = "Inglês"
            };
            var mockRepository = new Mock<IBaseRepository<Keyword>>();
            mockRepository.Setup(x => x.UpdateAsync(It.IsAny<Keyword>())).ThrowsAsync(new DbUpdateException());

            var keywordController = new BaseController<Keyword>(mockRepository.Object);

            //act
            var result = await keywordController.UpdateAsync(newLang);

            //assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact, Trait("BaseEntities", "DeleteEntity")]
        public async Task DeleteLanguage_InvalidId_ReturnBadRequest()
        {
            //arrange
            int id = 103;

            var mockRepository = new Mock<IBaseRepository<Keyword>>();
            mockRepository.Setup(x => x.RemoveByIdAsync(It.IsAny<int>())).ThrowsAsync(new DbUpdateException());

            var keywordController = new BaseController<Keyword>(mockRepository.Object);

            //act
            var result = await keywordController.Delete(id);

            //assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact, Trait("Keyword", "DeleteEntity")]
        public async Task DeleteLanguage_WhenCalled_ReturnOk()
        {
            //arrange
            int id = 100;

            var mockRepository = new Mock<IBaseRepository<Keyword>>();
            mockRepository.Setup(x => x.RemoveByIdAsync(It.IsAny<int>())).ReturnsAsync(true);

            var keywordController = new BaseController<Keyword>(mockRepository.Object);

            //act
            var result = await keywordController.Delete(id);

            //assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
