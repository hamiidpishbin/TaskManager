using Application.Models;
using Application.Models.UserTask;
using Domain.Common;

namespace Application.Interfaces;

public interface ITaskService
{
  Task<OldResult<List<UserTaskDto>>> GetUserTasks(GetUserTasksDto getUserTasksDto);
  Task<OldResult<bool>> AddUserTask(AddUserTaskDto addUserTaskDto);
}