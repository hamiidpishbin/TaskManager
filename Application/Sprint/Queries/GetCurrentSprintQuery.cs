using Application.Common.Interfaces.Infrastructure;
using Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Sprint.Queries;

public record GetCurrentSprintQuery : IRequest<Result<SprintDto>>;

public class
  GetCurrentSprintQueryHandler : IRequestHandler<GetCurrentSprintQuery, Result<SprintDto>>
{
  private readonly IApplicationDbContext _context;

  public GetCurrentSprintQueryHandler(IApplicationDbContext context)
  {
    _context = context;
  }

  public async Task<Result<SprintDto>> Handle(GetCurrentSprintQuery request,
    CancellationToken cancellationToken)
  {
    var result = await _context.Sprints.FirstOrDefaultAsync(
      s => s.Start >= DateTime.Now && s.End <= DateTime.Now, CancellationToken.None);
    return result is null
      ? Result<SprintDto>.Success(new SprintDto())
      : Result<SprintDto>.Success(result.ToDto());
  }
}