using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HarmonyLib;

namespace LotusEcarlateChanges.Model.Managers.Standalone;

public class LocationManager<T>(List<T> registeredLocations) : StandaloneManagerBase<T>(registeredLocations), IIndexableManager<T>
{
  protected override string GetName(T location)
  {
    var nestedLocation = (Location)AccessTools.Field(location.GetType(), "location").GetValue(location);
    return nestedLocation.name;
  }

  public T this[string name] => this.GetObject(name);
  public IEnumerable<T> this[params string[] names] => names.Select(name => this[name]).Where(l => l is not null);
  public IEnumerator<T> GetEnumerator() => this._registeredObjects.GetEnumerator();
  IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}
