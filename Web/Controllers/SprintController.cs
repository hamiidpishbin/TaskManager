using Application.Interfaces;
using Application.Models;
using Domain.Entity;
using Domain.Interface;
using Domain.Model.Sprint;
using Domain.Models.Sprint;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Base;

namespace Web.Controllers;

public class SprintController : BaseApiController
{
  private readonly ApplicationDbContext _context;
  private readonly ISprintService _sprintService;

  public SprintController(ApplicationDbContext context, ISprintService sprintService)
  {
    _context = context;
    _sprintService = sprintService;
  }

  [HttpGet]
  public IActionResult Get()
  {
    return Ok(_context.Sprints.ToList());
  }

  [HttpPost]
  public async Task<IActionResult> Add(SprintSaveDateTimeRangeDto sprintSaveDateTimeRangeDto)
  {
    await _sprintService.AddNewSprint(sprintSaveDateTimeRangeDto);
    return Ok();
  }

  [HttpGet("GetCurrentSprint")]
  public async Task<ActionResult<Sprint>> GetCurrentSprint()
  {
    return Ok(await _sprintService.GetCurrentSprint());
  }
}