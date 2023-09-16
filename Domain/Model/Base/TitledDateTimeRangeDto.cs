namespace Domain.Model.Base;

public class TitledDateTimeRangeDto : TitledDto
{
  public DateTime Start { get; set; }
  public DateTime End { get; set; }
}