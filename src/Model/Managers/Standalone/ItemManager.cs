using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LotusEcarlateChanges.Model.Wrappers;
using UnityEngine;

namespace LotusEcarlateChanges.Model.Managers.Standalone;

public class ItemManager<T>(List<T> registeredItems, List<GameObject> prefabs, List<GameObject> zNetOnlyPrefabs) : PrefabManagerBase<T>(registeredItems, prefabs), IIndexableManager<(T Item, ItemWrapper Wrapper)>
{
  private readonly List<GameObject> _zNetOnlyPrefabs = zNetOnlyPrefabs;

  protected override void ApplyToRemove()
  {
    base.ApplyToRemove();
    this._zNetOnlyPrefabs.RemoveAll(prefab => this._toRemove.Contains(prefab.name));
  }

  protected override void ApplyToKeep()
  {
    base.ApplyToKeep();
    this._zNetOnlyPrefabs.RemoveAll(prefab => !this._toKeep.Contains(prefab.name));
  }

  public (T Item, ItemWrapper Wrapper) this[string name]
  {
    get
    {
      var obj = this.GetObject(name);
      return (obj, ItemWrapper.Get(this.GetPrefab(obj)));
    }
  }
  public IEnumerable<(T Item, ItemWrapper Wrapper)> this[params string[] names] => names.Select(name => this[name]).Where(t => t.Item is not null);
  public IEnumerator<(T Item, ItemWrapper Wrapper)> GetEnumerator() => this._registeredObjects.Select(obj => (obj, ItemWrapper.Get(this.GetPrefab(obj)))).GetEnumerator();
  IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}
