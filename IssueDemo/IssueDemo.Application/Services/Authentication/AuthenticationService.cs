
using IssueDemo.Application.Common.Errors;
using IssueDemo.Application.Common.Interfaces.Authentication;
using IssueDemo.Application.Common.Interfaces.Persistence;
using IssueDemo.Domain.Entities;

namespace IssueDemo.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Register(string FirstName, string LastName, string Email, string Password)
    {

        // check if user exists
        if (_userRepository.GetUserByEmail(Email) is not null)
        {
            throw new DuplicateEmailException();
        }

        // create user (generate unique ID)
        User user = new User{
            FirstName = FirstName,
            LastName = LastName,
            Email = Email,
            Password = Password
        };
        
        _userRepository.Add(user);

        // Create JWT Token
        string token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
        user,
        token);
    }
    public AuthenticationResult Login(string Email, string Password)
    {
        // check if user doesn't exists
        if (_userRepository.GetUserByEmail(Email) is not User user)
        {
            throw new InvalidCredentialsException();
        }

        // check password
        if(user.Password != Password)
        {
            throw new InvalidCredentialsException();
        }


        // Create JWT Token
        string token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
        user,
        token);
    }

    
}
