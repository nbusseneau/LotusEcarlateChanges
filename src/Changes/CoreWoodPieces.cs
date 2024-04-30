using System.Collections.Generic;
using PieceManager;
using LotusEcarlateChanges.Model.Reflection;
using LotusEcarlateChanges.Model.Reflection.Plugins;

namespace LotusEcarlateChanges.Changes;

public class CoreWoodPieces : ReflectionChangesBase<CoreWoodPiecesPlugin>
{
  protected override void ApplyChangesInternal()
  {
    // Remove most CoreWoodFence pieces
    this.Remove("BCW_CoreWood_Fence1");
    this.Remove("BCW_CoreWood_Fence2");
    this.Remove("BCW_CoreWood_FenceGate");
    this.Remove("BCW_CoreWood_FencePillar");

    HashSet<string> drawBridges = [
      "BCW_CoreWood_DrawBridgeNarrow",
      "BCW_CoreWood_DrawBridgeNarrowTall",
      "BCW_CoreWood_DrawBridgeWide",
      "BCW_CoreWood_DrawBridgeWideTall",
    ];
    foreach (var piece in plugin.PieceManager.GetAll())
    {
      // Relocate draw bridges to Building to be consistent with MoreGates
      if (drawBridges.Contains(piece.UniqueName)) piece.Category = (int)BuildPieceCategory.Building;
      // Relocate custom CoreWoodFence pieces to Misc
      else if (piece.CustomCategory == "CoreWoodFence") piece.Category = (int)BuildPieceCategory.Misc;
      // Relocate custom CoreWoodPieces pieces to Building
      else if (piece.CustomCategory == "CoreWoodPieces") piece.Category = (int)BuildPieceCategory.Building;
    }
  }
}
