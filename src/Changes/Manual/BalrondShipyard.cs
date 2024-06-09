extern alias BalrondShipyard;

using System.Collections.Generic;
using BalrondShipyard::BalrondShipyard;
using LotusEcarlateChanges.Model.Changes;

namespace LotusEcarlateChanges.Changes.Manual;

public class BalrondShipyard : ManualChangesBase
{
  protected override void ApplyInternal()
  {
    // Remove extra ships
    this.PieceManager.Remove("Knarr");
    this.ItemManager.Remove([
      "SchematicKnarrAnchor",
      "SchematicKnarrArmor",
      "SchematicKnarrBag",
      "SchematicKnarrLights",
      "SchematicKnarrOars",
      "SchematicKnarrShields",
      "SchematicKnarrTent",
      "SchematicKnarrSailBlack",
      "SchematicKnarrSailBlue",
      "SchematicKnarrSailDefault",
      "SchematicKnarrSailDruid",
      "SchematicKnarrSailGreen",
      "SchematicKnarrSailHound",
      "SchematicKnarrSailRaven",
      "SchematicKnarrSailTransparent",
      "SchematicKnarrSailWhite",
      "SchematicKnarrSailWolf",
    ]);

    this.PieceManager.Remove("Holk");
    this.ItemManager.Remove([
      "SchematicHolkAnchor",
      "SchematicHolkArmor",
      "SchematicHolkLights",
      "SchematicHolkOars",
      "SchematicHolkShields",
      "SchematicHolkTent",
      "SchematicHolkBag",
      "SchematicHolkRopes",
      "SchematicHolkSailBlack",
      "SchematicHolkSailBlue",
      "SchematicHolkSailGreen",
      "SchematicHolkSailDefault",
      "SchematicHolkSailTransparent",
      "SchematicHolkSailWhite",
      "SchematicHolkSailHound",
      "SchematicHolkSailDruid",
      "SchematicHolkSailWolf",
      "SchematicHolkSailRaven",
    ]);

    // Remove some sails
    this.ItemManager.Remove([
      "SchematicKarveSailTransparent",
      "SchematicKarveSailWolf",
      "SchematicDrakkarSailTransparent",
      "SchematicDrakkarSailWolf",
    ]);

    // Remove some pieces
    HashSet<string> piecesToRemove = [
      "piece_chest_cargo",
      "piece_chest_tarred",
      "piece_iron_wall_torch",
    ];
    Launch.pieces.RemoveAll(piece => piecesToRemove.Contains(piece.name));

    // Remove all pirate items
    HashSet<string> itemsToRemove = [
      "HelmetPirateBandana",
      "HelmetPirateHat",
      "SledgeAnchor",
      "CapeSailor",
      "ShieldSteering",
      "SwordSaber",
    ];
    Launch.items.RemoveAll(item => itemsToRemove.Contains(item.name));
  }

  protected override void ApplyInternalDeferred()
  {
    // Relocate to furniture
    string[] relocateToFurniture = [
      "decor_dragon",
      "piece_banner_sail1",
      "piece_banner_sail2",
      "piece_ropewall",
      "piece_ropewall_big",
      "piece_wisplampceiling",
    ];
    foreach (var piece in this.PieceManager[relocateToFurniture]) piece.Category = Piece.PieceCategory.Furniture;

    // Erase comfort
    string[] removeComfort = [
      "piece_wisplampceiling",
      "decor_dragon",
      "piece_ropewall",
      "piece_ropewall_big",
    ];
    foreach (var piece in this.PieceManager[removeComfort]) piece.Comfort.Value = 0;
  }
}
