using Application.Common.Interfaces.Web;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;
using Web.Base;
using Task = Domain.Entities.Task;

namespace Web.Controllers;

public class DailyTaskController : BaseApiController
{
  private readonly ITaskService _taskService;

  public DailyTaskController(ITaskService taskService)
  {
    _taskService = taskService;
  }
  
  [HttpGet]
  public async Task<ActionResult<List<Task>>> GetCurrentSprintTasks()
  {
    return Ok(await _taskService.GetCurrentSprintTasks());
  }
}