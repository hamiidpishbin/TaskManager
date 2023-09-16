using Application.Interfaces;
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
	public async Task<IActionResult> Login(LoginDto loginDto)
	{
		var result = await _identityService.LoginAsync(loginDto);
		return HandleResult(result);
	}

	[HttpPost("Signup")]
	public async Task<IActionResult> Signup(SignupDto signupDto)
	{
		var result = await _identityService.CreateUserAsync(signupDto);
		return HandleResult(result);
	}
}