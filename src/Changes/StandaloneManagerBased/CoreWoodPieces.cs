extern alias CoreWoodPieces;

using System.Collections.Generic;
using CoreWoodPieces::PieceManager;
using LotusEcarlateChanges.Model.Changes;

namespace LotusEcarlateChanges.Changes.StandaloneManagerBased;

public class CoreWoodPieces : StandaloneManagerBasedChangesBase
{
  protected override void ApplyInternal()
  {
    var pieceManager = this.RegisterPieceManager(BuildPiece.registeredPieces, PiecePrefabManager.piecePrefabs);

    // Remove most CoreWoodFence pieces
    pieceManager.Remove([
      "BCW_CoreWood_Fence1",
      "BCW_CoreWood_Fence2",
      "BCW_CoreWood_FenceGate",
      "BCW_CoreWood_FencePillar",
    ]);

    HashSet<string> drawBridges = [
      "BCW_CoreWood_DrawBridgeNarrow",
      "BCW_CoreWood_DrawBridgeNarrowTall",
      "BCW_CoreWood_DrawBridgeWide",
      "BCW_CoreWood_DrawBridgeWideTall",
    ];
    foreach (var (piece, _) in pieceManager)
    {
      // Relocate draw bridges to BuildingWorkbench to be consistent with MoreGates
      if (drawBridges.Contains(piece.Prefab.name)) piece.Category.Set(BuildPieceCategory.BuildingWorkbench);
      // Relocate custom CoreWoodFence pieces to Misc
      else if (piece.Category.custom == "CoreWoodFence") piece.Category.Set(BuildPieceCategory.Misc);
      // Relocate custom CoreWoodPieces pieces to BuildingWorkbench
      else if (piece.Category.custom == "CoreWoodPieces") piece.Category.Set(BuildPieceCategory.BuildingWorkbench);
    }
  }
}
