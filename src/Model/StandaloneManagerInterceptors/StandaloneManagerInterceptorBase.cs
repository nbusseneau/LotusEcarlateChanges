using System.Collections.Generic;
using UnityEngine;
using LotusEcarlateChanges.Extensions;
using System.Collections;
using System.Linq;

namespace LotusEcarlateChanges.Model.StandaloneManagerInterceptors;

public abstract class StandaloneManagerInterceptorBase<T>(List<T> registeredContainers, List<GameObject> prefabs) : IStandaloneManagerInterceptor, IEnumerable<T>
{
  protected readonly List<T> _registeredContainers = registeredContainers;
  protected readonly List<GameObject> _prefabs = prefabs;

  protected readonly Dictionary<string, T> ContainersCache = [];
  public T this[string prefabName]
  {
    get
    {
      var isCached = this.ContainersCache.TryGetValue(prefabName, out var container);
      if (!isCached) container = this.ContainersCache[prefabName] = this._registeredContainers.Single(c => c.Prefab().name == prefabName);
      return container;
    }
  }

  public IEnumerable<T> GetAll(IEnumerable<string> prefabNames) => prefabNames.Select(prefabName => this[prefabName]);
  public IEnumerable<(T, Y)> GetAll<Y>(IEnumerable<KeyValuePair<string, Y>> prefabNamesDict) => prefabNamesDict.Select(kvp => (this[kvp.Key], kvp.Value));

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
