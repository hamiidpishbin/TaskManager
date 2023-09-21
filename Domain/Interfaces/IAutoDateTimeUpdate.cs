namespace Domain.Interface;

public interface IAutoDateTimeUpdate
{
  DateTime? Start { get; set; }
  DateTime? End { get; set; }
}