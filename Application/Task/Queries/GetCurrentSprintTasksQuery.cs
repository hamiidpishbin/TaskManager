using Application.Common.Interfaces.Infrastructure;
using Application.Common.Models;
using Application.Sprint.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Task.Queries;

public record GetCurrentSprintTasksQuery : IRequest<Result<IEnumerable<UserTaskDto>>>;

public class
  GetCurrentSprintTasksQueryHandler : IRequestHandler<GetCurrentSprintTasksQuery,
    Result<IEnumerable<UserTaskDto>>>
{
  private readonly IApplicationDbContext _context;
  private readonly ISender _mediator;

  public GetCurrentSprintTasksQueryHandler(ISender mediator, IApplicationDbContext context)
  {
    _mediator = mediator;
    _context = context;
  }

  public async Task<Result<IEnumerable<UserTaskDto>>> Handle(GetCurrentSprintTasksQuery request, CancellationToken cancellationToken)
  {
    var currentSprint = await _mediator.Send(new GetCurrentSprintQuery(), CancellationToken.None);

    if (currentSprint is null)
    {
      return Result<IEnumerable<UserTaskDto>>.Failure("Current Sprint Was Not Found");
    }

    var result = await _context.Tasks.Where(t => t.SprintId == currentSprint.Id).ToListAsync(CancellationToken.None);

    return Result<IEnumerable<UserTaskDto>>.Success(result.ToDto());
  }
}