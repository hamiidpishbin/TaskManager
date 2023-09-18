using MediatR;

namespace Application.Tasks.Queries;

public record GetTasksQuery : IRequest<List<TaskDto>>;

public class GetTasksQueryHandler : IRequestHandler<GetTasksQuery, List<TaskDto>>
{
  public Task<List<TaskDto>> Handle(GetTasksQuery request, CancellationToken cancellationToken)
  {
    return Task.FromResult(new List<TaskDto>());
  }
}