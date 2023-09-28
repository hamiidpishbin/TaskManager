using Application.Common.Interfaces.Infrastructure;
using Application.Common.Models;
using Domain.Models.Account;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Account.Queries.Login;

public record LoginQuery : IRequest<Result<UserDto>>
{
  public string Email { get; init; }
  public string Password { get; init; }
}

public class LoginQueryHandler : IRequestHandler<LoginQuery, Result<UserDto>>
{
  private readonly IIdentityService _identityService;

  public LoginQueryHandler(IIdentityService identityService)
  {
    _identityService = identityService;
  }

  public async Task<Result<UserDto>> Handle(LoginQuery request, CancellationToken cancellationToken)
  {
    return await _identityService.LoginAsync(request);
  }
}