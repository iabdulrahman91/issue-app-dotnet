using System.Net;

namespace IssueDemo.Application.Common.Errors;

public interface IServiceException
{
    public HttpStatusCode StatusCode {get;}
    public string ErrorMessage {get;}
}