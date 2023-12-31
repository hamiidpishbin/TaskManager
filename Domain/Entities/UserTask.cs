using Domain.Base;
using Domain.Enums;
using Domain.Interfaces;

namespace Domain.Entities;

public record UserTask : BaseAuditableEntity, ISoftDelete, IAutoDateTimeUpdate, IStatus
{
  public string Title { get; set; }
  public Guid SprintId { get; set; }
  public Sprint Sprint { get; set; } = null!;
  public DateTime? Start { get; set; }
  public DateTime? End { get; set; }
  public bool IsDeleted { get; set; }
  public Status Status { get; set; }
}