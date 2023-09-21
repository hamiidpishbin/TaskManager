using Application.Common.Interfaces.Infrastructure;
using Application.Common.Interfaces.Web;
using Application.Common.Models;
using Application.Models;
using Domain.Constants;
using Domain.Interfaces;
using Domain.Models.Account;
using Infrastructure.Mappings;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Identity;

public class IdentityService : IIdentityService
{
  private readonly UserManager<AppUser> _userManager;
  private readonly ITokenService _tokenService;
  private readonly SignInManager<AppUser> _signInManager;

  public IdentityService(UserManager<AppUser> userManager, ITokenService tokenService,
    SignInManager<AppUser> signInManager)
  {
    _userManager = userManager;
    _tokenService = tokenService;
    _signInManager = signInManager;
  }

  public async Task<Result<UserDto>> LoginAsync(LoginDto loginDto)
  {
    var user = await _userManager.FindByEmailAsync(loginDto.Email);

    if (user == null)
    {
      return Result<UserDto>.Failure(IdentityFailureReasons.Unauthorized);
    }

    var signInResult = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

    return signInResult.Succeeded
      ? Result<UserDto>.Success(GetUserDto(user))
      : Result<UserDto>.Failure(IdentityFailureReasons.Unauthorized);
  }

  public async Task<Result<UserDto>> CreateUserAsync(SignupDto signupDto)
  {
    var userNameIsTaken = await _userManager.Users.AnyAsync(user => user.UserName == signupDto.UserName);
    var emailIsTaken = await _userManager.Users.AnyAsync(user => user.Email == signupDto.Email);

    if (userNameIsTaken)
    {
      return Result<UserDto>.Failure(IdentityFailureReasons.UsernameTaken);
    }

    if (emailIsTaken)
    {
      return Result<UserDto>.Failure(IdentityFailureReasons.EmailTaken);
    }

    var user = new AppUser
    {
      UserName = signupDto.UserName,
      Email = signupDto.Email,
      DisplayName = signupDto.DisplayName
    };

    var createdUser = await _userManager.CreateAsync(user, signupDto.Password);

    return createdUser is not { Succeeded: true }
      ? Result<UserDto>.Failure(IdentityFailureReasons.UnknownError)
      : Result<UserDto>.Success(GetUserDto(user));
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