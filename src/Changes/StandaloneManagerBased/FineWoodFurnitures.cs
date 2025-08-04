extern alias FineWoodFurnitures;

using FineWoodFurnitures::PieceManager;
using LotusEcarlateChanges.Model.Changes;

namespace LotusEcarlateChanges.Changes.StandaloneManagerBased;

public class FineWoodFurnitures : StandaloneManagerBasedChangesBase
{
  protected override void ApplyInternal()
  {
    var pieceManager = this.RegisterPieceManager(BuildPiece.registeredPieces, PiecePrefabManager.piecePrefabs);

    // Remove item stands
    pieceManager.Remove([
      "BFP_ArmorStand",
      "BFP_WoodenArmorStand",
    ]);

    foreach (var (piece, _) in pieceManager)
    {
      // Relocate everything to Furniture
      piece.Category.Set(BuildPieceCategory.Furniture);
    }

    // Adjust comfort
    string[] comfort2 = [
      "BFP_FineWoodChair6",
      "BFP_FineWoodChair7",
      "BFP_MiniTable1",
      "BFP_LoxBed",
      "BFP_LoxDoubleBed",
    ];
    foreach (var (_, wrapper) in pieceManager[comfort2]) wrapper.Comfort.Value = 2;

    string[] comfort1 = [
      "BFP_FineWoodBed2",
      "BFP_LeatherBed",
    ];
    foreach (var (_, wrapper) in pieceManager[comfort1]) wrapper.Comfort.Value = 1;
  }
}
