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
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageService _languageService;

        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        [HttpGet]
        public async Task<ActionResult<LanguageViewOutput>> GetAllLanguages()
        {
            try
            {
                var AllLanguage = await _languageService.GetAllAsync();
                if (AllLanguage == null) return NotFound();

                return Ok(AllLanguage);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao recuperar dados do banco de dados");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Language>> GetLanguage(int id)
        {
            try
            {
                var getLanguage = await _languageService.GetByIdAsync(id);
                if (getLanguage == null) return NotFound();

                return Ok(getLanguage);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao recuperar dados do banco de dados");
            }
        }

        [HttpPost]
        public async Task<ActionResult<LanguageViewOutput>> CreateLanguage(Language language)
        {
            try
            {
                if (language == null) return BadRequest();

                var result = await _languageService.AddAsync(language);

                return CreatedAtAction(nameof(GetLanguage),
                    new { id = language.LanguageId}, result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao recuperar dados do banco de dados");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Language>> UpdateLanguage(int id, Language language)
        {
            try
            {
                if (id != language.LanguageId)
                    return BadRequest("Id e Linguagem incompatíveis");

                var result = await _languageService.GetByIdAsync(id);

                if (result == null)
                    return NotFound($"Linguagem com Id {id} não encontrado");

                return await _languageService.UpdateAsync(language);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao recuperar dados do banco de dados");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Language>> Delete(int id)
        {
            try
            {
                var result = await _languageService.GetByIdAsync(id);

                if (result == null)
                    return NotFound($"Linguagem com Id {id} não encontrado");

                return await _languageService.DeleteId(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao recuperar dados do banco de dados");
            }
        }
    }
}
