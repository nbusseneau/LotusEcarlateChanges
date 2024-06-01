using System.Linq;

namespace LotusEcarlateChanges.Extensions;

public static class GenericTypeExtensions
{
  public static void CopyProperties<T>(this T targetObject, T sourceObject)
  {
    foreach (var property in targetObject.GetType().GetProperties().Where(p => p.CanWrite))
    {
      property.SetValue(targetObject, property.GetValue(sourceObject));
    }
  }
}
