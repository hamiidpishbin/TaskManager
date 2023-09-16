namespace Domain.Interface;

public interface ITaskService
{
  Task<List<Domain.Entity.Task>> GetCurrentSprintTasks();
}