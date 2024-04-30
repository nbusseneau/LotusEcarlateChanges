using System.Collections.Generic;

namespace LotusEcarlateChanges.Model.Reflection.Plugins;

public class CapeAndTorchResistanceChangesPlugin : ReflectionPluginBase
{
  public CapeAndTorchResistanceChangesPlugin() : base("goldenrevolver.CapeAndTorchResistanceChanges") { }
  public override void UnregisterAllExceptToKeep(HashSet<string> toKeep) { }
  public override void UnregisterToRemove(HashSet<string> toRemove) { }
}
