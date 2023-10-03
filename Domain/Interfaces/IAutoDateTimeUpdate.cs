namespace Domain.Interfaces;

public interface IAutoDateTimeUpdate
{
  DateTime? Start { get; set; }
  DateTime? End { get; set; }
}