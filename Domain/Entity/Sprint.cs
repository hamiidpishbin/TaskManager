using Domain.Base;
using Domain.Enumeration;
using Domain.Interface;

namespace Domain.Entity;

public class Sprint : TitledEntity, IStatus, IAutoDateTimeUpdate, ISoftDelete
{
  public ICollection<Task>? Tasks { get; } = new List<Task>();
  public bool IsDeleted { get; set; }
  public Status Status { get; set; }
  public DateTime? Start { get; set; }
  public DateTime? End { get; set; }
}