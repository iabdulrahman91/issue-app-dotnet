using System.Net;
namespace IssueDemo.Application.Common.Errors;

public class InvalidCredentialsException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Unauthorized;

    public string ErrorMessage => "Invalid Credentials";
}