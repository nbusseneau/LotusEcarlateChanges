extern alias FineWoodBuildPieces;

using System.Collections.Generic;
using FineWoodBuildPieces::PieceManager;
using LotusEcarlateChanges.Model.Changes;

namespace LotusEcarlateChanges.Changes;

public class FineWoodBuildPieces : ChangesBase
{
  protected override void ApplyChangesInternal()
  {
    var pieceManager = this.RegisterPieceManager(BuildPiece.registeredPieces, PiecePrefabManager.piecePrefabs);

    // Remove most FineWoodFence pieces
    this.Remove("BFP_FenceGate");
    this.Remove("BFP_FencePillar1");
    this.Remove("BFP_FencePillar2");
    this.Remove("BFP_FencePillar3");
    this.Remove("BFP_FencePillar4");
    // Remove StepLadder
    this.Remove("BFP_StepLadder1");
    this.Remove("BFP_StepLadder2");

    foreach (var piece in pieceManager)
    {
      // Relocate Misc pieces to Furniture
      if (piece.Category.Category == BuildPieceCategory.Misc) piece.Category.Set(BuildPieceCategory.Furniture);
      // Relocate custom FineWoodFence pieces to Misc
      else if (piece.Category.custom == "FineWoodFence") piece.Category.Set(BuildPieceCategory.Misc);
      // Relocate custom FineWoodPieces pieces to BuildingWorkbench
      else if (piece.Category.custom == "FineWoodPieces") piece.Category.Set(BuildPieceCategory.BuildingWorkbench);
    }

    // Require Forge for heavy gate
    pieceManager["BFP_HeavyGate"].Crafting.Set(CraftingTable.Forge);

    // Require stonecutter for stone pieces and move them to BuildingStonecutter
    List<string> toAdjust = [
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
    foreach (var pieceName in toAdjust)
    {
      var piece = pieceManager[pieceName];
      piece.Crafting.Set(CraftingTable.StoneCutter);
      piece.Category.Set(BuildPieceCategory.BuildingStonecutter);
    }
  }
}
