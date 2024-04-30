using System.Collections;
using HarmonyLib;
using UnityEngine;

namespace LotusEcarlateChanges.Model.Reflection.Objects;

public class Creature : ReflectionObjectBase
{
  private readonly object _drops;
  private readonly IDictionary _dropsDict;

  public GameObject Prefab { get; }
  public override string UniqueName => this.Prefab.name;

  public Creature(object creature) : base(creature)
  {
    this._drops = AccessTools.Field(creature.GetType(), "Drops").GetValue(creature);
    this._dropsDict = (IDictionary)AccessTools.Field(this._drops.GetType(), "drops").GetValue(this._drops);

    this.Prefab = (GameObject)AccessTools.Field(creature.GetType(), "Prefab").GetValue(creature);
  }

  public void RemoveDrop(string prefabName)
  {
    this._dropsDict.Remove(prefabName);
  }
}
