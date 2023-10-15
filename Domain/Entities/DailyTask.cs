using Domain.Base;

namespace Domain.Entities;

public record DailyTask : BaseAuditableEntity
{
  public Guid UserTaskId { get; set; }
  public string Title { get; set; }
  public DateTime Start { get; set; }
  public DateTime End { get; set; }
  public string Description { get; set; }
  public bool Submitted { get; set; }
}