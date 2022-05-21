using ApiDotflix.Data;
using ApiDotflix.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ApiDotflix.Controllers
{
    [Route("api/languages")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly DotflixDbContext _dbContext;

        public LanguageController(DotflixDbContext dotflixDbContext)
        {
            _dbContext = dotflixDbContext;
        }

        [HttpGet("get")]
        public async Task<ActionResult<Language>> GetAllLanguages()
        {
            return Ok(await _dbContext.Language.AsNoTracking().ToListAsync());
        }
    }
}
