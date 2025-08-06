extern alias FineWoodFurnitures;

using FineWoodFurnitures::PieceManager;
using LotusEcarlateChanges.Model.Changes;
using UnityEngine;

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

    string[] comfort0 = [
      "BFP_Plant1",
      "BFP_Plant2",
      "BFP_Plant3",
      "BFP_Plant4",
      "BFP_Plant5",
      "BFP_Plant6",
      "BFP_Plant7",
      "BFP_Plant8",
      "BFP_Plant9",
      "BFP_Plant10",
      "BFP_Plant11",
      "BFP_Plant12",
      "BFP_Plant13",
      "BFP_Plant14",
      "BFP_Plant15",
      "BFP_Plant16",
      "BFP_Plant17",
      "BFP_Plant18",
      "BFP_FineWoodCrib",
    ];
    foreach (var (_, wrapper) in pieceManager[comfort0]) wrapper.Comfort.Value = 0;

    // Adjust container sizes and finewood costs
    (string, int, int, int)[] containersToAdjust = [
      ("BFP_BronzeFrameChest", 6, 3, 12),
      ("BFP_Cabinet1", 2, 4, 12),
      ("BFP_Cabinet2", 2, 4, 12),
      ("BFP_Cabinet3", 1, 2, 8),
      ("BFP_Cabinet4", 3, 3, 16),
      ("BFP_Cabinet5", 3, 3, 12),
      ("BFP_Cabinet6", 2, 4, 10),
      ("BFP_Cabinet7", 3, 4, 12),
      ("BFP_Cupboard", 3, 3, 16),
      ("BFP_FineWoodBasket", 2, 2, 6),
      ("BFP_FineWoodDrawer1", 2, 2, 8),
      ("BFP_FineWoodDrawer2", 3, 1, 8),
      ("BFP_FineWoodDrawer3", 3, 1, 8),
      ("BFP_FineWoodDrawer4", 3, 1, 10),
      ("BFP_FineWoodDrawer5", 3, 1, 8),
      ("BFP_LongCrate", 7, 2, 12),
    ];
    foreach (var (prefabName, width, height, finewoodCost) in containersToAdjust)
    {
      var (piece, wrapper) = pieceManager[prefabName];
      var container = wrapper.Prefab.GetComponent<Container>();
      container.m_width = width;
      container.m_height = height;

      // Don't ask. Seems like only this stupid clear/add technique works, can't edit in place. Not important enough to investigate.
      var currentRequirements = piece.RequiredItems.Requirements.ToArray();
      piece.RequiredItems.Requirements.Clear();
      foreach (var r in currentRequirements)
      {
        if (r.itemName == "FineWood") piece.RequiredItems.Add(r.itemName, finewoodCost, r.recover);
        else piece.RequiredItems.Add(r.itemName, r.amount, r.recover);
      }
    }

    // Remove containers
    string[] removeContainers = [
      "BFP_FineWoodTable8",
    ];
    foreach (var (_, wrapper) in pieceManager[removeContainers]) Object.Destroy(wrapper.Prefab.GetComponent<Container>());
  }
}
