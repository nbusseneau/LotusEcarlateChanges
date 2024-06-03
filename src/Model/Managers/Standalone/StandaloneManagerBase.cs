using System.Collections.Generic;
using System.Linq;

namespace LotusEcarlateChanges.Model.Managers.Standalone;

public abstract class StandaloneManagerBase<T>(List<T> registeredObjects) : IManager
{
  protected readonly List<T> _registeredObjects = registeredObjects;
  protected readonly Dictionary<string, T> _objectsCache = [];
  protected abstract string GetName(T obj);
  protected T GetObject(string name, bool logError = true)
  {
    var isCached = this._objectsCache.TryGetValue(name, out var cachedObject);
    if (!isCached)
    {
      cachedObject = this._registeredObjects.SingleOrDefault(obj => this.GetName(obj) == name);
      if (cachedObject is not null) this._objectsCache[name] = cachedObject;
      else if (logError) Plugin.Logger.LogError($"{this.GetType()} did not find any object registered with name {name}");
    }
    return cachedObject;
  }

  protected readonly HashSet<string> _toRemove = [];
  protected readonly HashSet<string> _toKeep = [];
  public void Remove(params string[] names) => this._toRemove.UnionWith(names);
  public void Remove(IEnumerable<string> names) => this._toRemove.UnionWith(names);
  public void Keep(params string[] names) => this._toKeep.UnionWith(names);
  public void Keep(IEnumerable<string> names) => this._toKeep.UnionWith(names);

  public void Apply()
  {
    if (this._toRemove.Any() && this._toKeep.Any()) Plugin.Logger.LogError("Can't have both object names to remove and object names to keep at the same time.");
    else if (this._toRemove.Any()) this.ApplyToRemove();
    else if (this._toKeep.Any()) this.ApplyToKeep();
  }

  protected virtual void ApplyToRemove()
  {
    foreach (var name in this._toRemove) this._registeredObjects.Remove(this.GetObject(name, logError: false));
  }

  protected virtual void ApplyToKeep()
  {
    var objectsToKeep = this._toKeep.Select(name => this.GetObject(name, logError: false)).Where(obj => obj is not null);
    this._registeredObjects.RemoveAll(obj => !objectsToKeep.Contains(obj));
  }
}
