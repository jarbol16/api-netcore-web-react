using Aranda.ComponenteAutorizacion.Entities;
using BusinessRules;
using BusinessRules.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Utilities;

namespace Aranda.ComponenteAutorizacion.Api.Controllers
{
    [Route("api/Person")]
    [ApiController]
    public class PersonController : ExceptionControl
    {
        private readonly IPersonBusiness personBusiness;
        public PersonController(IPersonBusiness personBusiness)
        {
            this.personBusiness = personBusiness;
        }

        [HttpGet("GetPersons")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Persona>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseApi))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseApi))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(ResponseApi))]
        public IActionResult GetPersons([FromQuery]string userName)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                return ExceptionBehavior(() => ResultApi(this.personBusiness.GetPersons(userName)));
            }
            else
            {
                return NotFound();
            }

        }
    }
}
