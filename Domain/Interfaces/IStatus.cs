using Domain.Enums;

namespace Application.Common.Interfaces.Web;

public interface IStatus
{
  Status Status { get; set; }
}