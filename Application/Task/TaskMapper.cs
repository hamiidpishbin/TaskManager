using Application.Task.Queries;
using Domain.Model.Task;

namespace Application.Task;

public static class TaskMapper
{
  public static TaskDto ToDto(this Domain.Entities.UserTask userTask)
  {
    return new TaskDto()
    {
      Status = userTask.Status,
      Sprint = userTask.Sprint,
      Start = userTask.Start,
      End = userTask.End,
    };
  }

  public static IEnumerable<TaskDto> ToDto(this IEnumerable<Domain.Entities.UserTask>? tasks)
  {
    return (tasks ?? Array.Empty<Domain.Entities.UserTask>()).Select(task => task.ToDto());
  }

  public static Domain.Entities.UserTask ToEntity(this AddTaskDto addTaskDto)
  {
    return new Domain.Entities.UserTask()
    {
      Title = addTaskDto.Title,
      SprintId = addTaskDto.SprintId,
    };
  }
}