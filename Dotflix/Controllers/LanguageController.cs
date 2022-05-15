﻿using ApiDotflix.Data;
using ApiDotflix.Models;
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

        [HttpGet]
        public async Task<ActionResult<Language>> GetAllLanguages()
        {
            return Ok(await _dbContext.Language.AsNoTracking().ToListAsync());
        }
    }
}
