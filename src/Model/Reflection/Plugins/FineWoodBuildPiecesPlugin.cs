using System.Collections.Generic;

namespace LotusEcarlateChanges.Model.Reflection.Plugins;

public class FineWoodBuildPiecesPlugin : ReflectionPluginBase
{
  public Managers.PieceManager PieceManager { get; }

  public FineWoodBuildPiecesPlugin() : base("blacks7ar.FineWoodBuildPieces")
  {
    this.PieceManager = new(this.Assembly, "FineWoodBuildPieces.Functions");
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
