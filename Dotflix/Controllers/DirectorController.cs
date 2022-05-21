using ApiDotflix.Entities;
using ApiDotflix.Entities.Models.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiDotflix.Controllers
{
    [Route("api/directors")]
    [ApiController]
    public class DirectorController : BaseController<Director>
    {
        public DirectorController(IBaseRepository<Director> baseRepository) : base(baseRepository)
        {
        }
    }
}
