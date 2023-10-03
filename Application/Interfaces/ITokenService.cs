using Application.Dtos.Identity;

namespace Application.Interfaces;

public interface ITokenService
{
  string CreateToken(AppUserDto user);
}