using Application.Common.Interfaces.Infrastructure;
using Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Sprint.Queries;

public record GetSprintsQuery : IRequest<Result<IEnumerable<SprintDto>>>;

public class
  GetSprintsQueryHandler : IRequestHandler<GetSprintsQuery, Result<IEnumerable<SprintDto>>>
{
  private readonly IApplicationDbContext _context;

  public GetSprintsQueryHandler(IApplicationDbContext context)
  {
    _context = context;
  }

  public async Task<Result<IEnumerable<SprintDto>>> Handle(GetSprintsQuery request,
    CancellationToken cancellationToken)
  {
    var result = await _context.Sprints.Include(s => s.Tasks).ToListAsync(CancellationToken.None);
    return Result<IEnumerable<SprintDto>>.Success(result.ToDto());
  }
}