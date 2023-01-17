namespace IssueDemo.Application.Services.Issue;
using IssueDemo.Domain.IssueAggregate;
public interface IIssueService
{
    IssueResult Create(string Text, bool IsClosed, string CloseReason);

    IssueResult Delete(Guid id);

    IssueResult Get(Guid id);

    IssueResult Update(Issue issue);

}