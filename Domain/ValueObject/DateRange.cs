using Domain.Exceptions;
using Domain.Interfaces;

namespace Domain.ValueObjects;

public class DateRange : IRange<DateTime>
{
  public DateTime Start { get; }
  public DateTime End { get; }

  public DateRange(DateTime start, DateTime end)
  {
    Start = start;
    End = end;

    if (!IsValidRange())
    {
      throw new InvalidDateRangeException(start, end);
    }
  }

  private bool IsValidRange()
  {
    return Start < End;
  }
}