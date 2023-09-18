using Application.Tasks.Queries;
using Task = Domain.Entity.Task;

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

  public static IEnumerable<TaskDto> ToDto(this IEnumerable<Task> tasks)
  {
    return tasks.Select(task => task.ToDto());
  }
}