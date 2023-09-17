using Domain.Interface;
using Domain.Interface.Infrastructure;
using Domain.Model.Task;
using Infrastructure.Data;
using Infrastructure.Mapping;
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
  
  public async Task<List<Domain.Entity.Task>> GetCurrentSprintTasks()
  {
    var currentSprint = await _sprintService.GetCurrentSprint();
    return _context.Tasks.Where(t => t.Id == currentSprint.Id).ToList();
  }
}