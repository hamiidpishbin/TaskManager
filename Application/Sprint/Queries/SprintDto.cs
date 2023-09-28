using Application.Task.Queries;
using Domain.Model.Base;

namespace Application.Sprint.Queries;

public class SprintDto : TitledDateTimeRangeDto
{
  public IEnumerable<TaskDto> Tasks { get; set; } = new List<TaskDto>();
}