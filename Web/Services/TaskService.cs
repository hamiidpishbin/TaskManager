using Application.Common.Interfaces.Infrastructure;
using Application.Common.Interfaces.Web;
using Application.Task;
using Domain.Entities;
using Domain.Interface;
using Domain.Model.Task;
using Infrastructure.Data;
using Infrastructure.Mappings;
using Task = System.Threading.Tasks.Task;

namespace Web.Services;

public class TaskService : ITaskService
{
  private readonly IApplicationDbContext _context;

  public TaskService(IApplicationDbContext context)
  {
    _context = context;
  }

  public async Task AddTask(AddTaskDto addTaskDto)
  {
    _context.Tasks.Add(addTaskDto.ToEntity());
    await _context.SaveChangesAsync();
  }

  public async Task<List<UserTask>> GetCurrentSprintTasks()
  {
    // var currentSprint = await _sprintService.GetCurrentSprint();
    // return _context.Tasks.Where(t => t.Id == currentSprint.Id).ToList();
    return await Task.FromResult(new List<UserTask>());
  }
}