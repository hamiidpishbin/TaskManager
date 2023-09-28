using Application.Task.Commands.Add;
using Application.Task.Queries;
using Microsoft.AspNetCore.Mvc;
using Web.Base;

namespace Web.Controllers;

public class TaskController : BaseApiController
{
  [HttpPost("AddTask")]
  public async Task<IActionResult> AddTask(AddTaskCommand addTaskCommand)
  {
    var result = await Mediator.Send(addTaskCommand);
    return HandleResult(result);
  }

  [HttpGet("GetCurrentSprintTasks")]
  public async Task<IActionResult> GetCurrentSprintTasks()
  {
    var result = await Mediator.Send(new GetCurrentSprintTasksQuery());
    return HandleResult(result);
  }
}