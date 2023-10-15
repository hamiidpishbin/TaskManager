using Application.Interfaces;
using Application.Models.UserTask;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class UserTaskController : BaseApiController
{
  private readonly ITaskService _taskService;

  public UserTaskController(ITaskService taskService)
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