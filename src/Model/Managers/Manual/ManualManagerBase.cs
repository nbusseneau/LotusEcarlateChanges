using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LotusEcarlateChanges.Model.Wrappers;

namespace LotusEcarlateChanges.Model.Managers.Manual;

public abstract class ManualManagerBase<T> : IIndexableManager<T> where T : PrefabWrapperBase
{
  protected abstract T Get(string name);
  protected readonly Dictionary<string, T> _wrappersCache = [];
  public T this[string name]
  {
    get
    {
      var isCached = this._wrappersCache.TryGetValue(name, out var wrapper);
      if (!isCached)
      {
        wrapper = this.Get(name);
        if (wrapper is not null) this._wrappersCache[name] = wrapper;
        else Plugin.Logger.LogError($"{this.GetType()} did not find any object registered with name {name}");
      }
      return wrapper;
    }
  }
  public IEnumerable<T> this[params string[] names] => names.Select(name => this[name]).Where(p => p is not null);

  protected readonly HashSet<string> _toRemove = [];
  public void Remove(params string[] names) => this._toRemove.UnionWith(names);
  public void Remove(IEnumerable<string> names) => this._toRemove.UnionWith(names);

  /// <summary>
  /// Not supported for manual managers.
  /// </summary>
  public void Keep(params string[] names) => throw new NotSupportedException();

  /// <summary>
  /// Not supported for manual managers.
  /// </summary>
  public void Keep(IEnumerable<string> names) => throw new NotSupportedException();

  public abstract void Apply();

  /// <summary>
  /// Not supported for manual managers.
  /// </summary>
  public IEnumerator<T> GetEnumerator() => throw new NotSupportedException();

  /// <summary>
  /// Not supported for manual managers.
  /// </summary>
  IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException();
}
