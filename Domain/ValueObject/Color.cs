using Domain.Exceptions;

namespace Domain.ValueObjects;

public class Color
{
  public string ColorCode { get; }

  public Color(string colorCode)
  {
    ColorCode = colorCode;

    if (!IsValidColorCode())
    {
      throw new UnsupportedColorCodeException(colorCode);
    }
  }

  private bool IsValidColorCode()
  {
    return ColorCode.StartsWith('#');
  }
}