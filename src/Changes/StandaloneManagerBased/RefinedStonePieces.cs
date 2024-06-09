extern alias RefinedStonePieces;

using LotusEcarlateChanges.Model.Changes;
using RefinedStonePieces::PieceManager;

namespace LotusEcarlateChanges.Changes.StandaloneManagerBased;

public class RefinedStonePieces : StandaloneManagerBasedChangesBase
{
  protected override void ApplyInternal()
  {
    var pieceManager = this.RegisterPieceManager(BuildPiece.registeredPieces, PiecePrefabManager.piecePrefabs);

    // Relocate RefinedStonePieces pieces to BuildingStonecutter
    foreach (var (piece, _) in pieceManager) piece.Category.Set(BuildPieceCategory.BuildingStonecutter);

    // Relocate statues to Furniture and remove comfort
    string[] statues = [
      "BRP_StoneCorgi",
      "BRP_StoneDeer",
      "BRP_StoneHare",
    ];
    foreach (var (piece, wrapper) in pieceManager[statues])
    {
      piece.Category.Set(BuildPieceCategory.Furniture);
      wrapper.Comfort.Value = 0;
    }

    // Relocate stack and hearth to Misc
    string[] relocateToMisc = [
      "BRP_RefinedStone_Stack",
      "BRP_RefinedStone_Hearth",
    ];
    foreach (var (piece, _) in pieceManager[relocateToMisc]) piece.Category.Set(BuildPieceCategory.Misc);
  }
}
