using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using Utilities;

namespace Aranda.ComponenteAutorizacion.Api
{
    public abstract class ExceptionControl: Microsoft.AspNetCore.Mvc.ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fnCallBack"></param>
        /// <returns></returns>
        protected IActionResult ExceptionBehavior(Func<IActionResult> fnCallBack)
        {
            try
            {
                return fnCallBack();
            }
            catch (Exception ex) { return ExceptionResultApi(ex); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statusCodes"></param>
        /// <param name="message"></param>
        /// <param name="tags"></param>
        /// <returns></returns>
        private IActionResult ResultResponseApi(int statusCodes, string message)
        {
            return StatusCode(statusCodes, new ResponseApi { ErrorCode = statusCodes, Message = message} );
        }

        protected IActionResult ExceptionResultApi(Exception customException)
        {
            return ResultResponseApi(StatusCodes.Status500InternalServerError, "Error General");
        }

        /// <summary>
        /// Controla los resultados de la Api
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objResult"></param>
        /// <returns></returns>
        protected IActionResult ResultApi<T>(T objResult)
        { return StatusCode(StatusCodes.Status200OK, objResult); }
    }
}
