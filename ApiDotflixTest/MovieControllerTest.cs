using Dotflix.Controllers;
using Dotflix.Models;
using Dotflix.Models.Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiDotflixTest
{
    public class MovieControllerTest
    {
        MovieController _controller;
        IMovieService _service;
        public MovieControllerTest()
        {
            _service = new MovieServiceFake();
            _controller = new MovieController(_service);
        }

        [Fact]
        public async Task GetMovie_Whencalled_ReturnOk()
        {
            //act
            var ReturnOk = await _controller.GetAllMovies();

            //acert
            Assert.IsType<OkObjectResult>(ReturnOk.Result);
        }
    }
}
