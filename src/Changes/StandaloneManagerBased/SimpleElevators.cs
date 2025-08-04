extern alias SimpleElevators;

using SimpleElevators::PieceManager;
using LotusEcarlateChanges.Model.Changes;

namespace LotusEcarlateChanges.Changes.StandaloneManagerBased;

public class SimpleElevators : StandaloneManagerBasedChangesBase
{
  protected override void ApplyInternal()
  {
    var pieceManager = this.RegisterPieceManager(BuildPiece.registeredPieces, PiecePrefabManager.piecePrefabs);

    foreach (var (piece, _) in pieceManager)
    {
      // Relocate everything to Heavy Build
      piece.Category.Set(BuildPieceCategory.BuildingStonecutter);

      // Set Black Forge as requirement for elevators
      piece.Crafting.Set(CraftingTable.BlackForge);
    }
  }
}
