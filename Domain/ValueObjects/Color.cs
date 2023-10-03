using Domain.Exceptions;

namespace Domain.ValueObjects;

public class Color
{
  public Color(string colorCode)
  {
    ColorCode = colorCode;

    if (!IsValidColorCode())
    {
      throw new UnsupportedColorCodeException(colorCode);
    }
  }

  public string ColorCode { get; }

  private bool IsValidColorCode()
  {
    return ColorCode.StartsWith('#');
  }
}