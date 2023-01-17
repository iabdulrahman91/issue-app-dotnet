namespace IssueDemo.Contracts.Authentication;
using System.ComponentModel.DataAnnotations;

public record LoginRequest(
    [EmailAddress] string Email,
    string Password
);