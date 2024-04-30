using System.Reflection;
using HarmonyLib;

namespace LotusEcarlateChanges.Model.Reflection.Objects.Nested;

public class PieceTool(object obj)
{
  private readonly object _object = obj;
  private readonly MethodInfo _addMethod = AccessTools.Method(obj.GetType(), "Add");

  public void Add(string tool) => this._addMethod.Invoke(this._object, [tool]);
}
