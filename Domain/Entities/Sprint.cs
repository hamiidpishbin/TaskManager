using Application.Common.Interfaces.Web;
using Domain.Common;
using Domain.Enums;
using Domain.Interface;

namespace Domain.Entities;

public class Sprint : BaseAuditableEntity, IStatus, IAutoDateTimeUpdate, ISoftDelete
{
  public string Title { get; set; }
  public ICollection<UserTask>? Tasks { get; } = new List<UserTask>();
  public DateTime? Start { get; set; }
  public DateTime? End { get; set; }
  public bool IsDeleted { get; set; }
  public Status Status { get; set; }
}