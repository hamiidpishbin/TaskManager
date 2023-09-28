using Application.Account.Commands.CreateAccount;
using Application.Account.Queries.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Base;

namespace Web.Controllers;

[AllowAnonymous]
public class AccountController : BaseApiController
{
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