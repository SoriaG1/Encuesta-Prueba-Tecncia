using Inventario.Api.Responses;
using Inventario.Entities.Dtos.Users;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Inventario.Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : Controller
    {
        [Route("/error-development")]
        public IActionResult HandleErrorDevelopment([FromServices] IHostEnvironment hostEnvironment)
        {
            if (!hostEnvironment.IsDevelopment())
            {
                return NotFound();
            }

            var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>()!;
            return StatusCode(StatusCodes.Status500InternalServerError,new
            {
                hasError = true,
                message = "Detail: "+ exceptionHandlerFeature.Error.StackTrace + "<br>title" + exceptionHandlerFeature.Error.Message,
                model = new { },
                requestId = System.Diagnostics.Activity.Current?.Id
            });
        }

        [Route("/error")]
        public IActionResult HandleError()
        {
            var exceptionHandlerFeature =
              HttpContext.Features.Get<IExceptionHandlerFeature>()!;

            return StatusCode(StatusCodes.Status500InternalServerError, new
            {
                hasError = true,
                message = "Detail: " + exceptionHandlerFeature.Error.StackTrace,
                model = new { },
                requestId = System.Diagnostics.Activity.Current?.Id
            });
        }

        [Route("/PageNotFound")]
        public IActionResult PageNotFound()
        {

            return Ok(new
            {
                hasError = true,
                message = "Not Found",
                model = new { title= "Page not found", message= "This page does not exists!" },
                requestId = System.Diagnostics.Activity.Current?.Id
            }); ;
        }
    }
}
