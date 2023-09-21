using Domain.Entities;
using Domain.Enums;
using Domain.Model.Base;

namespace Application.Tasks.Queries;

public class TaskDto : TitledDto
{
  public Status Status { get; set; }
  public Sprint Sprint { get; set; } = null!;
  public DateTime? Start { get; set; }
  public DateTime? End { get; set; }
}