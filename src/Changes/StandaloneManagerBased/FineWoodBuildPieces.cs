extern alias FineWoodBuildPieces;

using FineWoodBuildPieces::PieceManager;
using LotusEcarlateChanges.Model.Changes;

namespace LotusEcarlateChanges.Changes.StandaloneManagerBased;

public class FineWoodBuildPieces : StandaloneManagerBasedChangesBase
{
  protected override void ApplyInternal()
  {
    var pieceManager = this.RegisterPieceManager(BuildPiece.registeredPieces, PiecePrefabManager.piecePrefabs);

    // Remove most FineWoodFence pieces and StepLadders
    pieceManager.Remove([
      "BFP_FenceGate",
      "BFP_FencePillar1",
      "BFP_FencePillar2",
      "BFP_FencePillar3",
      "BFP_FencePillar4",
      "BFP_StepLadder1",
      "BFP_StepLadder2",
    ]);

    foreach (var (piece, _) in pieceManager)
    {
      // Relocate Misc pieces to Furniture
      if (piece.Category.Category == BuildPieceCategory.Misc) piece.Category.Set(BuildPieceCategory.Furniture);
      // Relocate custom FineWoodFence pieces to Misc
      else if (piece.Category.custom == "FineWoodFence") piece.Category.Set(BuildPieceCategory.Misc);
      // Relocate custom FineWoodPieces pieces to BuildingWorkbench
      else if (piece.Category.custom == "FineWoodPieces") piece.Category.Set(BuildPieceCategory.BuildingWorkbench);
    }

    // Require Forge for heavy gate
    pieceManager["BFP_HeavyGate"].BuildPiece.Crafting.Set(CraftingTable.Forge);

    // Require stonecutter for stone pieces and move them to BuildingStonecutter
    string[] stonePieces = [
      "BFP_StoneLightPost",
      "BFP_StoneRoof26",
      "BFP_StoneRoof45",
      "BFP_StoneRoofICorner26",
      "BFP_StoneRoofICorner45",
      "BFP_StoneRoofOCorner26",
      "BFP_StoneRoofOCorner45",
      "BFP_StoneRoofTop26",
      "BFP_StoneRoofTop45",
    ];
    foreach (var (piece, _) in pieceManager[stonePieces])
    {
      piece.Crafting.Set(CraftingTable.StoneCutter);
      piece.Category.Set(BuildPieceCategory.BuildingStonecutter);
    }
  }
}
