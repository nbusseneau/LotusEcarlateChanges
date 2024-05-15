using System.Collections.Generic;
using UnityEngine;
using LotusEcarlateChanges.Extensions;
using System.Collections;
using System.Linq;

namespace LotusEcarlateChanges.Model.Managers;

public abstract class ManagerBase<T>(List<T> registeredContainers, List<GameObject> prefabs) : IManager, IEnumerable<T>
{
  private readonly List<T> _registeredContainers = registeredContainers;
  private readonly List<GameObject> _prefabs = prefabs;

  protected readonly Dictionary<string, T> _cache = [];
  public T this[string prefabName]
  {
    get
    {
      if (!_cache.ContainsKey(prefabName)) _cache[prefabName] = this._registeredContainers.Single(c => c.Prefab().name == prefabName);
      return _cache[prefabName];
    }
  }

  public virtual void RemoveAll(HashSet<string> toRemove)
  {
    this._registeredContainers.RemoveAll(container => toRemove.Contains(container.Prefab().name));
    this._prefabs.RemoveAll(prefab => toRemove.Contains(prefab.name));
  }

  public virtual void KeepOnly(HashSet<string> toKeep)
  {
    this._registeredContainers.RemoveAll(container => !toKeep.Contains(container.Prefab().name));
    this._prefabs.RemoveAll(prefab => !toKeep.Contains(prefab.name));
  }

  public IEnumerator<T> GetEnumerator() => this._registeredContainers.GetEnumerator();
  IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}
