using System.Collections.Generic;
using UnityEngine;

namespace LotusEcarlateChanges.Model.Managers;
public class ItemManager<T>(List<T> registeredItems, List<GameObject> prefabs, List<GameObject> zNetOnlyPrefabs) : ManagerBase<T>(registeredItems, prefabs)
{
  private readonly List<GameObject> _zNetOnlyPrefabs = zNetOnlyPrefabs;

  public override void RemoveAll(HashSet<string> toRemove)
  {
    base.RemoveAll(toRemove);
    this._zNetOnlyPrefabs.RemoveAll(prefab => toRemove.Contains(prefab.name));
  }

  public override void KeepOnly(HashSet<string> toKeep)
  {
    base.KeepOnly(toKeep);
    this._zNetOnlyPrefabs.RemoveAll(prefab => !toKeep.Contains(prefab.name));
  }
}
