using Application.Account.Commands.CreateAccount;
using Application.Account.Queries.Login;
using Application.Common.Interfaces.Infrastructure;
using Domain.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Base;

namespace Web.Controllers;

[AllowAnonymous]
public class AccountController : BaseApiController
{
  private readonly IIdentityService _identityService;

  public AccountController(IIdentityService identityService)
  {
    _identityService = identityService;
  }

  [HttpPost("Login")]
  public async Task<IActionResult> Login(LoginQuery loginQuery)
  {
    var result = await Mediator.Send(loginQuery);
    return HandleResult(result);
  }

  [HttpPost("Signup")]
  public async Task<IActionResult> Signup(CreateAccountCommand request)
  {
    var result = await Mediator.Send(request);
    return HandleResult(result);
  }
}