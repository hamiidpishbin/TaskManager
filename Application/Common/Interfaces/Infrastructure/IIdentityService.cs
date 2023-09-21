using Application.Common.Models;
using Application.Models;
using Domain.Models.Account;

namespace Application.Common.Interfaces.Infrastructure;

public interface IIdentityService
{ 
    Task<Result<UserDto>> CreateUserAsync(SignupDto signupDto);
    Task<Result<UserDto>> LoginAsync(LoginDto loginDto);
}