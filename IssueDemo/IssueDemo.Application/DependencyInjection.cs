using IssueDemo.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace IssueDemo.Application;

public static class dependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        return services;
    }
}