using Aranda.ComponenteAutorizacion.Entities;
using BusinessRules;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Utilities;

namespace Aranda.ComponenteAutorizacion.Api.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UserController : ExceptionControl
    {
        private readonly IUserBusiness userBusiness;
        public UserController(IUserBusiness userBusiness)
        {
            this.userBusiness = userBusiness;
        }

        [HttpPost("UserValidate")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Usuario))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseApi))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseApi))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(ResponseApi))]
        public IActionResult UserValidate([FromBody] UserCredentials credentials)
        {
            if (credentials != null)
            {
                return ExceptionBehavior(() => ResultApi(this.userBusiness.ValidateLogin(credentials)));
            }
            else
            {
                return NotFound();
            }
           
        }

        [HttpPost("Users")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Usuario>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseApi))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseApi))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(ResponseApi))]
        public IActionResult GetUsers(string userName)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                return ExceptionBehavior(() => ResultApi(this.userBusiness.GetUsers(userName)));
            }
            else
            {
                return NotFound();
            }

        }
    }
}
