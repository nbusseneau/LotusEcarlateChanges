using System.Collections;
using System.Reflection;
using HarmonyLib;

namespace LotusEcarlateChanges.Model.Reflection.Objects.Nested;

public class DropTargets(object obj)
{
  private readonly object _object = obj;
  private readonly MethodInfo _addMethod = AccessTools.Method(obj.GetType(), "Add");
  private readonly IList _drops = (IList)AccessTools.Field(obj.GetType(), "Drops").GetValue(obj);

  public void Add(string creatureName, float chance, int min = 1, int? max = null, bool levelMultiplier = true) => this._addMethod.Invoke(this._object, [creatureName, chance, min, max, levelMultiplier]);
  public void Clear() => this._drops.Clear();
}
