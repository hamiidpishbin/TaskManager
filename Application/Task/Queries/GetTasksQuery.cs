using MediatR;

namespace Application.Task.Queries;

public record GetTasksQuery : IRequest<List<UserTaskDto>>;

public class GetTasksQueryHandler : IRequestHandler<GetTasksQuery, List<UserTaskDto>>
{
  public Task<List<UserTaskDto>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
  {
    return System.Threading.Tasks.Task.FromResult(new List<UserTaskDto>());
  }
}