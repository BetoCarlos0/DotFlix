using ApiDotflix.Data;
using ApiDotflix.Entities;
using ApiDotflix.Entities.Models.Contracts.Repositories;
using ApiDotflix.Entities.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ApiDotflix.Controllers
{
    [Route("api/directors")]
    [ApiController]
    public class DirectorController : BaseController<Director>
    {
        private readonly DotflixDbContext _dbContext;
        public DirectorController(DotflixDbContext dbContext, IBaseRepository<Director> baseRepository) : base(baseRepository)
        {
            _dbContext = dbContext;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("get/related/{id}")]
        public async Task<ActionResult<MovieOutputDto>> GetAllRelatedMovie(int id)
        {
            var getMovie = await (from movie in _dbContext.Movie
                                  join about in _dbContext.About on movie.MovieId equals about.MovieId
                                  where (about.DirectorId == id)
                                  select movie
                              ).ToListAsync();

            return Ok(Mapping.MappingMovieOutput(getMovie));
        }
    }
}
