using IssueDemo.Application.Services.Authentication;
using IssueDemo.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace IssueDemo.Api.Controllers;

[ApiController]
public class AuthenticationController: ControllerBase
{
    // applying dependancy injection to decouple the service from the controller.
    private readonly IAuthenticationService _authenticationService; 

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        AuthenticationResult authRestult = _authenticationService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password); 
        
        // mapping the result from auth service to the webapi auth response,
        AuthenticationResponse response = new AuthenticationResponse(
            authRestult.User.Id,
            authRestult.User.FirstName,
            authRestult.User.LastName,
            authRestult.User.Email,
            authRestult.Token);
        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        AuthenticationResult authRestult = _authenticationService.Login(
            request.Email,
            request.Password); 
        
        // mapping the result from auth service to the webapi auth response,
        AuthenticationResponse response = new AuthenticationResponse(
            authRestult.User.Id,
            authRestult.User.FirstName,
            authRestult.User.LastName,
            authRestult.User.Email,
            authRestult.Token);
        return Ok(response);
    }

}
