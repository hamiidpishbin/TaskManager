using Application.Sprints.Queries;
using Domain.Entity;
using Domain.Model.Sprint;

namespace Application.Common.Mappings;

public static class SprintMapper
{
  public static SprintDto ToDto(this Sprint sprint)
  {
    return new SprintDto()
    {
      Title = sprint.Title,
      Start = sprint.Start,
      End = sprint.End,
      Tasks = sprint.Tasks.ToDto(),
    };
  }

  public static IEnumerable<SprintDto> ToDto(this IEnumerable<Sprint> sprints)
  {
    return sprints.Select(sprint => sprint.ToDto());
  }
}