using Application.Models;
using Application.Models.Identity;
using Domain.Common;

namespace Application.Interfaces;

public interface IIdentityService
{
  Task<OldResult<bool>> CreateUserAsync(SignUpDto signUpDto);
  Task<OldResult<UserDto>> LoginAsync(LoginDto loginDto);
  Task<AppUserDto> GetCurrentUser();
}