using System;
using System.Collections.Generic;
using System.Linq;
using LotusEcarlateChanges.Model.Reflection.Plugins;

namespace LotusEcarlateChanges.Model.Reflection;

public abstract class ReflectionChangesBase<T> : IChanges where T : ReflectionPluginBase
{
  protected T plugin = Activator.CreateInstance<T>();
  protected HashSet<string> ToRemove { get; } = [];
  protected HashSet<string> ToKeep { get; } = [];

  protected void Remove(string prefabName) => this.ToRemove.Add(prefabName);
  protected void Keep(string prefabName) => this.ToKeep.Add(prefabName);

  public void Apply()
  {
    this.ApplyChangesInternal();
    if (this.ToRemove.Any()) plugin.UnregisterToRemove(ToRemove);
    if (this.ToKeep.Any()) plugin.UnregisterAllExceptToKeep(ToKeep);
  }

  protected abstract void ApplyChangesInternal();
}
