using IssueDemo.Domain.Common.Models;
using IssueDemo.Domain.IssueAggregate.Entities;
using IssueDemo.Domain.IssueAggregate.ValueObjects;

namespace IssueDemo.Domain.IssueAggregate;

public sealed class Issue : AggregateRoot<IssueId>
{
    private readonly List<Comment> _comments = new();

    private readonly List<IssueLabel> _issueLabels = new();

    private Issue(IssueId issueId,
                  string text,
                  bool isClosed,
                  string closeReason) : base(issueId)
    {
        Text = text;
        IsClosed = isClosed;
        CloseReason = closeReason;
    }

    public static Issue Create(
        string text,
        bool isClosed,
        string closeReason
    )
    {
        return new(
            IssueId.CreateUnique(),
            text,
            isClosed,
            closeReason
        );
    }
    public string Text { get; }

    public bool IsClosed { get; }

    public string CloseReason { get; }

    public IReadOnlyList<Comment> Comments => _comments.AsReadOnly();
}