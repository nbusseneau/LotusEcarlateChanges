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

    // Relocate some other pieces
    pieceManager["BRP_RefinedStone_Stack"].BuildPiece.Category.Set(BuildPieceCategory.Misc);
    pieceManager["BRP_RefinedStone_Hearth"].BuildPiece.Category.Set(BuildPieceCategory.Furniture);
    pieceManager["BRP_StoneChest"].BuildPiece.Category.Set(BuildPieceCategory.Furniture);
  }
}
