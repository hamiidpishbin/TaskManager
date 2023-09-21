using Application.Common.Interfaces.Web;
using Domain.Interface;

namespace Web.Services;

public class DailyTaskService
{
  private readonly ISprintService _sprintService;

  public DailyTaskService(ISprintService sprintService)
  {
    _sprintService = sprintService;
  }
  
  public async Task GetCurrentSprintDailyTasks(Guid sprintId)
  {
   var currentSprint = await _sprintService.GetCurrentSprint();
   
   
  }
}