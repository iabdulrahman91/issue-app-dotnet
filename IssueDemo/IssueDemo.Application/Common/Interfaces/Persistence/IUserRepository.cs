using IssueDemo.Domain.Entities;

namespace IssueDemo.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);

    void Add(User user);
}