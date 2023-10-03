using Application.Dtos.UserTask;

namespace Application.Dtos.Sprint;

public record SprintDto : BaseDto
{
  public string Title { get; set; }
  public DateTime Start { get; set; }
  public DateTime End { get; set; }
  public IEnumerable<UserTaskDto> Tasks { get; set; } = new List<UserTaskDto>();
}