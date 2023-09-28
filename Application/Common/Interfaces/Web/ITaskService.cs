using Domain.Model.Task;
using Domain.Entities;

namespace Application.Common.Interfaces.Web;

public interface ITaskService
{
  Task<List<UserTask>> GetCurrentSprintTasks();
  System.Threading.Tasks.Task AddTask(AddTaskDto addTaskDto);
}