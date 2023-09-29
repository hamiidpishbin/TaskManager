using Application.Sprint.Commands.AddSprint;
using Application.Sprint.Queries;
using Microsoft.AspNetCore.Mvc;
using Web.Base;
using Application.Sprint;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers;

public class SprintController : BaseApiController
{
  [HttpGet("GetSprints")]
  public async Task<IActionResult> GetSprints()
  {
    var result = await Mediator.Send(new GetSprintsQuery());
    return HandleResult(result);
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
    var result = await Mediator.Send(new GetCurrentSprintDtoQuery());
    return HandleResult(result);
  }
}