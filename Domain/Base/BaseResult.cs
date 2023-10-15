namespace Domain.Base;

public record BaseResult<TResult, TError, TErrorType> where TError : BaseErrorResult<TErrorType>
{
  protected BaseResult(TResult value) : this(isSuccessful: true, value: value, errors: null)
  {
  }

  protected BaseResult(TError serviceError) : this(isSuccessful: false, value: default!, errors: new List<TError> { serviceError })
  {
  }

  protected BaseResult(IEnumerable<TError>? errors) : this(isSuccessful: false, value: default!, errors: errors)
  {
  }

  protected BaseResult(bool isSuccessful, TResult value, IEnumerable<TError>? errors)
  {
    IsSuccessful = isSuccessful;
    Value = value;
    Errors = errors;
  }

  public TResult? Value { get; set; }
  public bool IsSuccessful { get; set; }
  public IEnumerable<TError>? Errors { get; set; }
}