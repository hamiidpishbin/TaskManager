using Application.Common.Interfaces.Web;
using Domain.Common;
using Domain.Enums;
using Domain.Interface;

namespace Domain.Entities;

public class Task : BaseEntity, ISoftDelete, IAutoDateTimeUpdate, IStatus
{
  public string Title { get; set; }
  public Status Status { get; set; }
  public bool IsDeleted { get; set; }
  public Guid SprintId { get; set; }
  public Sprint Sprint { get; set; } = null!;
  public DateTime? Start { get; set; }
  public DateTime? End { get; set; }
}