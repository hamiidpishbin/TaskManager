using Application.Common.Interfaces.Web;
using Domain.Common;
using Domain.Enums;
using Domain.Interface;

namespace Domain.Entities;

public class Issue : BaseEntity, ISoftDelete, IStatus
{
  public bool IsDeleted { get; set; }
  public Status Status { get; set; }
}