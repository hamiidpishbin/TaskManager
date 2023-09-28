using Application.Account.Commands.CreateAccount;
using Application.Account.Queries.Login;
using Application.Common.Interfaces.Infrastructure;
using Application.Common.Interfaces.Web;
using Application.Common.Models;
using Application.Models;
using Domain.Constants;
using Domain.Enums.Results;
using Domain.Interfaces;
using Domain.Models.Account;
using Infrastructure.Mappings;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Identity;

public class IdentityService : IIdentityService
{
  private readonly SignInManager<AppUser> _signInManager;
  private readonly ITokenService _tokenService;
  private readonly UserManager<AppUser> _userManager;

  public IdentityService(UserManager<AppUser> userManager, ITokenService tokenService,
    SignInManager<AppUser> signInManager)
  {
    _userManager = userManager;
    _tokenService = tokenService;
    _signInManager = signInManager;
  }

  public async Task<Result<UserDto>> LoginAsync(LoginQuery loginQuery)
  {
    var user = await _userManager.FindByEmailAsync(loginQuery.Email);

    if (user == null)
    {
      return Result<UserDto>.Failure(IdentityFailureReasons.Unauthorized);
    }

    var signInResult = await _signInManager.CheckPasswordSignInAsync(user, loginQuery.Password, false);

    return signInResult.Succeeded
      ? Result<UserDto>.Success(GetUserDto(user))
      : Result<UserDto>.Failure(IdentityFailureReasons.Unauthorized);
  }

  public async Task<Result<AccountResult>> CreateUserAsync(CreateAccountCommand request)
  {
    var userNameIsTaken = await _userManager.Users.AnyAsync(user => user.UserName == request.UserName);
    var emailIsTaken = await _userManager.Users.AnyAsync(user => user.Email == request.Email);

    if (userNameIsTaken)
    {
      return Result<AccountResult>.Failure(GetEnumString(AccountResult.UserNameIsTaken));
    }

    if (emailIsTaken)
    {
      return Result<AccountResult>.Failure(GetEnumString(AccountResult.EmailIsTaken));
    }

    var user = new AppUser
    {
      UserName = request.UserName,
      Email = request.Email,
      DisplayName = request.DisplayName
    };

    var createdUser = await _userManager.CreateAsync(user, request.Password);

    return createdUser is not { Succeeded: true }
      ? Result<AccountResult>.Failure(IdentityFailureReasons.UnknownError)
      : Result<AccountResult>.Success(AccountResult.Done);
  }

  private string GetEnumString(Enum enumeration)
  {
    return Enum.GetName(enumeration.GetType(), enumeration)!;
  }

  private UserDto GetUserDto(AppUser user)
  {
    return new UserDto
    {
      DisplayName = user.DisplayName,
      Token = _tokenService.CreateToken(user.ToDto())
    };
  }
}