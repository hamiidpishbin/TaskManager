using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Account;


public class SignupDto
{
  [Required]
  public string UserName { get; set; }
  
  [Required]
  public string DisplayName { get; set; }

  [Required]
  [EmailAddress]
  public string Email { get; set; }

  [Required]
  // [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{4,8}$")]
  public string Password { get; set; }
}