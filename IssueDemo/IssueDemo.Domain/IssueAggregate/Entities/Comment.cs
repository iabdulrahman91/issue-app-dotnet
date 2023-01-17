using IssueDemo.Domain.Common.Models;
using IssueDemo.Domain.IssueAggregate.ValueObjects;

namespace IssueDemo.Domain.IssueAggregate.Entities;

public sealed class Comment : Entity<CommentId>
{
    // private readonly IDateTimeProvider _dateTimeProvider;

    private Comment(
        CommentId commentId,
        string text) : base(commentId)
    {
        Text = text;
        CreationTime = DateTime.UtcNow; // TODO: replace with IDateTimeProvider
    }

    public static Comment Create(string text)
    {
        return new(CommentId.CreateUnique(),
        text);
    }
    public string Text { get; }

    public DateTime CreationTime { get; }

}