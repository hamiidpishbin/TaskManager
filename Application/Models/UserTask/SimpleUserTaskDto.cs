namespace Application.Models.UserTask;

public record SimpleUserTaskDto
{
  public Guid Id { get; set; }
  public string Title { get; set; }
}