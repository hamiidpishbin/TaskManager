using System.Text.Json.Serialization;
using Domain.Base;
using Domain.Enums;
using Domain.Interfaces;

namespace Domain.Entities;

public record Sprint : BaseAuditableEntity, IStatus, ISoftDelete
{
  public string Title { get; set; }

  [JsonIgnore] public ICollection<UserTask>? Tasks { get; } = new List<UserTask>();

  public DateTime Start { get; set; }
  public DateTime End { get; set; }
  public bool IsDeleted { get; set; }
  public Status Status { get; set; }
}