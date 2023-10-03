using System.Security.Claims;
using Application.Interfaces;
using Application.Models;
using Application.Models.Identity;
using AutoMapper;
using Domain.Extensions;
using Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using IdentityResult = Domain.Enums.IdentityResult;

namespace Infrastructure.Services;

public class IdentityService : IIdentityService
{
  #region Private Methods

  private UserDto GetUserDto(AppUser user)
  {
    return new UserDto
    {
      DisplayName = user.DisplayName,
      Token = _tokenService.CreateToken(_mapper.Map<AppUserDto>(user))
    };
  }

  #endregion

  #region Ctor

  private readonly SignInManager<AppUser> _signInManager;
  private readonly IHttpContextAccessor _httpContextAccessor;
  private readonly IMapper _mapper;
  private readonly ITokenService _tokenService;
  private readonly UserManager<AppUser> _userManager;

  public IdentityService(UserManager<AppUser> userManager,
    ITokenService tokenService,
    SignInManager<AppUser> signInManager,
    IHttpContextAccessor httpContextAccessor,
    IMapper mapper)
  {
    _userManager = userManager;
    _tokenService = tokenService;
    _signInManager = signInManager;
    _httpContextAccessor = httpContextAccessor;
    _mapper = mapper;
  }

  #endregion

  #region Public Methods

  public async Task<Result<UserDto>> LoginAsync(LoginDto loginDto)
  {
    var user = await _userManager.FindByEmailAsync(loginDto.Email);

    if (user == null)
    {
      return Result<UserDto>.Failure(IdentityResult.IncorrectLoginCredentials.GetDescription());
    }

    var signInResult = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

    return signInResult.Succeeded
      ? Result<UserDto>.Success(GetUserDto(user))
      : Result<UserDto>.Failure(IdentityResult.IncorrectLoginCredentials.GetDescription());
  }

  public async Task<Result<bool>> CreateUserAsync(SignUpDto signUpDto)
  {
    var userNameIsTaken = await _userManager.Users.AnyAsync(user => user.UserName == signUpDto.UserName);
    if (userNameIsTaken)
    {
      return Result<bool>.Failure(IdentityResult.UserNameIsTaken.GetDescription());
    }

    var emailIsTaken = await _userManager.Users.AnyAsync(user => user.Email == signUpDto.Email);
    if (emailIsTaken)
    {
      return Result<bool>.Failure(IdentityResult.EmailIsTaken.GetDescription());
    }

    var user = new AppUser
    {
      UserName = signUpDto.UserName,
      Email = signUpDto.Email,
      DisplayName = signUpDto.DisplayName
    };

    var createdUser = await _userManager.CreateAsync(user, signUpDto.Password);

    return createdUser is not { Succeeded: true }
      ? Result<bool>.Failure(createdUser.Errors.ToList().First().ToString())
      : Result<bool>.Success(true);
  }

  public async Task<AppUserDto> GetCurrentUser()
  {
    var currentUserEmail = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimValueTypes.Email);
    if (currentUserEmail is null) return new AppUserDto();
    var user = await _userManager.FindByEmailAsync(currentUserEmail);

    return _mapper.Map<AppUserDto>(user);
  }

  #endregion
}