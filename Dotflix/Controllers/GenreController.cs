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
    [Route("api/genres")]
    [ApiController]
    public class GenreController : BaseController<Genre>
    {
        private readonly DotflixDbContext _dbContext;
        public GenreController(DotflixDbContext dbContext, IBaseRepository<Genre> baseRepository) : base(baseRepository)
        {
            _dbContext = dbContext;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("get/related/{id}")]
        public async Task<ActionResult<MovieOutputDto>> GetAllRelatedMovie(int id)
        {
            var getMovie = await (from movie in _dbContext.Movie
                                  join about in _dbContext.About on movie.MovieId equals about.MovieId
                                  join mtm in _dbContext.AboutGenre on about.AboutId equals mtm.AboutId
                                  where (mtm.GenreId == id)
                                  select movie
                              ).ToListAsync();

            return Ok(Mapping.MappingMovieOutput(getMovie));
        }
    }
}
