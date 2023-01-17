namespace IssueDemo.Contracts.Issues;

public record IssueResponse(
    Guid Id,
    string Text,
    bool IsClosed,
    string CloseReason
);