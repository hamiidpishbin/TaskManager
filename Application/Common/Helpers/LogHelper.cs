namespace Application.Common.Helpers;

public class LogHelper
{
  public static string GetFailureLog(string detail)
  {
    return $"Failed to {detail}";
  }
}