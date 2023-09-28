using Application.Task.Queries;
using Domain.Model.Base;

namespace Application.Sprint.Queries;

public class SprintDto : TitledDateTimeRangeDto
{
  public IEnumerable<UserTaskDto> Tasks { get; set; } = new List<UserTaskDto>();
}