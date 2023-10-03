using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Common;

public class AppUser : IdentityUser
{
  public string DisplayName { get; set; }
}