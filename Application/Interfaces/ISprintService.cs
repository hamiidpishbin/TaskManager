using Application.Common.Models;
using Application.Dtos.Sprint;

namespace Application.Interfaces;

public interface ISprintService
{
  Task<Result<IEnumerable<SprintDto>>> GetSprintsAsync();
  Task<Domain.Entities.Sprint> GetCurrentSprintAsync();
  Task<Result<SprintDto>> GetCurrentSprintDtoAsync();
  Task<Result<bool>> AddSprintAsync(AddSprintDto addSprintDto);
}