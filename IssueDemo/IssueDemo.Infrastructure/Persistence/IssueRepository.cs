using IssueDemo.Application.Common.Interfaces.Persistence;
using IssueDemo.Domain.Entities;
using IssueDemo.Domain.IssueAggregate;

namespace IssueDemo.Infrastructure.Persistance;

public class IssueRepository : IIssueRepository
{
    private static readonly List<Issue> issues = new();

    public void Add(Issue issue)
    {
        issues.Add(issue);
    }

    public void Delete(Guid id)
    {
        Issue? issue = issues.FirstOrDefault(x => x.Id.Value == id);
        issues.Remove(issue);
    }

    public Issue? GetById(Guid id)
    {
        Issue? issue = issues.FirstOrDefault(x => x.Id.Value == id);
        return issue;
    }
}