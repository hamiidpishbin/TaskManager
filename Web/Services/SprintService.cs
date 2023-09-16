using Domain.Entity;
using Domain.Interface;
using Domain.Model.Sprint;
using Infrastructure.Data;
using Infrastructure.Mapping;
using Task = System.Threading.Tasks.Task;

namespace Web.Services;

public class SprintService : ISprintService
{
  private readonly ApplicationDbContext _context;

  public SprintService(ApplicationDbContext context)
  {
    _context = context;
  }

  public async Task AddNewSprint(SprintSaveDateTimeRangeDto sprintSaveDateTimeRangeDto)
  {
    _context.Sprints.Add(sprintSaveDateTimeRangeDto.ToEntity());
    await _context.SaveChangesAsync();
  }

  public async Task<Sprint> GetCurrentSprint()
  {
    return await Task.Run(() =>
      _context.Sprints.First(sprint => sprint.Start < DateTime.Now && sprint.End > DateTime.Now));
  }
}