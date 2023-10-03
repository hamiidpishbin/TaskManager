using System.Text.Json.Serialization;
using Application.Common.Interfaces.Web;
using Domain.Common;
using Domain.Enums;
using Domain.Interface;

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