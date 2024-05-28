using System.Collections.Generic;
using System.Linq;
using LotusEcarlateChanges.Model.Wrappers;

namespace LotusEcarlateChanges.Model.ManualManagers;

public abstract class ManualManagerBase<T> where T : IWrapper
{
  protected abstract T Get(string prefabName);
  protected readonly Dictionary<string, T> WrappersCache = [];
  public T this[string prefabName]
  {
    get
    {
      var isCached = this.WrappersCache.TryGetValue(prefabName, out var wrapper);
      if (!isCached)
      {
        wrapper = this.Get(prefabName);
        if (wrapper is not null) this.WrappersCache[prefabName] = wrapper;
      }
      return wrapper;
    }
  }

  public IEnumerable<T> GetAll(IEnumerable<string> prefabNames) => prefabNames.Select(prefabName => this[prefabName]).Where(p => p is not null);
  public IEnumerable<(T, Y)> GetAll<Y>(IEnumerable<KeyValuePair<string, Y>> prefabNamesDict) => prefabNamesDict.Select(kvp => (this[kvp.Key], kvp.Value)).Where(t => t.Item1 is not null);

  public abstract void RemoveAll(HashSet<string> toRemove);
}
