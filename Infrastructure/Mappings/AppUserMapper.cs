using Application.Models;
using Infrastructure.Identity;

namespace Infrastructure.Mappings;

public static class AppUserMapper
{
  public static AppUserDto ToDto(this AppUser user)
  {
    return new AppUserDto
    {
      Id = user.Id,
      UserName = user.UserName,
      Email = user.Email,
    };
  }
}