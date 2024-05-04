using System.Collections.Generic;

namespace LotusEcarlateChanges.Model.Reflection.Plugins;

public class MonsterLabZPlugin : ReflectionPluginBase
{
  public Managers.CreatureManager CreatureManager { get; }

  public MonsterLabZPlugin() : base("MonsterLabZ")
  {
    this.CreatureManager = new(this.Assembly);
  }

  public override void UnregisterToRemove(HashSet<string> toRemove)
  {
    this.CreatureManager.UnregisterToRemove(toRemove);
  }

  public override void UnregisterAllExceptToKeep(HashSet<string> toKeep)
  {
    this.CreatureManager.UnregisterAllExceptToKeep(toKeep);
  }
}
