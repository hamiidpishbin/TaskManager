using Domain.Entity;
using Domain.Model.Sprint;
using Task = System.Threading.Tasks.Task;

namespace Domain.Interface;

public interface ISprintService
{
    Task AddNewSprint(SprintSaveDateTimeRangeDto sprintSaveDateTimeRangeDto);
    Task<Sprint> GetCurrentSprint();
}