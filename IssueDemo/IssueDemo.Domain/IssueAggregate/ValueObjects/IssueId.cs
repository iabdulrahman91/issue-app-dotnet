using IssueDemo.Domain.Common.Models;

namespace IssueDemo.Domain.IssueAggregate.ValueObjects;

public sealed class IssueId : ValueObject
{
    public Guid Value { get; }

    private IssueId(Guid value)
    {
        Value = value;
    }

    public static IssueId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}