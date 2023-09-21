using Domain.Model.Task;

namespace Application.Common.Interfaces.Web;

public interface ITaskService
{
  Task<List<Domain.Entities.Task>> GetCurrentSprintTasks();
  Task AddTask(AddTaskDto addTaskDto);
}