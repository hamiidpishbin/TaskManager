using Application.Common.Interfaces.Infrastructure;
using Application.Common.Models;
using MediatR;

namespace Application.Sprints.Commands.Add;

public record AddSprintCommand : IRequest<Result<Unit>>
{
  public string Title { get; init; }
  public DateTime Start { get; init; }
  public DateTime End { get; init; }
}

public class AddSprintCommandHandler : IRequestHandler<AddSprintCommand, Result<Unit>>
{
  private readonly IApplicationDbContext _context;

  public AddSprintCommandHandler(IApplicationDbContext context)
  {
    _context = context;
  }

  public async Task<Result<Unit>> Handle(AddSprintCommand request, CancellationToken cancellationToken)
  {
    _context.Sprints.Add(request.ToEntity());
    var result = await _context.SaveChangesAsync(CancellationToken.None) > 0;
    return result ? Result<Unit>.Success(Unit.Value) : Result<Unit>.Failure("Failed to Add Sprint");
  }
}