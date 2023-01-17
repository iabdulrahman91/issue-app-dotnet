using IssueDemo.Application.Common.Interfaces.Persistence;
using IssueDemo.Domain.Entities;

namespace IssueDemo.Infrastructure.Persistance;

public class UserRepository : IUserRepository
{
    private static readonly List<User> users = new();

    public void Add(User user)
    {
        users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return users.SingleOrDefault(user => user.Email == email);
    }
}