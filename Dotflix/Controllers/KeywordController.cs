using ApiDotflix.Entities;
using ApiDotflix.Entities.Models.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiDotflix.Controllers
{
    [Route("api/keywords")]
    [ApiController]
    public class KeywordController : BaseController<Keyword>
    {
        public KeywordController(IBaseRepository<Keyword> baseRepository) : base(baseRepository)
        {
        }
    }
}
