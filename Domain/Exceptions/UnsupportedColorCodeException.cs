namespace Domain.Exceptions
{
  public class UnsupportedColorCodeException : Exception
  {
    public UnsupportedColorCodeException(string colorCode) : base($"Color Code {colorCode} Is Not Supported")
    {
    }
  }
}