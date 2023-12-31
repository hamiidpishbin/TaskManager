using System.ComponentModel;

namespace Domain.Extensions;

public static class EnumExtensions
{
  public static string GetDescription(this Enum value)
  {
    var attribute = value.GetAttribute<DescriptionAttribute>();
    return attribute is null
      ? value.ToString()
      : attribute.Description;
  }

  private static T GetAttribute<T>(this Enum value) where T : Attribute
  {
    var type = value.GetType();
    var memberInfo = type.GetMember(value.ToString());
    var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
    return (attributes.Length > 0
      ? (T)attributes[0]
      : null)!;
  }
}