namespace IssueDemo.Application.Services.Issue;

using System;
using IssueDemo.Application.Common.Errors;
using IssueDemo.Application.Common.Interfaces.Persistence;
using IssueDemo.Domain.IssueAggregate;
public class IssueService : IIssueService
{
    private readonly IIssueRepository _issueRepository;

    public IssueService(IIssueRepository issueRepository)
    {
        _issueRepository = issueRepository;
    }

    public IssueResult Create(string Text, bool IsClosed, string CloseReason)
    {

        // Create Issue
        Issue issue = Issue.Create(Text, IsClosed, CloseReason);

        // Persist Issue
        _issueRepository.Add(issue);

        // return Issue
        return new IssueResult(issue);

    }

    public IssueResult Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public IssueResult Get(Guid id)
    {
        Issue? issue = _issueRepository.GetById(id);

        if ( issue is null)
        {
            throw new NotFoundException();
        }
        
        return new IssueResult(issue);

    }

    public IssueResult Update(Issue issue)
    {
        throw new NotImplementedException();
    }
}