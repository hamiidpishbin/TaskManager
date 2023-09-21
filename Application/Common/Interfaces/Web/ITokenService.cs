using Application.Models;

namespace Application.Common.Interfaces.Web;

public interface ITokenService
{
    string CreateToken(AppUserDto user);
}