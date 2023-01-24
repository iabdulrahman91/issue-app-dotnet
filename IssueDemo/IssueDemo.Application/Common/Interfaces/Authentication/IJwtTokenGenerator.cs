using IssueDemo.Domain.Entities;

namespace IssueDemo.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}