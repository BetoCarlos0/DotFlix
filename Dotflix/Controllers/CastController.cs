using ApiDotflix.Data;
using ApiDotflix.Entities;
using ApiDotflix.Entities.Models.Contracts.Repositories;
using ApiDotflix.Entities.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDotflix.Controllers
{
    [Route("api/casts")]
    [ApiController]
    public class CastController : BaseController<Cast>
    {
        private readonly DotflixDbContext _dbContext;
        public CastController(DotflixDbContext dbContext, IBaseRepository<Cast> baseRepository) : base(baseRepository)
        {
            _dbContext = dbContext;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("get/related/{id}")]
        public async Task<ActionResult<MovieOutputDto>> GetAllRelatedMovie(int id)
        {
            var getMovie = await (from movie in _dbContext.Movie
                              join about in _dbContext.About on movie.MovieId equals about.MovieId
                              join aboutCast in _dbContext.AboutCast on about.AboutId equals aboutCast.AboutId
                            where (aboutCast.CastId == id)
                              select movie
                              ).ToListAsync();

            return Ok(Mapping.MappingMovieOutput(getMovie));
        }
    }
}
