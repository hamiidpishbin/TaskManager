using Domain.Base;
using Domain.Enumeration;
using Domain.Interface;

namespace Domain.Entity;

public class Task : TitledEntity, ISoftDelete, IAutoDateTimeUpdate, IStatus
{
  public Status Status { get; set; }
  public bool IsDeleted { get; set; }
  public Guid SprintId { get; set; }
  public Sprint Sprint { get; set; } = null!;
  public DateTime? Start { get; set; }
  public DateTime? End { get; set; }
}