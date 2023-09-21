namespace Application.Common.Models;

public class Result<T>
{
  public bool Succeeded { get; set; }
  public T Value { get; set; }
  public string? Error { get; set; }

  public static Result<T> Success(T value)
  {
    return new Result<T>
    {
      Succeeded = true,
      Value = value
    };
  }

  public static Result<T> Failure(string? error)
  {
    return new Result<T>
    {
      Succeeded = false,
      Error = error
    };
  }
}