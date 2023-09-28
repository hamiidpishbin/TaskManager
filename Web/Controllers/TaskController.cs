using Application.Common.Interfaces.Web;
using Application.Task.Commands.Add;
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
  public async Task<IActionResult> AddTask(AddTaskCommand addTaskCommand)
  {
    var result = await Mediator.Send(addTaskCommand);
    return HandleResult(result);
  }

  [HttpGet("GetCurrentSprintTasks")]
  public async Task<ActionResult<List<Domain.Entities.UserTask>>> GetCurrentSprintTasks()
  {
    var result = await _taskService.GetCurrentSprintTasks();
    return Ok(result);
  }
}