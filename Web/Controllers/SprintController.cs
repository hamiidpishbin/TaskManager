using Application.Dtos.Sprint;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Web.Base;

namespace Web.Controllers;

public class SprintController : BaseApiController
{
  private readonly ISprintService _sprintService;

  public SprintController(ISprintService sprintService)
  {
    _sprintService = sprintService;
  }

  [HttpGet("GetSprints")]
  public async Task<IActionResult> GetSprints()
  {
    var result = await _sprintService.GetSprintsAsync();
    return HandleResult(result);
  }

  [HttpPost("AddSprint")]
  public async Task<IActionResult> AddSprint(AddSprintDto addSprintDto)
  {
    var result = await _sprintService.AddSprintAsync(addSprintDto);
    return HandleResult(result);
  }

  [HttpGet("GetCurrentSprint")]
  public async Task<IActionResult> GetCurrentSprint()
  {
    var result = await _sprintService.GetCurrentSprintDtoAsync();
    return HandleResult(result);
  }
}