using Application.Models;
using Domain.Enums;

namespace Application.Dtos.UserTask;

public record UserTaskDto : BaseDto
{
  public string Title { get; set; }
  public Status Status { get; set; }
  public Domain.Entities.Sprint Sprint { get; set; } = null!;
  public DateTime? Start { get; set; }
  public DateTime? End { get; set; }
}