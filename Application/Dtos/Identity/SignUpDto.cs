namespace Infrastructure.Dtos.Identity;

public record SignUpDto
{
  public string UserName { get; init; }
  public string DisplayName { get; init; }
  public string Email { get; init; }
  public string Password { get; init; }
}