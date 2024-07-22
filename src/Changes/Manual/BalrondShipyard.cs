extern alias BalrondShipyard;

using System.Collections.Generic;
using BalrondShipyard::BalrondShipyard;
using LotusEcarlateChanges.Extensions;
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
      "SchematicKnarrNamePlate",
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
      "SchematicHolkBag",
      "SchematicHolkLights",
      "SchematicHolkNamePlate",
      "SchematicHolkOars",
      "SchematicHolkRopes",
      "SchematicHolkShields",
      "SchematicHolkTent",
      "SchematicHolkSailBlack",
      "SchematicHolkSailBlue",
      "SchematicHolkSailDefault",
      "SchematicHolkSailDruid",
      "SchematicHolkSailGreen",
      "SchematicHolkSailHound",
      "SchematicHolkSailRaven",
      "SchematicHolkSailTransparent",
      "SchematicHolkSailWhite",
      "SchematicHolkSailWolf",
    ]);

    // Remove some sails
    this.ItemManager.Remove([
      "SchematicKarveSailTransparent",
      "SchematicKarveSailWolf",
      "SchematicDrakkarSailTransparent",
      "SchematicDrakkarSailWolf",
      "SchematicAshlandsDrakkarSailWolf",
      "SchematicAshlandsDrakkarSailTransparent",
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

    var shipyardTutorial = Launch.shipyard.GetComponentInChildren<GuidePoint>().m_text;
    shipyardTutorial.m_label = "$Tutorial_Shipyard_Label";
    shipyardTutorial.m_topic = "$Tutorial_Shipyard_Topic";
    shipyardTutorial.m_text = "$Tutorial_Shipyard_Text";

    var scribeTableTutorial = Launch.scribeTable.GetComponentInChildren<GuidePoint>().m_text;
    scribeTableTutorial.m_label = "$Tutorial_ScribeTable_Label";
    scribeTableTutorial.m_topic = "$Tutorial_ScribeTable_Topic";
    scribeTableTutorial.m_text = "$Tutorial_ScribeTable_Text";
  }

  protected override void ApplyOnObjectDBAwakeInternal()
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

    // Adjust container sizes
    var raftContainer = Launch.raftExtension.Find("piece_chest").GetComponent<Container>();
    raftContainer.m_width = 2;
    raftContainer.m_height = 2;

    var karveContainer = this.PieceManager["Karve"].Prefab.Find("piece_chest").GetComponent<Container>();
    karveContainer.m_width = 5;
    karveContainer.m_height = 2;

    var longshipContainer = this.PieceManager["VikingShip"].Prefab.Find("piece_chest").GetComponent<Container>();
    longshipContainer.m_width = 6;
    longshipContainer.m_height = 4;

    var drakkarContainer = this.PieceManager["VikingShip_Ashlands"].Prefab.Find("piece_chest").GetComponent<Container>();
    drakkarContainer.m_width = 8;
    drakkarContainer.m_height = 4;
  }
}
