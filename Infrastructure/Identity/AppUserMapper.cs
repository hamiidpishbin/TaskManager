using Application.Models;

namespace Infrastructure.Identity;

public static class AppUserMapper
{
  public static AppUserDto ToDto(this AppUser appUser)
  {
    return new AppUserDto
    {
      Id = appUser.Id,
      UserName = appUser.UserName,
      Email = appUser.Email,
    };
  }
}