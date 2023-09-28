using Application.Common.Helpers;
using Application.Common.Interfaces.Infrastructure;
using Application.Common.Models;
using MediatR;

namespace Application.Task.Commands.Add;

public record AddTaskCommand : IRequest<Result<Unit>>
{
  public Guid SprintId { get; init; }
  public string Title { get; init; }
}

public class AddTaskCommandHandler : IRequestHandler<AddTaskCommand, Result<Unit>>
{
  private readonly IApplicationDbContext _context;

  public AddTaskCommandHandler(IApplicationDbContext context)
  {
    _context = context;
  }

  public async Task<Result<Unit>> Handle(AddTaskCommand request,
    CancellationToken cancellationToken)
  {
    _context.Tasks.Add(request.ToEntity());
    var result = await _context.SaveChangesAsync(CancellationToken.None) > 0;
    return result
      ? Result<Unit>.Success(Unit.Value)
      : Result<Unit>.Failure(LogHelper.GetFailureLog("Add Task"));
  }
}