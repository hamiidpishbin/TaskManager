using Domain.Interface;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Web.Base;
using Task = Domain.Entity.Task;

namespace Web.Controllers;

public class TaskController : BaseApiController
{
  private readonly ISprintService _sprintService;
  private readonly ApplicationDbContext _context;

  public TaskController(ISprintService sprintService, ApplicationDbContext context)
  {
    _sprintService = sprintService;
    _context = context;
  }

  // [HttpPost("AddTask")]
  // public async Task AddTask()
  // {
  //   
  // }
  
  [HttpGet("GetCurrentSprintTasks")]
  public async Task<ActionResult<List<Task>>> GetCurrentSprintTasks()
  {
    var currentSprint = await _sprintService.GetCurrentSprint();
    var result = _context.Tasks.Where(task => task.Id == currentSprint.Id).ToList();
    return Ok(result);
  }
}