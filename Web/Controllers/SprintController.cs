using Application.Common.Interfaces.Infrastructure;
using Application.Common.Interfaces.Web;
using Application.Sprint.Commands.AddSprint;
using Application.Sprint.Queries;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Web.Base;

namespace Web.Controllers;

public class SprintController : BaseApiController
{
  [HttpGet("GetSprints")]
  public async Task<ActionResult<IEnumerable<SprintDto>>> GetSprints()
  {
    return Ok(await Mediator.Send(new GetSprintsQuery()));
  }

  [HttpPost("AddSprint")]
  public async Task<IActionResult> AddSprint(AddSprintCommand sprintCommand)
  {
    var result = await Mediator.Send(sprintCommand);
    return HandleResult(result);
  }

  [HttpGet("GetCurrentSprint")]
  public async Task<IActionResult> GetCurrentSprint()
  {
    var result = await Mediator.Send(new GetCurrentSprintQuery());
    return HandleResult(result);
  }
}