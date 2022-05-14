using ApiDotflix.Models;
using ApiDotflix.Models.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ApiDotflix.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class KeywordController : Controller
    {
        private readonly IKeywordService _keywordService;

        public KeywordController(IKeywordService keywordService)
        {
            _keywordService = keywordService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<Keyword>> GetAllKeywords()
        {
            return Ok(await _keywordService.GetAllAsync());
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Keyword>> GetKeyword(int id)
        {
            try
            {
                return Ok(await _keywordService.GetByIdAsync(id));
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

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateKeyword(Keyword keyword)
        {
            if (!ModelState.IsValid) return BadRequest(new ValidationProblemDetails(ModelState));

            try
            {
                await _keywordService.AddAsync(keyword).ConfigureAwait(false);

                return CreatedAtAction(nameof(GetKeyword),
                    new { id = keyword.KeywordId}, keyword);
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

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKeyword(int id, Keyword keyword)
        {
            if (!ModelState.IsValid) return BadRequest(new ValidationProblemDetails(ModelState));

            if (id != keyword.KeywordId)
                return BadRequest("Id e Idioma incompatíveis");

            try
            {
                return Ok(await _keywordService.UpdateAsync(keyword));
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

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                return Ok(await _keywordService.DeleteId(id));
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
    }
}
