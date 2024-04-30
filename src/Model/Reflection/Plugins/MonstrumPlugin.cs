using System.Collections.Generic;

namespace LotusEcarlateChanges.Model.Reflection.Plugins;

public class MonstrumPlugin : ReflectionPluginBase
{
  public Managers.ItemManager ItemManager { get; }
  public Managers.PieceManager PieceManager { get; }
  public Managers.CreatureManager CreatureManager { get; }

  public MonstrumPlugin() : base("Therzie.Monstrum")
  {
    this.ItemManager = new(this.Assembly);
    this.PieceManager = new(this.Assembly);
    this.CreatureManager = new(this.Assembly);
  }

  public override void UnregisterToRemove(HashSet<string> toRemove)
  {
    this.ItemManager.UnregisterToRemove(toRemove);
    this.PieceManager.UnregisterToRemove(toRemove);
    this.CreatureManager.UnregisterToRemove(toRemove);
  }

  public override void UnregisterAllExceptToKeep(HashSet<string> toKeep)
  {
    this.ItemManager.UnregisterAllExceptToKeep(toKeep);
    this.PieceManager.UnregisterAllExceptToKeep(toKeep);
    this.CreatureManager.UnregisterAllExceptToKeep(toKeep);
  }
}
