using Domain.Model.Base;

namespace Domain.Model.Task;

public class AddTaskDto : TitledDto
{
  public Guid SprintId { get; set; }
}