using Domain.Entities;
using Domain.Model.Sprint;
using Task = System.Threading.Tasks.Task;

namespace Application.Common.Interfaces.Web;

public interface ISprintService
{
    Task<Sprint> GetCurrentSprint();
    Task AddSprint(AddSprintDto addSprintDto);
}