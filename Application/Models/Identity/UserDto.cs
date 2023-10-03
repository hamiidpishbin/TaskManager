namespace Application.Models.Identity;

public class UserDto
{
  public string DisplayName { get; set; }
  public string Token { get; set; }
  public string? Image { get; set; }
}