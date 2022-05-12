using Dotflix.Data.Services;
using Dotflix.Models;
using Dotflix.Models.Contracts;
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
    public class LanguageServiceTest
    {/*
        [Fact]
        public async Task CreateLanguage_WhenCalled_ReturnBadRquest()
        {
            //arrange
            var newLang = new Language
            {
                LanguageId = new Guid("c9db8681-a670-4750-a839-f75f9e85d0f4"),
                Name = "Português"
            };
            var mockRepo = new Mock<ILanguageRepository>();
            var getLang = mockRepo.Setup(x => x.GetByNameAsync(It.IsAny<string>()));
            mockRepo.Setup(x => x.AddAsync(It.IsAny<Language>()));

            var langController = new LanguageService(mockRepo.Object);

            //act
            var result = await langController.AddAsync(newLang);

            //assert
            Assert.IsType<BadRequestObjectResult>(result);
        }*/
    }
}
