using Application.Models;
using Application.Models.Identity;

namespace Application.Interfaces;

public interface IIdentityService
{
  Task<Result<bool>> CreateUserAsync(SignUpDto signUpDto);
  Task<Result<UserDto>> LoginAsync(LoginDto loginDto);
  Task<AppUserDto> GetCurrentUser();
}