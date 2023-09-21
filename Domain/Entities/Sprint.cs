using Application.Common.Interfaces.Web;
using Domain.Common;
using Domain.Enums;
using Domain.Interface;
using Task = Domain.Entities.Task;

namespace Domain.Entities;

public class Sprint : BaseEntity, IStatus, IAutoDateTimeUpdate, ISoftDelete
{
  public string Title { get; set; }
  public bool IsDeleted { get; set; }
  public Status Status { get; set; }
  public DateTime? Start { get; set; }
  public DateTime? End { get; set; }
  public ICollection<Task>? Tasks { get; } = new List<Task>();
}