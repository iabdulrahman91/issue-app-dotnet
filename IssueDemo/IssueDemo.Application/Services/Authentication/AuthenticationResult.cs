using IssueDemo.Domain.Entities;

namespace IssueDemo.Application.Services.Authentication;

/** 
since we are not referencing to the presentation layer(api and contracts) from application layer,
then we need to define AuthenticationResult within the application layer.
**/
public record AuthenticationResult(
    User User,
    string Token);