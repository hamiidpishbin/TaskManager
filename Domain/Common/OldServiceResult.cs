using Domain.Base;
using Domain.Enums;

namespace Domain.Common;

public record OldServiceResult<TResult> : BaseResult<TResult, ServiceErrorResult, ServiceErrorType>
{
  public OldServiceResult(TResult value) : base(value)
  {
  }

  public OldServiceResult(ServiceErrorResult serviceError) : base(serviceError)
  {
  }

  public OldServiceResult(IEnumerable<ServiceErrorResult>? errors) : base(errors)
  {
  }

  public OldServiceResult(bool isSuccessful, TResult value, IEnumerable<ServiceErrorResult>? errors) : base(isSuccessful, value, errors)
  {
  }
}