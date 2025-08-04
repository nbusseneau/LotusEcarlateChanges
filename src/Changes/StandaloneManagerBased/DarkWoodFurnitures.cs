extern alias DarkWoodFurnitures;

using DarkWoodFurnitures::PieceManager;
using LotusEcarlateChanges.Model.Changes;

namespace LotusEcarlateChanges.Changes.StandaloneManagerBased;

public class DarkWoodFurnitures : StandaloneManagerBasedChangesBase
{
  protected override void ApplyInternal()
  {
    var pieceManager = this.RegisterPieceManager(BuildPiece.registeredPieces, PiecePrefabManager.piecePrefabs);

    foreach (var (piece, _) in pieceManager)
    {
      // Relocate everything to Furniture
      piece.Category.Set(BuildPieceCategory.Furniture);
    }

    // Adjust comfort for tables and chairs
    string[] comfortToAdjust = [
      "BDWF_Chair6",
      "BDWF_Chair7",
      "BDWF_MiniTable1",
    ];
    foreach (var (_, wrapper) in pieceManager[comfortToAdjust]) wrapper.Comfort.Value = 2;

    string[] comfort1 = [
      "BDWF_Bed2",
      "BDWF_Bed3",
    ];
    foreach (var (_, wrapper) in pieceManager[comfort1]) wrapper.Comfort.Value = 1;
  }
}
