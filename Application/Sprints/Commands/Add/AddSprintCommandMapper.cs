using Domain.Entities;

namespace Application.Sprints.Commands.Add;

public static class AddSprintCommandMapper
{
  public static Sprint ToEntity(this AddSprintCommand sprintCommand)
  {
    return new Sprint
    {
      Title = sprintCommand.Title,
      Start = sprintCommand.Start,
      End = sprintCommand.End
    };
  }
}