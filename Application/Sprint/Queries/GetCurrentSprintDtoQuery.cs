using Application.Common.Interfaces.Infrastructure;
using Application.Common.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Sprint.Queries;

public record GetCurrentSprintDtoQuery : IRequest<Result<SprintDto>>;

public class
  GetCurrentSprintDtoQueryHandler : IRequestHandler<GetCurrentSprintDtoQuery, Result<SprintDto>>
{
  private readonly ISender _mediator;

  public GetCurrentSprintDtoQueryHandler(ISender mediator)
  {
    _mediator = mediator;
  }

  public async Task<Result<SprintDto>> Handle(GetCurrentSprintDtoQuery request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new GetCurrentSprintQuery(), CancellationToken.None);

    return result is null
      ? Result<SprintDto>.Failure("Sprint Was Not Found")
      : Result<SprintDto>.Success(result.ToDto());
  }
}