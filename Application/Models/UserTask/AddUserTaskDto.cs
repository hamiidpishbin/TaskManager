namespace Application.Dtos.UserTask;

public record AddUserTaskDto
{
  public Guid SprintId { get; init; }
  public string Title { get; init; }
}