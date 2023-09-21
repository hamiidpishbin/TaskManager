using Application.Common.Interfaces.Infrastructure;
using Application.Common.Interfaces.Web;
using Application.Common.Mappings;
using Domain.Interface;
using Domain.Model.Task;
using Infrastructure.Data;
using Infrastructure.Mappings;
using Task = System.Threading.Tasks.Task;

namespace Web.Services;

public class TaskService : ITaskService
{
  private readonly ISprintService _sprintService;
  private readonly IApplicationDbContext _context;

  public TaskService(ISprintService sprintService, IApplicationDbContext context)
  {
    _sprintService = sprintService;
    _context = context;
  }

  public async Task AddTask(AddTaskDto addTaskDto)
  {
    _context.Tasks.Add(addTaskDto.ToEntity());
    await _context.SaveChangesAsync();
  }
  
  public async Task<List<Domain.Entities.Task>> GetCurrentSprintTasks()
  {
    var currentSprint = await _sprintService.GetCurrentSprint();
    return _context.Tasks.Where(t => t.Id == currentSprint.Id).ToList();
  }
}