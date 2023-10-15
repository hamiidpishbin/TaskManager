namespace Domain.Common;

public class OldResult<T>
{
  public bool Succeeded { get; set; }
  public T Value { get; set; }
  public string? Error { get; set; }

  public static OldResult<T> Success(T value)
  {
    return new OldResult<T>
    {
      Succeeded = true,
      Value = value
    };
  }

  public static OldResult<T> Failure(string? error)
  {
    return new OldResult<T>
    {
      Succeeded = false,
      Error = error
    };
  }
}