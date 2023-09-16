using Domain.Base;
using Domain.Interface;

namespace Domain.Entity;

public class Sprint : TitledDateTimeRangeEntity, ISoftDelete
{
  public ICollection<Task>? Tasks { get; } = new List<Task>();
  public bool IsDeleted { get; set; }
}