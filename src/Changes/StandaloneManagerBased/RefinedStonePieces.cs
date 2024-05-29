extern alias RefinedStonePieces;

using RefinedStonePieces::PieceManager;
using LotusEcarlateChanges.Model.Changes;
using LotusEcarlateChanges.Extensions;
using System.Collections.Generic;

namespace LotusEcarlateChanges.Changes.StandaloneManagerBased;

public class RefinedStonePieces : StandaloneManagerBasedChangesBase
{
  protected override void ApplyInternal()
  {
    var pieceManager = this.RegisterPieceManager(BuildPiece.registeredPieces, PiecePrefabManager.piecePrefabs);

    // Relocate RefinedStonePieces pieces to BuildingStonecutter
    foreach (var piece in pieceManager) piece.Category.Set(BuildPieceCategory.BuildingStonecutter);

    // Relocate statues to Furniture and adjust comfort
    HashSet<string> toFurniture = [
      "BRP_StoneCorgi",
      "BRP_StoneDeer",
      "BRP_StoneHare",
    ];
    foreach (var piece in pieceManager.GetAll(toFurniture))
    {
      piece.Category.Set(BuildPieceCategory.Furniture);
      piece.Piece().Comfort.Value = 0;
    }

    // Relocate stack and hearth to Misc
    HashSet<string> toMisc = [
      "BRP_RefinedStone_Stack",
      "BRP_RefinedStone_Hearth",
    ];
    foreach (var piece in pieceManager.GetAll(toMisc)) piece.Category.Set(BuildPieceCategory.Misc);
  }
}
