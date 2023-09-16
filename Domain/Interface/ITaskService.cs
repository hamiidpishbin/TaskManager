using Domain.Model.Task;

namespace Domain.Interface;

public interface ITaskService
{
  Task<List<Domain.Entity.Task>> GetCurrentSprintTasks();
  Task AddTask(AddTaskDto addTaskDto);
}