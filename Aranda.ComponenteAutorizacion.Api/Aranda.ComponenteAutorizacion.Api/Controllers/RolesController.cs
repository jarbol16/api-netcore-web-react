using Aranda.ComponenteAutorizacion.Entities;
using BusinessRules;
using BusinessRules.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Utilities;

namespace Aranda.ComponenteAutorizacion.Api.Controllers
{
    [Route("api/Roles")]
    [ApiController]
    public class RolesController : ExceptionControl
    {
        private readonly IRolesBusiness rolesBusiness;
        public RolesController(IRolesBusiness rolesBusiness)
        {
            this.rolesBusiness = rolesBusiness;
        }

        [HttpGet("GetRoles")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Rol>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseApi))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseApi))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(ResponseApi))]
        public IActionResult GetRoles()
        {
             return ExceptionBehavior(() => ResultApi(this.rolesBusiness.GetProfiles()));
        }

        [HttpGet("GetPermisions")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Rol>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseApi))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseApi))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(ResponseApi))]
        public IActionResult GetPermisions()
        {
            return ExceptionBehavior(() => ResultApi(this.rolesBusiness.GetPermisions()));
        }
    }
}
