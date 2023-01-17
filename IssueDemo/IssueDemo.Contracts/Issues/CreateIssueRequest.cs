namespace IssueDemo.Contracts.Issues;
using System.ComponentModel.DataAnnotations;

public record CreateIssueRequest(
    [MinLength(5)] string Text,
    bool IsClosed,
    string CloseReason
);

public record CommentSection(
    string Text
);


public record UpdateIssueRequest(
    [MinLength(5)] string Text,
    bool IsClosed,
    string CloseReason
);