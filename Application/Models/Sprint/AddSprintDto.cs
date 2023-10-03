namespace Application.Models.Sprint;

public record AddSprintDto
{
  public string Title { get; init; }
  public DateTime Start { get; init; }
  public DateTime End { get; init; }
}