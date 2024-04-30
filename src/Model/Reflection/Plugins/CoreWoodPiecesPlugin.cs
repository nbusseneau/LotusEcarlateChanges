using System.Collections.Generic;

namespace LotusEcarlateChanges.Model.Reflection.Plugins;

public class CoreWoodPiecesPlugin : ReflectionPluginBase
{
  public Managers.PieceManager PieceManager { get; }

  public CoreWoodPiecesPlugin() : base("blacks7ar.CoreWoodPieces")
  {
    this.PieceManager = new(this.Assembly);
  }

  public override void UnregisterToRemove(HashSet<string> toRemove)
  {
    this.PieceManager.UnregisterToRemove(toRemove);
  }

  public override void UnregisterAllExceptToKeep(HashSet<string> toKeep)
  {
    this.PieceManager.UnregisterAllExceptToKeep(toKeep);
  }
}
