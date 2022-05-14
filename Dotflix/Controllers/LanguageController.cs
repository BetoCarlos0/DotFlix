using ApiDotflix.Models;
using ApiDotflix.Models.Contracts.Services;
using ApiDotflix.Models.Enum;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ApiDotflix.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        [HttpGet]
        public ActionResult<Languages> GetAllIdiomas()
        {
            List<EnumValue> values = new List<EnumValue>();
            foreach (var itemType in Enum.GetValues(typeof(Languages)))
            {
                values.Add(new EnumValue()
                {
                    Name = Enum.GetName(typeof(Languages), itemType),
                    Value = (int)itemType
                });
            }
            return Ok(values);
        }
    }
}
