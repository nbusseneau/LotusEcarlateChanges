using PieceManager;
using LotusEcarlateChanges.Model.Reflection;
using LotusEcarlateChanges.Model.Reflection.Plugins;

namespace LotusEcarlateChanges.Changes;

public class FineWoodBuildPieces : ReflectionChangesBase<FineWoodBuildPiecesPlugin>
{
  protected override void ApplyChangesInternal()
  {
    // Remove most FineWoodFence pieces
    this.Remove("BFP_FenceGate");
    this.Remove("BFP_FencePillar1");
    this.Remove("BFP_FencePillar2");
    this.Remove("BFP_FencePillar3");
    this.Remove("BFP_FencePillar4");
    // Remove StepLadder
    this.Remove("BFP_StepLadder1");
    this.Remove("BFP_StepLadder2");

    foreach (var piece in plugin.PieceManager.GetAll())
    {
      // Relocate Misc pieces to Furniture
      if (piece.Category == (int)BuildPieceCategory.Misc) piece.Category = (int)BuildPieceCategory.Furniture;
      // Relocate custom FineWoodFence pieces to Misc
      else if (piece.CustomCategory == "FineWoodFence") piece.Category = (int)BuildPieceCategory.Misc;
      // Relocate custom FineWoodPieces pieces to Building
      else if (piece.CustomCategory == "FineWoodPieces") piece.Category = (int)BuildPieceCategory.Building;
    }
  }
}
