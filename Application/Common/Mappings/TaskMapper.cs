using Application.Tasks.Queries;
using Domain.Model.Task;
using Task = Domain.Entities.Task;

namespace Application.Common.Mappings;

public static class TaskMapper
{
  public static TaskDto ToDto(this Task task)
  {
    return new TaskDto()
    {
      Status = task.Status,
      Sprint = task.Sprint,
      Start = task.Start,
      End = task.End,
    };
  }

  public static IEnumerable<TaskDto> ToDto(this IEnumerable<Task>? tasks)
  {
    return (tasks ?? Array.Empty<Task>()).Select(task => task.ToDto());
  }
  
  public static Task ToEntity(this AddTaskDto addTaskDto)
  {
    return new Task()
    {
      Title = addTaskDto.Title,
      SprintId = addTaskDto.SprintId,
    };
  }
}