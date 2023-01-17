// it benefit from referencing application layer from Infra layer
using IssueDemo.Application.Common.Interfaces.Authentication;
using IssueDemo.Application.Common.Interfaces.Persistence;
using IssueDemo.Application.Common.Interfaces.Services;
using IssueDemo.Infrastructure.Authentication;
using IssueDemo.Infrastructure.Persistance;
using IssueDemo.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IssueDemo.Infrastructure;

public static class dependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IUserRepository, UserRepository>();
        
        return services;
    }
}