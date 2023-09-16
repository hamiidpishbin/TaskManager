using Domain.Entity;
using Domain.Model.Sprint;

namespace Infrastructure.Mapping;

public static class SprintMapper
{
  public static Sprint ToEntity(this AddSprintDto addSprintDto)
  {
    return new Sprint()
    {
      Title = addSprintDto.Title,
      Start = addSprintDto.Start,
      End = addSprintDto.End
    };
  }
}