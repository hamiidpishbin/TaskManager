using Application.Common.Interfaces.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Sprint.Queries;

public record GetCurrentSprintQuery : IRequest<Domain.Entities.Sprint>;

public class
  GetCurrentSprintQueryHandler : IRequestHandler<GetCurrentSprintQuery, Domain.Entities.Sprint>
{
  private readonly IApplicationDbContext _context;

  public GetCurrentSprintQueryHandler(IApplicationDbContext context)
  {
    _context = context;
  }

  public async Task<Domain.Entities.Sprint> Handle(GetCurrentSprintQuery request,
    CancellationToken cancellationToken)
  {
    return (await _context.Sprints.FirstOrDefaultAsync(
      s => s.Start >= DateTime.Now && s.End <= DateTime.Now, CancellationToken.None))!;
  }
}