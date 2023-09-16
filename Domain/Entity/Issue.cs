using Domain.Base;
using Domain.Enumeration;
using Domain.Interface;

namespace Domain.Entity;

public class Issue : BaseEntity, ISoftDelete
{
  public IssueStatus Status { get; set; }
  public bool IsDeleted { get; set; }
}