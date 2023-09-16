using Domain.Base;
using Domain.Interface;

namespace Domain.Entity;

public class Sprint : TitledDateTimeRangeEntity, ISoftDelete
{
  public IEnumerable<Task>? Tasks { get; set; }
  public bool IsDeleted { get; set; }
}