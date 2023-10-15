using Domain.Base;
using Domain.Enums;

namespace Domain.Common;

public record ServiceErrorResult : BaseErrorResult<ServiceErrorType>
{
  public ServiceErrorResult(ServiceErrorType serviceError)
  {
    Type = serviceError;
  }
}