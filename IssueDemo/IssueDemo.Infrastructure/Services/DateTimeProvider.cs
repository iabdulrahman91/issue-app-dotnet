using IssueDemo.Application.Common.Interfaces.Services;

namespace IssueDemo.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;

}