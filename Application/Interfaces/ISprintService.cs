using Application.Models;
using Application.Models.Sprint;
using Domain.Common;

namespace Application.Interfaces;

public interface ISprintService
{
  Task<OldResult<IEnumerable<SprintDto>>> GetSprintsAsync();
  Task<Domain.Entities.Sprint> GetCurrentSprintAsync();
  Task<OldResult<SprintDto>> GetCurrentSprintDtoAsync();
  Task<OldResult<bool>> AddSprintAsync(AddSprintDto addSprintDto);
}