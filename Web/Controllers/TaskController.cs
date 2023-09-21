using Application.Common.Interfaces.Web;
using Domain.Interface;
using Domain.Model.Task;
using Microsoft.AspNetCore.Mvc;
using Web.Base;

namespace Web.Controllers;

public class TaskController : BaseApiController
{
  private readonly ITaskService _taskService;

  public TaskController(ITaskService taskService)
  {
    _taskService = taskService;
  }

  [HttpPost("AddTask")]
  public async Task AddTask(AddTaskDto addTaskDto)
  {
    await _taskService.AddTask(addTaskDto);
  }
  
  [HttpGet("GetCurrentSprintTasks")]
  public async Task<ActionResult<List<Domain.Entities.Task>>> GetCurrentSprintTasks()
  {
    var result = await _taskService.GetCurrentSprintTasks();
    return Ok(result);
  }
}