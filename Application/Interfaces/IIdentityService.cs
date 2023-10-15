using Application.Models;
using Application.Models.Identity;
using Domain.Common;

namespace Application.Interfaces;

public interface IIdentityService
{
  Task<ServiceResult<bool>> CreateUserAsync(SignUpDto signUpDto);
  Task<ServiceResult<UserDto>> LoginAsync(LoginDto loginDto);
  Task<AppUserDto> GetCurrentUser();
}