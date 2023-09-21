using Application.Common.Interfaces.Infrastructure;
using Application.Common.Models;
using Domain.Enums.Results;
using MediatR;

namespace Application.Account.Commands.CreateAccount;

public record CreateAccountCommand : IRequest<Result<AccountResult>>
{
  public string UserName { get; init; }
  public string DisplayName { get; init; }
  public string Email { get; init; }
  public string Password { get; init; }
}

public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, Result<AccountResult>>
{
  private readonly IIdentityService _identityService;

  public CreateAccountCommandHandler(IIdentityService identityService)
  {
    _identityService = identityService;
  }

  public async Task<Result<AccountResult>> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
  {
    var validator = new CreateAccountCommandValidator();
    var validationResult = validator.Validate(request);
    if (!validationResult.IsValid)
    {
      return Result<AccountResult>.Failure(validationResult.ToString());
    }

    return await _identityService.CreateUserAsync(request);
  }
}