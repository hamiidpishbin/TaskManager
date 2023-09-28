using Application.Sprint.Commands.AddSprint;
using Application.Sprint.Queries;
using Application.Task;

namespace Application.Sprint;

internal static class SprintMapper
{
  public static Domain.Entities.Sprint ToEntity(this AddSprintCommand sprintCommand)
  {
    return new Domain.Entities.Sprint
    {
      Title = sprintCommand.Title,
      Start = sprintCommand.Start,
      End = sprintCommand.End
    };
  }

  public static SprintDto ToDto(this Domain.Entities.Sprint sprint)
  {
    return new SprintDto()
    {
      Title = sprint.Title,
      Start = sprint.Start,
      End = sprint.End,
      Tasks = sprint.Tasks.ToDto(),
    };
  }

  public static IEnumerable<SprintDto> ToDto(this IEnumerable<Domain.Entities.Sprint> sprints)
  {
    return sprints.Select(sprint => sprint.ToDto());
  }
}