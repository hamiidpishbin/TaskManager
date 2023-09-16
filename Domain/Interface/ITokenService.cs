using Application.Models;

namespace Application.Interfaces;

public interface ITokenService
{
    string CreateToken(AppUserDto user);
}