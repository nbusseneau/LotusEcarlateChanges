using System.Collections.Generic;

namespace LotusEcarlateChanges.Model.Reflection.Plugins;

public class WarfarePlugin : ReflectionPluginBase
{
  public Managers.ItemManager ItemManager { get; }
  public Managers.PieceManager PieceManager { get; }
  public Managers.SkillManager SkillManager { get; }

  public WarfarePlugin() : base("Therzie.Warfare")
  {
    this.ItemManager = new(this.Assembly);
    this.PieceManager = new(this.Assembly);
    this.SkillManager = new(this.Assembly);
  }

  public override void UnregisterToRemove(HashSet<string> toRemove)
  {
    this.ItemManager.UnregisterToRemove(toRemove);
    this.PieceManager.UnregisterToRemove(toRemove);
    this.SkillManager.UnregisterToRemove(toRemove);
  }

  public override void UnregisterAllExceptToKeep(HashSet<string> toKeep)
  {
    this.ItemManager.UnregisterAllExceptToKeep(toKeep);
    this.PieceManager.UnregisterAllExceptToKeep(toKeep);
    this.SkillManager.UnregisterAllExceptToKeep(toKeep);
  }
}
