using Domain.Interface;
using Domain.Model.Task;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Web.Base;

namespace Web.Controllers;

public class TaskController : BaseApiController
{
  private readonly ISprintService _sprintService;
  private readonly ApplicationDbContext _context;
  private readonly ITaskService _taskService;

  public TaskController(ISprintService sprintService, ApplicationDbContext context, ITaskService taskService)
  {
    _sprintService = sprintService;
    _context = context;
    _taskService = taskService;
  }

  [HttpPost("AddTask")]
  public async Task AddTask(AddTaskDto addTaskDto)
  {
    await _taskService.AddTask(addTaskDto);
  }
  
  [HttpGet("GetCurrentSprintTasks")]
  public async Task<ActionResult<List<Domain.Entity.Task>>> GetCurrentSprintTasks()
  {
    var currentSprint = await _sprintService.GetCurrentSprint();
    var result = _context.Tasks.Where(task => task.Id == currentSprint.Id).ToList();
    return Ok(result);
  }
}