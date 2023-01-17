namespace IssueDemo.Domain.Entities;

public class User
{
    public Guid Id {set; get;} = Guid.NewGuid();

    public string FirstName { set; get; } = null!;
    public string LastName { set; get; } = null!;
    public string Email { set; get; } = null!;
    public string Password { set; get; } = null!;
}