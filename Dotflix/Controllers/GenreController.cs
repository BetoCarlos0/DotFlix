using ApiDotflix.Entities;
using ApiDotflix.Entities.Models.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiDotflix.Controllers
{
    [Route("api/genres")]
    [ApiController]
    public class GenreController : BaseController<Genre>
    {
        public GenreController(IBaseRepository<Genre> genreRepository) : base(genreRepository)
        {
        }
    }
}
