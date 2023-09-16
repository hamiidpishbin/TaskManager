using Domain.Model.Base;

namespace Domain.Model.DailyTask;

public class DailyTaskDto : TitledDateTimeRangeDto
{
  // public TaskDto Task { get; set; }
  public TimeSpan TimeSpan { get; set; }
  public string Comment { get; set; }
  public bool IsSubmitted { get; set; }
}