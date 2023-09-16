using Domain.Entity;
using Domain.Model.Sprint;
using Domain.Models.Sprint;

namespace Infrastructure.Mapping;

public static class SprintMapper
{
  public static Sprint ToEntity(this SprintSaveDateTimeRangeDto sprintSaveDateTimeRangeDto)
  {
    return new Sprint()
    {
      Title = sprintSaveDateTimeRangeDto.Title,
      Start = sprintSaveDateTimeRangeDto.Start,
      End = sprintSaveDateTimeRangeDto.End
    };
  }
}