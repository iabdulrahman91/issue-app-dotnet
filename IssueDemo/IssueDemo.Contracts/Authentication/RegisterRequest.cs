namespace IssueDemo.Contracts.Authentication;
using System.ComponentModel.DataAnnotations;

public record RegisterRequest(
    string FirstName,
    string LastName,
    [EmailAddress] string Email,
    string Password
);