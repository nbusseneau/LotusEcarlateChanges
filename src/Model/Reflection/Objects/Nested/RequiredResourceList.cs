using System.Collections;
using System.Reflection;
using HarmonyLib;

namespace LotusEcarlateChanges.Model.Reflection.Objects.Nested;

public class RequiredResourceList(object obj)
{
  private readonly object _object = obj;
  private readonly MethodInfo _addMethod = AccessTools.Method(obj.GetType(), "Add", [typeof(string), typeof(int), typeof(int)]);
  private readonly IList _requirements = (IList)AccessTools.Field(obj.GetType(), "Requirements").GetValue(obj);

  public void Add(string itemName, int amount, int quality = 0) => this._addMethod.Invoke(this._object, [itemName, amount, quality]);
  public void Clear() => this._requirements.Clear();
}
