using System.Collections.Generic;
using HarmonyLib;
using UnityEngine;

namespace LotusEcarlateChanges.Model.Managers.Standalone;

public abstract class PrefabManagerBase<T>(List<T> registeredObjects, List<GameObject> prefabs) : StandaloneManagerBase<T>(registeredObjects)
{
  protected readonly List<GameObject> _prefabs = prefabs;

  protected GameObject GetPrefab(T obj) => obj is not null ? (GameObject)AccessTools.Field(obj.GetType(), "Prefab").GetValue(obj) : null;
  protected override string GetName(T obj) => this.GetPrefab(obj)?.name;

  protected override void ApplyToRemove()
  {
    base.ApplyToRemove();
    this._prefabs.RemoveAll(prefab => this._toRemove.Contains(prefab.name));
  }

  protected override void ApplyToKeep()
  {
    base.ApplyToKeep();
    this._prefabs.RemoveAll(prefab => !this._toKeep.Contains(prefab.name));
  }
}
