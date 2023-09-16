using Domain.Model.Task;
using Task = Domain.Entity.Task;

namespace Infrastructure.Mapping;

public static class TaskMapper
{
  public static Task ToEntity(this AddTaskDto addTaskDto)
  {
    return new Task()
    {
      Title = addTaskDto.Title,
      Start = addTaskDto.Start,
      End = addTaskDto.End,
      SprintId = addTaskDto.SprintId,
    };
  }
}