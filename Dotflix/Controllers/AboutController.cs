using ApiDotflix.Entities.Models.Contracts.Services;
using ApiDotflix.Entities.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ApiDotflix.Controllers
{
    [Route("api/abouts")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("get/{id}")]
        public async Task<ActionResult<AboutOutputDto>> GetAbout(int id)
        {
            try
            {
                return Ok(await _aboutService.GetByIdAsync(id));
            }
            catch (DbUpdateException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao recuperar dados do banco de dados");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("put")]
        public async Task<IActionResult> UpdateAbout(AboutInputDto about)
        {
            if (!ModelState.IsValid) return BadRequest(new ValidationProblemDetails(ModelState));

            try
            {
                return Ok(await _aboutService.UpdateAsync(about).ConfigureAwait(false));
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao recuperar dados do banco de dados");
            }
        }
    }
}
