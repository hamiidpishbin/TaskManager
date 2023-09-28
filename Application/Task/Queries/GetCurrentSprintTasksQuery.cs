using Application.Common.Interfaces.Infrastructure;
using Application.Common.Models;
using Application.Sprint.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Task.Queries;

public record GetCurrentSprintTasksQuery : IRequest<Result<IEnumerable<TaskDto>>>;

public class
  GetCurrentSprintTasksQueryHandler : IRequestHandler<GetCurrentSprintTasksQuery,
    Result<IEnumerable<TaskDto>>>
{
  private readonly IApplicationDbContext _context;
  private readonly ISender _mediator;

  public GetCurrentSprintTasksQueryHandler(ISender mediator, IApplicationDbContext context)
  {
    _mediator = mediator;
    _context = context;
  }

  public async Task<Result<IEnumerable<TaskDto>>> Handle(GetCurrentSprintTasksQuery request, CancellationToken cancellationToken)
  {
    var currentSprint = await _mediator.Send(new GetCurrentSprintQuery(), CancellationToken.None);

    var result = await _context.Tasks.Where(t => t.SprintId == currentSprint.Id).ToListAsync(CancellationToken.None);

    return Result<IEnumerable<TaskDto>>.Success(result.ToDto());
  }
}