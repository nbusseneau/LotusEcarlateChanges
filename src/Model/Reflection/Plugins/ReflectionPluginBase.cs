using System.Collections.Generic;
using System.Reflection;

namespace LotusEcarlateChanges.Model.Reflection.Plugins;

public abstract class ReflectionPluginBase
{
  public Assembly Assembly { get; }

  protected ReflectionPluginBase(string modGUID)
  {
    var pluginInfo = BepInEx.Bootstrap.Chainloader.PluginInfos[modGUID];
    this.Assembly = Assembly.LoadFile(pluginInfo.Location);
  }

  public abstract void UnregisterToRemove(HashSet<string> toRemove);
  public abstract void UnregisterAllExceptToKeep(HashSet<string> toKeep);
}
