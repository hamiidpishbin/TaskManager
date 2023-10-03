using System.ComponentModel;

namespace Domain.Enums;

public enum IdentityResult
{
  Done = 1,

  [Description("Email Is Already Taken")]
  EmailIsTaken,

  [Description("Username Is Already Taken")]
  UserNameIsTaken,

  [Description("Login Credentials Are Not Correct")]
  IncorrectLoginCredentials
}