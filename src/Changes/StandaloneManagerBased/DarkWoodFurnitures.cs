extern alias DarkWoodFurnitures;

using DarkWoodFurnitures::PieceManager;
using LotusEcarlateChanges.Model.Changes;
using UnityEngine;

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

    // Adjust container sizes
    (string, int, int)[] containersToAdjust = [
      ("BDWF_Cabinet1", 2, 4),
      ("BDWF_Cabinet2", 2, 4),
      ("BDWF_Cabinet3", 1, 4),
      ("BDWF_Cupboard", 3, 3),
      ("BDWF_Drawer1", 3, 3),
      ("BDWF_Drawer2", 3, 3),
      ("BDWF_Drawer3", 2, 4),
      ("BDWF_Drawer4", 2, 2),
      ("BDWF_Drawer5", 3, 1),
      ("BDWF_Drawer6", 3, 1),
      ("BDWF_Drawer7", 3, 1),
      ("BDWF_Drawer8", 3, 1),
      ("BDWF_IronChest", 7, 4),
      ("BDWF_LongCrate", 8, 3),
      ("BDWF_Table8", 2, 1),
    ];
    foreach (var (prefabName, width, height) in containersToAdjust)
    {
      var container = pieceManager[prefabName].Wrapper.Prefab.GetComponent<Container>();
      container.m_width = width;
      container.m_height = height;
    }

    // Remove containers
    string[] removeContainers = [
      "BDWF_Table8",
    ];
    foreach (var (_, wrapper) in pieceManager[removeContainers]) Object.Destroy(wrapper.Prefab.GetComponent<Container>());
  }
}
