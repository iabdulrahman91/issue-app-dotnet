using IssueDemo.Application.Services.Authentication;
using IssueDemo.Application.Services.Issue;
using Microsoft.Extensions.DependencyInjection;

namespace IssueDemo.Application;

public static class dependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IIssueService, IssueService>();
        return services;
    }
}