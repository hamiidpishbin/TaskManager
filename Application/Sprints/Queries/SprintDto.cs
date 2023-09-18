using Application.Tasks.Queries;
using Domain.Model.Base;

namespace Application.Sprints.Queries;

public class SprintDto : TitledDateTimeRangeDto
{
  public IEnumerable<TaskDto> Tasks { get; set; } = new List<TaskDto>();
}