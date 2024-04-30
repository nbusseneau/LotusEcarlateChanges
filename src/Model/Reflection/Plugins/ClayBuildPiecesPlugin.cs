using System.Collections.Generic;

namespace LotusEcarlateChanges.Model.Reflection.Plugins;

public class ClayBuildPiecesPlugin : ReflectionPluginBase
{
  public Managers.PieceManager PieceManager { get; }

  public ClayBuildPiecesPlugin() : base("blacks7ar.ClayBuildPieces")
  {
    this.PieceManager = new(this.Assembly, "ClayBuildPieces.Functions");
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
