using Application.Dtos.UserTask;
using Application.Interfaces;
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
  public async Task<IActionResult> AddTask(AddUserTaskDto addUserTaskDto)
  {
    var result = await _taskService.AddUserTask(addUserTaskDto);
    return HandleResult(result);
  }

  [HttpGet("GetCurrentSprintTasks")]
  public async Task<IActionResult> GetCurrentSprintTasks(GetUserTasksDto getUserTasksDto)
  {
    var result = await _taskService.GetUserTasks(getUserTasksDto);
    return HandleResult(result);
  }
}