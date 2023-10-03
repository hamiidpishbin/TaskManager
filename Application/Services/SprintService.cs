using Application.Common.Interfaces.Infrastructure;
using Application.Common.Models;
using Application.Dtos.Sprint;
using Application.Interfaces;
using AutoMapper;
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

  public async Task<Result<IEnumerable<SprintDto>>> GetSprintsAsync()
  {
    var sprints = await _context.Sprints.Include(s => s.Tasks).ToListAsync(CancellationToken.None);
    var result = _mapper.Map<IEnumerable<SprintDto>>(sprints);
    return Result<IEnumerable<SprintDto>>.Success(result);
  }

  public async Task<Domain.Entities.Sprint> GetCurrentSprintAsync()
  {
    return (await _context.Sprints.FirstOrDefaultAsync(
      s => s.Start >= DateTime.Now && s.End <= DateTime.Now, CancellationToken.None))!;
  }

  public async Task<Result<SprintDto>> GetCurrentSprintDtoAsync()
  {
    var sprint = await GetCurrentSprintAsync();
    var result = _mapper.Map<SprintDto>(sprint);

    return result is null
      ? Result<SprintDto>.Failure("Sprint Was Not Found")
      : Result<SprintDto>.Success(result);
  }

  public async Task<Result<bool>> AddSprintAsync(AddSprintDto addSprintDto)
  {
    var sprint = _mapper.Map<Domain.Entities.Sprint>(addSprintDto);
    _context.Sprints.Add(sprint);
    var result = await _context.SaveChangesAsync(CancellationToken.None) > 0;
    return result
      ? Result<bool>.Success(true)
      : Result<bool>.Failure("Failed to Add Sprint");
  }
}