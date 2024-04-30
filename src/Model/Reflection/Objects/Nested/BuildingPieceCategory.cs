using System.Reflection;
using HarmonyLib;

namespace LotusEcarlateChanges.Model.Reflection.Objects.Nested;

public class BuildingPieceCategory
{
  private readonly object _object;
  private readonly FieldInfo _category;
  private readonly FieldInfo _custom;
  private readonly MethodInfo _categorySetMethod;

  public BuildingPieceCategory(object obj)
  {
    this._object = obj;
    this._category = AccessTools.Field(obj.GetType(), "Category");
    this._custom = AccessTools.Field(obj.GetType(), "custom");
    this._categorySetMethod = AccessTools.Method(obj.GetType(), "Set", [this._category.FieldType]);
  }

  public int Get() => (int)this._category.GetValue(_object);
  public string GetCustom() => (string)this._custom.GetValue(_object);
  public void Set(int category) => this._categorySetMethod.Invoke(this._object, [category]);
}
