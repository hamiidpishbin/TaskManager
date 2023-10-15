using Domain.Base;
using Domain.Enums;

namespace Domain.Common;

public record ServiceResult<TResult> : BaseResult<TResult, ServiceErrorResult, ServiceErrorType>
{
  public ServiceResult(TResult value) : base(value)
  {
  }

  public ServiceResult(ServiceErrorResult serviceError) : base(serviceError)
  {
  }

  public ServiceResult(IEnumerable<ServiceErrorResult>? errors) : base(errors)
  {
  }

  public ServiceResult(bool isSuccessful, TResult value, IEnumerable<ServiceErrorResult>? errors) : base(isSuccessful, value, errors)
  {
  }
}