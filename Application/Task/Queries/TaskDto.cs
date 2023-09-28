using Domain.Enums;
using Domain.Model.Base;

namespace Application.Task.Queries;

public class TaskDto : TitledDto
{
  public Status Status { get; set; }
  public Domain.Entities.Sprint Sprint { get; set; } = null!;
  public DateTime? Start { get; set; }
  public DateTime? End { get; set; }
}