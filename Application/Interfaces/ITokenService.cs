using Application.Models.Identity;

namespace Application.Interfaces;

public interface ITokenService
{
  string CreateToken(AppUserDto user);
}