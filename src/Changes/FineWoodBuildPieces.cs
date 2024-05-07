using PieceManager;
using LotusEcarlateChanges.Model.Reflection;
using LotusEcarlateChanges.Model.Reflection.Plugins;
using System.Collections.Generic;

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

    // Require Forge for heavy gate
    plugin.PieceManager["BFP_HeavyGate"].Crafting.Set((int)CraftingTable.Forge);

    // Require stonecutter for stone pieces
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
      plugin.PieceManager[pieceName].Crafting.Set((int)CraftingTable.StoneCutter);
    }
  }
}
