using IssueDemo.Domain.Common.Models;

namespace IssueDemo.Domain.IssueAggregate.ValueObjects;

public sealed class IssueLabel : ValueObject
{
    public Guid Value { get; }

    private IssueLabel(Guid value)
    {
        Value = value;
    }

    public static IssueLabel CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}