using System.Collections.Generic;

namespace LotusEcarlateChanges.Model.Reflection.Plugins;

public class SouthsilArmorPlugin : ReflectionPluginBase
{
  public Managers.ItemManager ItemManager { get; }

  public SouthsilArmorPlugin() : base("southsil.SouthsilArmor")
  {
    this.ItemManager = new(this.Assembly);
  }

  public override void UnregisterToRemove(HashSet<string> toRemove)
  {
    this.ItemManager.UnregisterToRemove(toRemove);
  }

  public override void UnregisterAllExceptToKeep(HashSet<string> toKeep)
  {
    this.ItemManager.UnregisterAllExceptToKeep(toKeep);
  }
}
