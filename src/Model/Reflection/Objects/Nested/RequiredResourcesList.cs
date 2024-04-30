using System.Collections;
using System.Reflection;
using HarmonyLib;

namespace LotusEcarlateChanges.Model.Reflection.Objects.Nested;

public class RequiredResourcesList(object obj)
{
  private readonly object _object = obj;
  private readonly MethodInfo _addMethod = AccessTools.Method(obj.GetType(), "Add");
  private readonly IList _requirements = (IList)AccessTools.Field(obj.GetType(), "Requirements").GetValue(obj);

  public void Add(string itemName, int amount, bool recover = true) => this._addMethod.Invoke(this._object, [itemName, amount, recover]);
  public void Clear() => this._requirements.Clear();
}
