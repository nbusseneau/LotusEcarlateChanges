using System.Collections.Generic;

namespace LotusEcarlateChanges.Model.Reflection.Plugins;

public class BackpacksPlugin : ReflectionPluginBase
{
  public BackpacksPlugin() : base("org.bepinex.plugins.backpacks") { }

  public override void UnregisterToRemove(HashSet<string> toRemove) { }

  public override void UnregisterAllExceptToKeep(HashSet<string> toKeep) { }
}
