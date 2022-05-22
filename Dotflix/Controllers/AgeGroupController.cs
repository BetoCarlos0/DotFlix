using ApiDotflix.Data;
using ApiDotflix.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiDotflix.Controllers
{
    [Route("api/agegroup")]
    [ApiController]
    public class AgeGroupController : ControllerBase
    {
        [HttpGet("get")]
        public ActionResult<AgeGroup> GetAll()
        {
            var ageGroup = new List<AgeGroup>()
            {
                new AgeGroup("L", "Livre", "Não expõe crianças a conteúdo potencialmente prejudiciais"),
                new AgeGroup("10", "Não recomendado para menores de 10 anos",
                            "Conteúdo violento ou linguagem inapropírada para crianças"),
                new AgeGroup("12", "Não recomendado para menores de 12 anos",
                            "Cenas podem conter agressão física, consumo de drogas e insinuação sexual"),
                new AgeGroup("14", "Não recomendado para menores de 14 anos",
                            "Conteúdos mais violentos e/ou de linguagem sexual mais acentuada"),
                new AgeGroup("16", "Não recomendado para menores de 16 anos",
                            "Conteúdo mais violentos, com cenas de tortura, suicídio, estupro ou nudez total"),
                new AgeGroup("18", "Não recomendado para menores de 18 anos",
                            "Conteúdos violentos e sexuais extremos. Cenas de sexo, incesto ou atos repetidos de tortura, multilação ou abuso sexual")
            };

            return Ok(ageGroup);
        }
    }
}
