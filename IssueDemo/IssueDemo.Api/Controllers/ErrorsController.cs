using IssueDemo.Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace IssueDemo.Api.Controllers;
[ApiExplorerSettings(IgnoreApi = true)]

public class ErrorsController: ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

    var (statusCode, message) = exception switch
    {
      IServiceException serviceException => (serviceException.StatusCode.GetHashCode(), serviceException.ErrorMessage),
      _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred."),
    };
        return Problem(statusCode: statusCode, title: message);

    }
}