using System.Collections;
using System.Reflection;
using HarmonyLib;

namespace LotusEcarlateChanges.Model.Reflection.Objects.Nested;

public class CraftingStationList(object obj)
{
  private readonly object _object = obj;
  private readonly MethodInfo _addMethod = AccessTools.GetDeclaredMethods(obj.GetType())[0];
  private readonly IList _stations = (IList)AccessTools.Field(obj.GetType(), "Stations").GetValue(obj);

  public void Add(int table, int level = 1) => this._addMethod.Invoke(this._object, [table, level]);
  public void Clear() => this._stations.Clear();
}
