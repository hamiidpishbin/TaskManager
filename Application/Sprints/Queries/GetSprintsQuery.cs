using Application.Common.Mappings;
using Domain.Interface.Infrastructure;
using Domain.Model.Sprint;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Sprints.Queries;

public record GetSprintsQuery : IRequest<IEnumerable<SprintDto>>;

public class GetSprintsQueryHandler : IRequestHandler<GetSprintsQuery, IEnumerable<SprintDto>>
{
  private readonly IApplicationDbContext _context;

  public GetSprintsQueryHandler(IApplicationDbContext context)
  {
    _context = context;
  }
  
  public async Task<IEnumerable<SprintDto>> Handle(GetSprintsQuery request, CancellationToken cancellationToken)
  {
    var result = await _context.Sprints.Include(s => s.Tasks).ToListAsync(CancellationToken.None);
    return result.ToDto();
  }
}