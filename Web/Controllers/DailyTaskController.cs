using Domain.Entity;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;
using Web.Base;

namespace Web.Controllers;

public class DailyTaskController : BaseApiController
{
  private readonly ITaskService _taskService;

  public DailyTaskController(ITaskService taskService)
  {
    _taskService = taskService;
  }
  
  [HttpGet]
  public async Task<ActionResult<List<Domain.Entity.Task>>> GetCurrentSprintTasks()
  {
    return Ok(await _taskService.GetCurrentSprintTasks());
  }
}