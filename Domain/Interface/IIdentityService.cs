using Application.Models;
using Domain.Models.Account;

namespace Application.Interfaces;

public interface IIdentityService
{ 
    Task<Result<UserDto>> CreateUserAsync(SignupDto signupDto);
    Task<Result<UserDto>> LoginAsync(LoginDto loginDto);
}