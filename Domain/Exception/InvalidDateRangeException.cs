namespace Domain.Exceptions;

public class InvalidDateRangeException : Exception
{
  public InvalidDateRangeException(DateTime start, DateTime end) : base(
    $"Start Date {start} Should Smaller Than End Date {end}")
  {
  }
}