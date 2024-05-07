using System.Collections;
using System.Reflection;
using HarmonyLib;

namespace LotusEcarlateChanges.Model.Reflection.Objects.Nested;

public class BuildingPieceCraftingStationList(object obj)
{
  private readonly object _object = obj;
  private readonly MethodInfo _setMethod = AccessTools.GetDeclaredMethods(obj.GetType())[0];
  private readonly IList _stations = (IList)AccessTools.Field(obj.GetType(), "Stations").GetValue(obj);

  public void Set(int table) => this._setMethod.Invoke(this._object, [table]);
  public void Clear() => this._stations.Clear();
}
