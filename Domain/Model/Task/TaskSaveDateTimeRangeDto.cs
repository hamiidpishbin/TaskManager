using Domain.Model.Base;
using Domain.Model.Sprint;

namespace Domain.Model.Task;

public class TaskSaveDateTimeRangeDto : TitledDateTimeRangeDto
{
  public SprintSaveDateTimeRangeDto Sprint { get; set; }
}