using Application.Interfaces;
using Application.Models;
using Application.Models.Sprint;
using AutoMapper;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

public class SprintService : ISprintService
{
  private readonly IApplicationDbContext _context;
  private readonly IMapper _mapper;

  public SprintService(IApplicationDbContext context, IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
  }

  public async Task<OldResult<IEnumerable<SprintDto>>> GetSprintsAsync()
  {
    var sprints = await _context.Sprints.Include(s => s.Tasks).ToListAsync(CancellationToken.None);
    var result = _mapper.Map<IEnumerable<SprintDto>>(sprints);
    return OldResult<IEnumerable<SprintDto>>.Success(result);
  }

  public async Task<Domain.Entities.Sprint> GetCurrentSprintAsync()
  {
    return (await _context.Sprints.FirstOrDefaultAsync(
      s => s.Start >= DateTime.Now && s.End <= DateTime.Now, CancellationToken.None))!;
  }

  public async Task<OldResult<SprintDto>> GetCurrentSprintDtoAsync()
  {
    var sprint = await GetCurrentSprintAsync();
    var result = _mapper.Map<SprintDto>(sprint);

    return result is null
      ? OldResult<SprintDto>.Failure("Sprint Was Not Found")
      : OldResult<SprintDto>.Success(result);
  }

  public async Task<OldResult<bool>> AddSprintAsync(AddSprintDto addSprintDto)
  {
    var sprint = _mapper.Map<Domain.Entities.Sprint>(addSprintDto);
    _context.Sprints.Add(sprint);
    var result = await _context.SaveChangesAsync(CancellationToken.None) > 0;
    return result
      ? OldResult<bool>.Success(true)
      : OldResult<bool>.Failure("Failed to Add Sprint");
  }
}