using Domain.Entity;
using Domain.Model.Sprint;
using Task = System.Threading.Tasks.Task;

namespace Domain.Interface;

public interface ISprintService
{
    Task<Sprint> GetCurrentSprint();
    Task AddSprint(AddSprintDto addSprintDto);
}