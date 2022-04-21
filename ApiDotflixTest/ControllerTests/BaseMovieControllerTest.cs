using Dotflix.Controllers;
using Dotflix.Models;
using Dotflix.Models.Contracts.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDotflixTest.ControllerTests
{
    public abstract class BaseMovieControllerTest
    {
        protected readonly List<Movie> _movies;
        protected readonly Mock<IMovieService> _mockService;
        protected readonly MovieController _movieController; 

        public BaseMovieControllerTest(List<Movie> movies)
        {
            _movies = movies;
            _mockService = new Mock<IMovieService>();
            _mockService.Setup(x => x.GetAllAsync()).ReturnsAsync(movies);
            _movieController = new MovieController(_mockService.Object);
        }
    }
}
