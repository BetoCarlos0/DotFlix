using ApiDotflix.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ApiDotflixTest.ControllerTests
{
    public class KeywordControllerTest
    {
        /*[Fact, Trait("Keyword", "GetLanguage")]
        public async Task GetAllLanguage_Whencalled_ReturnOk()
        {
            //arrange
            var mockService = new Mock<IKeywordService>();
            mockService.Setup(x => x.GetAllAsync());
            var keywordController = new KeywordController(mockService.Object);

            //act
            var lang = await keywordController.GetAllKeywords();

            //assert
            var result = lang.Result;
            Assert.IsType<OkObjectResult>(result);
        }
        
        [Fact, Trait("Keyword", "GetLanguage")]
        public async Task GetLanguageById_WhenCalled_ReturnOk()
        {
            //arrange
            int id = 100;
            var getLang = new Keyword
            {
                KeywordId = id,
                Name = "Português"
            };
            var mockService = new Mock<IKeywordService>();
            mockService.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(getLang);
            var keywordController = new KeywordController(mockService.Object);

            //act
            var lang = await keywordController.GetKeyword(id);

            //assert
            var result = lang.Result;
            var actionValue = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(id, ((Keyword)actionValue.Value).KeywordId);
            Assert.IsType<OkObjectResult>(result);
        }
        
        [Fact, Trait("Keyword", "GetLanguage")]
        public async Task GetLanguageById_WhenCalled_NotFound()
        {
            //arrange
            int id = 102;
            var getLang = new Keyword
            {
                KeywordId = id,
                Name = "Português"
            };
            var mockService = new Mock<IKeywordService>();
            mockService.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ThrowsAsync(new DbUpdateException());
            var keywordController = new KeywordController(mockService.Object);

            //act
            var lang = await keywordController.GetKeyword(id);

            //assert
            var result = lang.Result;
            Assert.IsType<NotFoundObjectResult>(result);
        }
        
        [Fact, Trait("Keyword", "PostLanguage")]
        public async Task CreateLanguage_DuplicateName_ReturnBadRequest()
        {
            //arrange
            var newLang = new Keyword
            {
                Name = "Português"
            };
            var mockService = new Mock<IKeywordService>();
            mockService.Setup(x => x.AddAsync(It.IsAny<Keyword>())).ThrowsAsync(new DbUpdateException());
            var keywordController = new KeywordController(mockService.Object);

            //act
            var result = await keywordController.CreateKeyword(newLang);

            //assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
        
        [Fact, Trait("Keyword", "PostLanguage")]
        public async Task CreateLanguage_WhenCalled_ReturnCreated()
        {
            //arrange
            var newLang = new Keyword
            {
                Name = "teste"
            };
            var mockService = new Mock<IKeywordService>();
            mockService.Setup(x => x.AddAsync(It.IsAny<Keyword>()));
            var keywordController = new KeywordController(mockService.Object);

            //act
            var result = await keywordController.CreateKeyword(newLang);

            //assert
            Assert.IsType<CreatedAtActionResult>(result);
        }
        
        [Fact, Trait("Keyword", "PostLanguage")]
        public async Task CreateLanguage_FieldNull_ReturnBadRequest()
        {
            //arrange
            var newLang = new Keyword
            {
                Name = null
            };
            var mockService = new Mock<IKeywordService>();
            mockService.Setup(x => x.AddAsync(It.IsAny<Keyword>()));

            var keywordController = new KeywordController(mockService.Object);
            keywordController.ModelState.AddModelError("name", "Required");

            //act
            var result = await keywordController.CreateKeyword(newLang);

            //assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
        
        [Fact, Trait("Keyword", "PutLanguage")]
        public async Task UpdateLanguage_WhenCalled_ReturnOk()
        {
            //arrange
            var id = 100;
            var newLang = new Keyword
            {
                KeywordId = 100,
                Name = "teste"
            };
            var mockService = new Mock<IKeywordService>();
            mockService.Setup(x => x.UpdateAsync(It.IsAny<Keyword>()));

            var keywordController = new KeywordController(mockService.Object);

            //act
            var result = await keywordController.UpdateKeyword(id, newLang);

            //assert
            Assert.IsType<OkObjectResult>(result);
        }
        
        [Fact, Trait("Keyword", "PutLanguage")]
        public async Task UpdateLanguage_CompareId_ReturnBadRequest()
        {
            //arrange
            var id = 100;
            var newLang = new Keyword
            {
                KeywordId = 103,
                Name = "teste"
            };
            var mockService = new Mock<IKeywordService>();
            mockService.Setup(x => x.UpdateAsync(It.IsAny<Keyword>()));
            var keywordController = new KeywordController(mockService.Object);

            //act
            var result = await keywordController.UpdateKeyword(id, newLang);

            //assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact, Trait("Keyword", "PutLanguage")]
        public async Task UpdateLanguage_DuplicateName_ReturnBadRequest()
        {
            //arrange
            int id = 103;
            var newLang = new Keyword
            {
                KeywordId = 101,
                Name = "Inglês"
            };
            var mockService = new Mock<IKeywordService>();
            mockService.Setup(x => x.UpdateAsync(It.IsAny<Keyword>())).ThrowsAsync(new DbUpdateException());

            var keywordController = new KeywordController(mockService.Object);

            //act
            var result = await keywordController.UpdateKeyword(id, newLang);

            //assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact, Trait("Keyword", "PutLanguage")]
        public async Task UpdateLanguage_InvalidId_ReturnBadRequest()
        {
            //arrange
            int id = 100;
            var newLang = new Keyword
            {
                KeywordId = 101,
                Name = "Inglês"
            };
            var mockService = new Mock<IKeywordService>();
            mockService.Setup(x => x.UpdateAsync(It.IsAny<Keyword>())).ThrowsAsync(new DbUpdateException());

            var keywordController = new KeywordController(mockService.Object);

            //act
            var result = await keywordController.UpdateKeyword(id, newLang);

            //assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact, Trait("Keyword", "DeleteLanguage")]
        public async Task DeleteLanguage_InvalidId_ReturnBadRequest()
        {
            //arrange
            int id = 103;

            var mockService = new Mock<IKeywordService>();
            mockService.Setup(x => x.DeleteId(It.IsAny<int>())).ThrowsAsync(new DbUpdateException());

            var keywordController = new KeywordController(mockService.Object);

            //act
            var result = await keywordController.Delete(id);

            //assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact, Trait("Keyword", "DeleteLanguage")]
        public async Task DeleteLanguage_WhenCalled_ReturnOk()
        {
            //arrange
            int id = 100;

            var mockService = new Mock<IKeywordService>();
            mockService.Setup(x => x.DeleteId(It.IsAny<int>())).ReturnsAsync(true);

            var keywordController = new KeywordController(mockService.Object);

            //act
            var result = await keywordController.Delete(id);

            //assert
            Assert.IsType<OkObjectResult>(result);
        }*/
    }
}
