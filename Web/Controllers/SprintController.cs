using Application.Common.Interfaces.Infrastructure;
using Application.Common.Interfaces.Web;
using Application.Sprints.Commands.Add;
using Application.Sprints.Queries;
using Domain.Entities;
using Domain.Interface;
using Domain.Model.Sprint;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Web.Base;

namespace Web.Controllers;

public class SprintController : BaseApiController
{
  private readonly IApplicationDbContext _context;
  private readonly ISprintService _sprintService;

  public SprintController(IApplicationDbContext context, ISprintService sprintService)
  {
    _context = context;
    _sprintService = sprintService;
  }

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
  public async Task<ActionResult<Sprint>> GetCurrentSprint()
  {
    return Ok(await _sprintService.GetCurrentSprint());
  }
}