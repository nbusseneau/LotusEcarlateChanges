using System.Reflection;
using HarmonyLib;

namespace LotusEcarlateChanges.Model.Reflection.Objects.Nested;

public class LocalizeKey(object obj)
{
  private readonly object _object = obj;
  private readonly MethodInfo _aliasMethod = AccessTools.Method(obj.GetType(), "Alias");
  private readonly MethodInfo _englishMethod = AccessTools.Method(obj.GetType(), "English");
  private readonly MethodInfo _frenchMethod = AccessTools.Method(obj.GetType(), "French");

  public void Alias(string key) => this._aliasMethod.Invoke(this._object, [key]);
  public void English(string key) => this._englishMethod.Invoke(this._object, [key]);
  public void French(string key) => this._frenchMethod.Invoke(this._object, [key]);
}
