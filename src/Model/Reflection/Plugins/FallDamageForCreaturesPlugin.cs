using System.Collections.Generic;

namespace LotusEcarlateChanges.Model.Reflection.Plugins;

public class FallDamageForCreaturesPlugin : ReflectionPluginBase
{
  public FallDamageForCreaturesPlugin() : base("fall_damage_for_creatures") { }
  public override void UnregisterAllExceptToKeep(HashSet<string> toKeep) { }
  public override void UnregisterToRemove(HashSet<string> toRemove) { }
}
