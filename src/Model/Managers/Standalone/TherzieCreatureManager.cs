using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using UnityEngine;

namespace LotusEcarlateChanges.Model.Managers.Standalone;

public class TherzieCreatureManager<T, Y>(List<T> registeredCreatures, List<Y> registeredSpawners, List<GameObject> prefabs) : PrefabManagerBase<T>(registeredCreatures, prefabs), IIndexableManager<(T Creature, IEnumerable<Y> Spawners)>
{
  private readonly List<Y> _registeredSpawners = registeredSpawners;

  protected override void ApplyToRemove()
  {
    base.ApplyToRemove();
    this._registeredSpawners.RemoveAll(spawner => this._toRemove.Contains(GetCreatureName(spawner)));
  }

  protected override void ApplyToKeep()
  {
    base.ApplyToKeep();
    this._registeredSpawners.RemoveAll(spawner => !this._toKeep.Contains(GetCreatureName(spawner)));
  }

  private string GetCreatureName(Y spawner) => this.GetName((T)AccessTools.Field(spawner.GetType(), "csCreature")?.GetValue(spawner));
  private IEnumerable<Y> GetSpawners(T creature) => this._registeredSpawners.Where(spawner => this.GetCreatureName(spawner).Equals(this.GetName(creature)));

  public (T Creature, IEnumerable<Y> Spawners) this[string name]
  {
    get
    {
      var creature = this.GetObject(name);
      return (creature, this.GetSpawners(creature));
    }
  }
  public IEnumerable<(T Creature, IEnumerable<Y> Spawners)> this[params string[] names] => names.Select(name => this[name]).Where(t => t.Creature is not null);
  public IEnumerator<(T Creature, IEnumerable<Y> Spawners)> GetEnumerator() => this._registeredObjects.Select(creature => (creature, this.GetSpawners(creature))).GetEnumerator();
  IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}
