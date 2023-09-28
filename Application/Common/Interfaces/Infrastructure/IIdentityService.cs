using Application.Account.Commands.CreateAccount;
using Application.Account.Queries.Login;
using Application.Common.Models;
using Domain.Enums.Results;
using Domain.Models.Account;

namespace Application.Common.Interfaces.Infrastructure;

public interface IIdentityService
{
  Task<Result<AccountResult>> CreateUserAsync(CreateAccountCommand request);
  Task<Result<UserDto>> LoginAsync(LoginQuery loginQuery);
}