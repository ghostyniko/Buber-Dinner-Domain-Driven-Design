using BuberDinner.Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("error")]
public class ErrorsController : ControllerBase
{
    [HttpGet]
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        var (statusCode,message) = exception switch
        {
            IServiceException serviceException =>((int)serviceException.StatusCode,serviceException.ErrorMessage),
        
            _ => (StatusCodes.Status500InternalServerError, "An unexpected error occured")
        };
        return Problem(statusCode:statusCode,title:message);
    }
}

