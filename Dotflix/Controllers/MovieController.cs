using Dotflix.Data;
using Dotflix.Models;
using Dotflix.Models.Contracts;
using Dotflix.Models.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Dotflix.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetAllMovies()
        {
            return Ok(await _movieService.GetAllAsync());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(Guid id)
        {
            var result = await _movieService.GetByIdAsync(id);

            if (result == null) return NotFound($"404 - Filme com Id {id} não encontrado");
                
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult> CreateMovie(Movie movie)
        {
            if (!ModelState.IsValid) return BadRequest(new ValidationProblemDetails(ModelState));

            try
            {
                var result = await _movieService.AddAsync(movie).ConfigureAwait(false);

                if (result.Title == movie.Title && result.MovieId != movie.MovieId)
                    return BadRequest($"400 - Filme com Id {result.MovieId} tem o mesmo Título");

                return CreatedAtAction(nameof(GetMovie),
                        new { id = movie.MovieId }, movie);
            }
            catch (DbUpdateException)
            {
                return BadRequest(new ValidationProblemDetails(ModelState));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<ActionResult<Movie>> UpdateMovie(Guid id, Movie movie)
        {
            if (!ModelState.IsValid) return BadRequest(new ValidationProblemDetails(ModelState));

            if (id != movie.MovieId)
                return BadRequest("400 - Id e Filme incompatíveis");

            try
            {
                return Ok(await _movieService.UpdateAsync(movie).ConfigureAwait(false));
            }
            catch (DbUpdateException)
            {
                return BadRequest(new ValidationProblemDetails(ModelState));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var resultType = await _movieService.DeleteId(id).ConfigureAwait(false);

                if (resultType == false) return BadRequest();

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
