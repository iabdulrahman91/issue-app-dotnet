using System.Net;
namespace IssueDemo.Application.Common.Errors;

public class NotFoundException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.NotFound;

    public string ErrorMessage => "Not Found.";
}