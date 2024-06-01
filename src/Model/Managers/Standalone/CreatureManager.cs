using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LotusEcarlateChanges.Model.Managers.Standalone;

public class CreatureManager<T>(List<T> registeredCreatures, List<GameObject> prefabs) : PrefabManagerBase<T>(registeredCreatures, prefabs), IIndexableManager<T>
{
  public T this[string name] => this.GetObject(name);
  public IEnumerable<T> this[params string[] names] => names.Select(name => this[name]).Where(c => c is not null);
  public IEnumerator<T> GetEnumerator() => this._registeredObjects.GetEnumerator();
  IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}
