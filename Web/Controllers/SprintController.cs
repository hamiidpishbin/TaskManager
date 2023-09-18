using Application.Sprints.Queries;
using Domain.Entity;
using Domain.Interface;
using Domain.Interface.Infrastructure;
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
  public IActionResult GetSprints()
  {
    return Ok(_context.Sprints.ToList());
  }
  
  [HttpGet("GetSprintsNew")]
  public async Task<ActionResult<IEnumerable<SprintDto>>> GetSprintsNew()
  {
    return Ok(await Mediator.Send(new GetSprintsQuery()));
  }

  [HttpPost("AddSprint")]
  public async Task<IActionResult> AddSprint(AddSprintDto sprintDto)
  {
    await _sprintService.AddSprint(sprintDto);
    return Ok();
  }

  [HttpGet("GetCurrentSprint")]
  public async Task<ActionResult<Sprint>> GetCurrentSprint()
  {
    return Ok(await _sprintService.GetCurrentSprint());
  }
}