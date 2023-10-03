using Application.Common.Models;
using Application.Dtos.UserTask;

namespace Application.Interfaces;

public interface ITaskService
{
  Task<Result<List<UserTaskDto>>> GetUserTasks(GetUserTasksDto getUserTasksDto);
  Task<Result<bool>> AddUserTask(AddUserTaskDto addUserTaskDto);
}