using Dotflix.Models;
using Dotflix.Models.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Dotflix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        
        [HttpGet]
        public async Task<ActionResult<Movie>> GetAllMovies()
        {
            try
            {
                var AllMovie = await _movieService.GetAllAsync();
                if (AllMovie == null) return NotFound();

                return Ok(AllMovie);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao recuperar dados do banco de dados");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            try
            {
                var result = await _movieService.GetByIdAsync(id);
                if (result == null) return NotFound();
                
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao recuperar dados do banco de dados");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> CreateMovie(Movie movie)
        {
            try
            {
                if (movie == null) return BadRequest();

                var result = await _movieService.AddAsync(movie);

                return CreatedAtAction(nameof(GetMovie),
                    new { id = movie.MovieId}, result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao recuperar dados do banco de dados");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Movie>> UpdateMovie(int id, Movie movie)
        {
            try
            {
                if (id != movie.MovieId)
                    return BadRequest("Id e Filme incompatíveis");

                var result = _movieService.GetByIdAsync(id);

                if(result == null)
                    return NotFound($"Filme com Id {id} não encontrado");

                return await _movieService.UpdateAsync(movie);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao recuperar dados do banco de dados");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Movie>> Delete(int id)
        {
            try
            {
                var result = await _movieService.GetByIdAsync(id);

                if (result == null)
                    return NotFound($"Filme com Id {id} não encontrado");

                return await _movieService.DeleteId(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao recuperar dados do banco de dados");
            }
        }
    }
}
