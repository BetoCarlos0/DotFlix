using Dotflix.Models;
using Dotflix.Models.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Dotflix.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageService _languageService;

        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<Language>> GetAllLanguages()
        {
            return Ok(await _languageService.GetAllAsync());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Language>> GetLanguage(Guid id)
        {
            var getLanguage = await _languageService.GetByIdAsync(id);

            if (getLanguage == null) return NotFound($"404 - Idioma com Id {id} não encontrado");

            return Ok(getLanguage);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult<Language>> CreateLanguage(Language language)
        {
            if (!ModelState.IsValid) return BadRequest(new ValidationProblemDetails(ModelState));

            try
            {
                var result = await _languageService.AddAsync(language).ConfigureAwait(false);

                if (result.Name == language.Name && result.LanguageId != language.LanguageId)
                    return BadRequest($"400 - Idioma {result.Name} Já existente");

                return CreatedAtAction(nameof(GetLanguage),
                    new { id = language.LanguageId}, language);
            }
            catch (DbUpdateException)
            {
                return BadRequest(new ValidationProblemDetails(ModelState));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao recuperar dados do banco de dados");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public async Task<ActionResult<Language>> UpdateLanguage(Guid id, Language language)
        {
            if (!ModelState.IsValid) return BadRequest(new ValidationProblemDetails(ModelState));

            if (id != language.LanguageId)
                return BadRequest("400 - Id e Idioma incompatíveis");

            try
            {
                return Ok(await _languageService.UpdateAsync(language));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao recuperar dados do banco de dados");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var result = await _languageService.DeleteId(id);

                if (result == false) return BadRequest();

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao recuperar dados do banco de dados");
            }
        }
    }
}
