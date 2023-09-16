using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class IssueController
{
    [HttpGet]
    public IActionResult GetIssues()
    {
        return new BadRequestResult();
    }
}