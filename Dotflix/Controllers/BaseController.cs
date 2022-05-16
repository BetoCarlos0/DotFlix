using ApiDotflix.Entities.Models.Contracts.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using ApiDotflix.Entities.Models.Contracts.Repositories;
using ApiDotflix.Entities;

namespace ApiDotflix.Controllers
{
    /*public abstract class BaseController<T, TRepository> : ControllerBase where T : class where TRepository : IBaseRepository<T>
    {
        private readonly TRepository _baseRepository;

        protected BaseController(TRepository baseService)
        {
            _baseRepository = baseService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<T>> GetAllAsync()
        {
            return Ok(await _baseRepository.GetAllAsync());
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<T>> GetByIdAsync(int id)
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
        [HttpPost]
        public async Task<IActionResult> CreateAsync(T entity)
        {
            if (!ModelState.IsValid) return BadRequest(new ValidationProblemDetails(ModelState));

            try
            {
                return await _baseRepository.AddAsync(entity).ConfigureAwait(false);

                //return CreatedAtAction("GetByIdAsync", new { id = entity.Id }, entity);
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
        [HttpDelete("{id}")]
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
    }*/
}
