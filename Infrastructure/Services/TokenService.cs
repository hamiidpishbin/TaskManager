using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Common.Interfaces.Web;
using Application.Dtos.Identity;
using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Domain.Model;
using Infrastructure.Common;
using Infrastructure.Dtos.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Web.Services;

public class TokenService : ITokenService
{
  private readonly IConfiguration _config;

  public TokenService(IConfiguration config)
  {
    _config = config;
  }

  public string CreateToken(AppUserDto user)
  {
    var claims = new List<Claim>
    {
      new Claim(ClaimTypes.Name, user.UserName),
      new Claim(ClaimTypes.NameIdentifier, user.Id),
      new Claim(ClaimTypes.Email, user.Email),
    };

    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["TokenKey"]));
    var credits = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

    var tokenDescriptor = new SecurityTokenDescriptor
    {
      Subject = new ClaimsIdentity(claims),
      Expires = DateTime.Now.AddDays(7),
      SigningCredentials = credits,
    };

    var tokenHandler = new JwtSecurityTokenHandler();
    var token = tokenHandler.CreateToken(tokenDescriptor);

    return tokenHandler.WriteToken(token);
  }
}