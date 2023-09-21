using Application.Common.Interfaces.Infrastructure;
using Application.Common.Interfaces.Web;
using Domain.Entities;
using Domain.Model.Sprint;
using Task = System.Threading.Tasks.Task;

namespace Web.Services;

public class SprintService : ISprintService
{
  private readonly IApplicationDbContext _context;

  public SprintService(IApplicationDbContext context)
  {
    _context = context;
  }

  public async Task AddSprint(AddSprintDto addSprintDto)
  {
    // _context.Sprints.Add(addSprintDto.ToEntity());
    // await _context.SaveChangesAsync();
  }

  public async Task<Sprint> GetCurrentSprint()
  {
    return await Task.Run(() =>
      _context.Sprints.First(sprint => sprint.Start < DateTime.Now && sprint.End > DateTime.Now));
  }
}