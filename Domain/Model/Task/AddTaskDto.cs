using Domain.Model.Base;

namespace Domain.Model.Task;

public class AddTaskDto : TitledDateTimeRangeDto
{
  public Guid SprintId { get; set; }
}