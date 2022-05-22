using ApiDotflix.Entities.Models;
using ApiDotflix.Entities.Models.Contracts.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ApiDotflix.Controllers
{
    public class BaseController<T> : ControllerBase where T : BaseEntity
    {
        private readonly IBaseRepository<T> _baseRepository;

        public BaseController(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("get")]
        public async Task<ActionResult<T>> GetAllAsync()
        {
            return Ok(await _baseRepository.GetAllAsync());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("get/{id}")]
        public async Task<ActionResult<T>> GetById(int id)
        {
            try
            {
                return Ok(await _baseRepository.GetByIdAsync(id));
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
        [HttpPost("post")]
        public async Task<IActionResult> CreateAsync(T entity)
        {
            if (!ModelState.IsValid) return BadRequest(new ValidationProblemDetails(ModelState));

            try
            {
                await _baseRepository.AddAsync(entity).ConfigureAwait(false);

                return CreatedAtAction(nameof(GetById),
                    new { id = entity.Id }, entity);
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
        [HttpPut("put")]
        public async Task<IActionResult> UpdateAsync(T entity)
        {
            if (!ModelState.IsValid) return BadRequest(new ValidationProblemDetails(ModelState));

            try
            {
                return Ok(await _baseRepository.UpdateAsync(entity));
            }
            catch (DbUpdateException)
            {
                return BadRequest("Erro ao salvar dados, verifique ID");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao recuperar dados do banco de dados");
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                return Ok(await _baseRepository.RemoveByIdAsync(id));
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
