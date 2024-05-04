using System;
using System.Collections;
using HarmonyLib;

namespace LotusEcarlateChanges.Model.Reflection.Objects.Nested;

public class DropList
{
  private readonly IDictionary _drops;
  private readonly Type _dropType;

  public DropList(object obj)
  {
    this._drops = (IDictionary)AccessTools.Field(obj.GetType(), "drops").GetValue(obj);
    this._dropType = this._drops.GetType().GetGenericArguments()[1];
  }

  public void Add(string prefabName, float chance = 100f, float min = 1, float max = 1, bool levelMultiplier = true)
  {
    this._drops[prefabName] = Activator.CreateInstance(_dropType);
    AccessTools.Field(_dropType, "DropChance").SetValue(this._drops[prefabName], chance);
    var amount = AccessTools.Field(_dropType, "Amount").GetValue(this._drops[prefabName]);
    AccessTools.Field(amount.GetType(), "min").SetValue(amount, min);
    AccessTools.Field(amount.GetType(), "max").SetValue(amount, max);
    AccessTools.Field(_dropType, "MultiplyDropByLevel").SetValue(this._drops[prefabName], levelMultiplier);
  }
  public void Remove(string prefabName) => this._drops.Remove(prefabName);
  public void Clear() => this._drops.Clear();
}
