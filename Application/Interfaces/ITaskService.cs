using Application.Models;
using Application.Models.UserTask;
using Domain.Common;

namespace Application.Interfaces;

public interface ITaskService
{
  Task<ServiceResult<List<UserTaskDto>>> GetUserTasks(GetUserTasksDto getUserTasksDto);
  Task<ServiceResult<bool>> AddUserTask(AddUserTaskDto addUserTaskDto);
}