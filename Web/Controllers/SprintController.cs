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