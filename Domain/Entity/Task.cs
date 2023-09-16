using Domain.Base;
using Domain.Enumeration;
using Domain.Interface;

namespace Domain.Entity;

public class Task : TitledDateTimeRangeEntity, ISoftDelete
{
  public Status Status { get; set; }
  public bool IsDeleted { get; set; }
  public Sprint Sprint { get; set; }
  public Guid SprintId { get; set; }
}