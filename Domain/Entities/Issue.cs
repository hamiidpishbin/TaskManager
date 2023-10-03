using Domain.Base;
using Domain.Enums;
using Domain.Interfaces;

namespace Domain.Entities;

public record Issue : BaseAuditableEntity, ISoftDelete, IStatus
{
  public bool IsDeleted { get; set; }
  public Status Status { get; set; }
}