using Application.Models;
using Application.Models.Sprint;
using Domain.Common;

namespace Application.Interfaces;

public interface ISprintService
{
  Task<ServiceResult<IEnumerable<SprintDto>>> GetSprintsAsync();
  Task<Domain.Entities.Sprint> GetCurrentSprintAsync();
  Task<ServiceResult<SprintDto>> GetCurrentSprintDtoAsync();
  Task<ServiceResult<bool>> AddSprintAsync(AddSprintDto addSprintDto);
}