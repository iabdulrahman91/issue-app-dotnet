using IssueDemo.Domain.IssueAggregate;

namespace IssueDemo.Application.Common.Interfaces.Persistence;

public interface IIssueRepository
{
    void Add(Issue issue);
    Issue? GetById(Guid id);
}