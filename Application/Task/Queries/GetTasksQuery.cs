using MediatR;

namespace Application.Task.Queries;

public record GetTasksQuery : IRequest<List<TaskDto>>;

public class GetTasksQueryHandler : IRequestHandler<GetTasksQuery, List<TaskDto>>
{
  public Task<List<TaskDto>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
  {
    return System.Threading.Tasks.Task.FromResult(new List<TaskDto>());
  }
}