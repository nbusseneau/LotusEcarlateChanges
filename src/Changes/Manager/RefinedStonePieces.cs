extern alias RefinedStonePieces;

using RefinedStonePieces::PieceManager;
using LotusEcarlateChanges.Model.Changes;
using LotusEcarlateChanges.Extensions;
using System.Collections.Generic;

namespace LotusEcarlateChanges.Changes.Manager;

public class RefinedStonePieces : ManagerChangesBase
{
  protected override void ApplyInternal()
  {
    var pieceManager = this.RegisterPieceManager(BuildPiece.registeredPieces, PiecePrefabManager.piecePrefabs);

    // Relocate RefinedStonePieces pieces to BuildingStonecutter
    foreach (var piece in pieceManager)
    {
      piece.Category.Set(BuildPieceCategory.BuildingStonecutter);
    }

    // Relocate statues to Furniture and adjust comfort
    HashSet<string> toAdjust = [
      "BRP_StoneCorgi",
      "BRP_StoneDeer",
      "BRP_StoneHare",
    ];
    foreach (var piece in pieceManager.GetAll(toAdjust))
    {
      piece.Category.Set(BuildPieceCategory.Furniture);
      piece.Piece().Comfort.Value = 0;
    }

    // Relocate stack to Misc
    pieceManager["BRP_RefinedStone_Stack"].Category.Set(BuildPieceCategory.Misc);
  }
}
