using Domain.Enums;
using Domain.Extensions;

namespace Domain.Common;

public class ServiceResult<T>
{
  public bool Succeeded { get; set; }
  public T Value { get; set; }
  public Enum Error { get; set; }

  public static ServiceResult<T> Success(T value)
  {
    return new ServiceResult<T>
    {
      Succeeded = true,
      Value = value
    };
  }

  public static ServiceResult<T> Failure(Enum error)
  {
    return new ServiceResult<T>
    {
      Succeeded = false,
      Error = error
    };
  }
}