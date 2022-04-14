using Dotflix.Models;
using Dotflix.Models.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        public async Task<ActionResult<IEnumerable<MovieOutput>>> GetAllMovies()
        {
            return Ok(await _movieService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieOutput>> GetMovie(int id)
        {
            var result = await _movieService.GetByIdAsync(id);

            if (result == null) return NotFound();
                
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> CreateMovie(Movie movie)
        {
            if (movie == null) return BadRequest();
            try
            {
                await _movieService.AddAsync(movie);

                return CreatedAtAction(nameof(GetMovie),
                    new { id = movie.MovieId}, movie);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Movie>> UpdateMovie(int id, Movie movie)
        {
            if (id != movie.MovieId)
                return BadRequest("Id e Filme incompatíveis");

            var result = await _movieService.GetByIdAsync(id);

            if(result == null)
                return NotFound($"Filme com Id {id} não encontrado");

            try
            {
                return await _movieService.UpdateAsync(movie);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
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

                return Ok(await _movieService.DeleteId(id));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
