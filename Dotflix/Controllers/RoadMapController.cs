using ApiDotflix.Entities;
using ApiDotflix.Entities.Models.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiDotflix.Controllers
{
    [Route("api/roadmaps")]
    [ApiController]
    public class RoadMapController : BaseController<RoadMap>
    {
        public RoadMapController(IBaseRepository<RoadMap> baseRepository) : base(baseRepository)
        {
        }
    }
}
