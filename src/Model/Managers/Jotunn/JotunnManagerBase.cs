using System.Collections.Generic;
using System.Linq;

namespace LotusEcarlateChanges.Model.Managers.Jotunn;

public abstract class JotunnManagerBase : IManager
{
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
  protected abstract void ApplyToRemove();
  protected abstract void ApplyToKeep();
}
