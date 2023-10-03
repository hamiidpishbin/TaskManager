using Application.Dtos.UserTask;
using Application.Models;

namespace Application.Interfaces;

public interface ITaskService
{
  Task<Result<List<UserTaskDto>>> GetUserTasks(GetUserTasksDto getUserTasksDto);
  Task<Result<bool>> AddUserTask(AddUserTaskDto addUserTaskDto);
}