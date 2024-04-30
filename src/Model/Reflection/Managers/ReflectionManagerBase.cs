using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using LotusEcarlateChanges.Model.Reflection.Objects;

namespace LotusEcarlateChanges.Model.Reflection.Managers;

public abstract class ReflectionManagerBase<T>(Assembly assembly) where T : ReflectionObjectBase
{
  protected readonly Assembly assembly = assembly;
  protected readonly Dictionary<string, T> _cache = [];

  protected abstract object GetObjectFromStorage(string name);
  public virtual T this[string prefabName]
  {
    get
    {
      if (!_cache.ContainsKey(prefabName))
      {
        var obj = this.GetObjectFromStorage(prefabName);
        _cache[prefabName] = (T)Activator.CreateInstance(typeof(T), [obj]);
      }
      return _cache[prefabName];
    }
  }

  protected abstract ICollection GetAllObjectsFromStorage();
  public virtual List<T> GetAll()
  {
    List<T> instances = [];
    foreach (var obj in this.GetAllObjectsFromStorage())
    {
      var instance = (T)Activator.CreateInstance(typeof(T), [obj]);
      if (!_cache.ContainsKey(instance.UniqueName))
      {
        _cache[instance.UniqueName] = instance;
        instances.Add(instance);
      }
      else instances.Add(_cache[instance.UniqueName]);
    }
    return instances;
  }


  public abstract void UnregisterToRemove(HashSet<string> toRemove);
  public abstract void UnregisterAllExceptToKeep(HashSet<string> toKeep);
}
