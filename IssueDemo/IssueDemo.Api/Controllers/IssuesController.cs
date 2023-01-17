using System.Net;
using IssueDemo.Application.Services.Issue;
using IssueDemo.Contracts.Issues;
using Microsoft.AspNetCore.Mvc;

namespace IssueDemo.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class IssuesController : ControllerBase
{
        private readonly IIssueService _issueService;

    public IssuesController(IIssueService issueService)
    {
        _issueService = issueService;
    }

    [HttpPost]
    public IActionResult CreateIssue(
        CreateIssueRequest request
    )
    {
        if (ModelState.IsValid)
            {
                // Do something with the product (not shown).
                IssueResult issueResult = _issueService.Create(
                    request.Text,
                    request.IsClosed,
                    request.CloseReason); 
                
                // mapping the result from service result to the webapi response,
                IssueResponse response = new IssueResponse(
                    issueResult.Issue.Id.Value,
                    issueResult.Issue.Text,
                    issueResult.Issue.IsClosed,
                    issueResult.Issue.CloseReason);

                return CreatedAtAction(
                    nameof(GetIssue),
                    new {id = response.Id},
                    response);
            }
            else
            {
                return Problem(statusCode: HttpStatusCode.BadRequest.GetHashCode());
            }
            

    }

    [HttpGet("{id:guid}")]
    public IActionResult GetIssue(Guid id)
    {

        IssueResult issueResult = _issueService.Get(id);

        IssueResponse response = new IssueResponse(
                    issueResult.Issue.Id.Value,
                    issueResult.Issue.Text,
                    issueResult.Issue.IsClosed,
                    issueResult.Issue.CloseReason);

        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateIssue(Guid id, UpdateIssueRequest request)
    {
        return Ok(request);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteIssue(Guid id)
    {
        return Ok(id);
    }
}