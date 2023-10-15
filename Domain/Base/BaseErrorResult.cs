namespace Domain.Base;

public record BaseErrorResult<TErrorType>
{
  public TErrorType Type { get; set; }
}