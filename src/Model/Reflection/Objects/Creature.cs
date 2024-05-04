using HarmonyLib;
using LotusEcarlateChanges.Model.Reflection.Objects.Nested;
using UnityEngine;

namespace LotusEcarlateChanges.Model.Reflection.Objects;

public class Creature : ReflectionObjectBase
{
  public GameObject Prefab { get; }
  public override string UniqueName => this.Prefab.name;

  public DropList Drops { get; }

  public Creature(object creature) : base(creature)
  {
    this.Prefab = (GameObject)AccessTools.Field(creature.GetType(), "Prefab").GetValue(creature);
    this.Drops = new(AccessTools.Field(creature.GetType(), "Drops").GetValue(creature));
  }
}
