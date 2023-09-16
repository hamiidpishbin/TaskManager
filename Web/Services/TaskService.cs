using Domain.Entity;
using Domain.Interface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace Web.Services;

public class TaskService : ITaskService
{
  private readonly ISprintService _sprintService;
  private readonly ApplicationDbContext _context;

  public TaskService(ISprintService sprintService, ApplicationDbContext context)
  {
    _sprintService = sprintService;
    _context = context;
  }
  
  public async Task<List<Domain.Entity.Task>> GetCurrentSprintTasks()
  {
    var currentSprint = await _sprintService.GetCurrentSprint();
    
    return await Task.Run(() => _context.Tasks.Where(t => t.Id == currentSprint.Id).ToList());
  }
}