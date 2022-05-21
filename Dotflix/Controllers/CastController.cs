using ApiDotflix.Entities;
using ApiDotflix.Entities.Models.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiDotflix.Controllers
{
    [Route("api/casts")]
    [ApiController]
    public class CastController : BaseController<Cast>
    {
        public CastController(IBaseRepository<Cast> baseRepository) : base(baseRepository)
        { }
    }
}
