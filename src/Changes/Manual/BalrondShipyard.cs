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
    this.Remove("Knarr");
    this.Remove("SchematicKnarrAnchor");
    this.Remove("SchematicKnarrArmor");
    this.Remove("SchematicKnarrBag");
    this.Remove("SchematicKnarrLights");
    this.Remove("SchematicKnarrOars");
    this.Remove("SchematicKnarrShields");
    this.Remove("SchematicKnarrTent");
    this.Remove("SchematicKnarrSailBlack");
    this.Remove("SchematicKnarrSailBlue");
    this.Remove("SchematicKnarrSailDefault");
    this.Remove("SchematicKnarrSailDruid");
    this.Remove("SchematicKnarrSailGreen");
    this.Remove("SchematicKnarrSailHound");
    this.Remove("SchematicKnarrSailRaven");
    this.Remove("SchematicKnarrSailTransparent");
    this.Remove("SchematicKnarrSailWhite");
    this.Remove("SchematicKnarrSailWolf");

    this.Remove("Holk");
    this.Remove("SchematicHolkAnchor");
    this.Remove("SchematicHolkArmor");
    this.Remove("SchematicHolkLights");
    this.Remove("SchematicHolkOars");
    this.Remove("SchematicHolkShields");
    this.Remove("SchematicHolkTent");
    this.Remove("SchematicHolkBag");
    this.Remove("SchematicHolkRopes");
    this.Remove("SchematicHolkSailBlack");
    this.Remove("SchematicHolkSailBlue");
    this.Remove("SchematicHolkSailGreen");
    this.Remove("SchematicHolkSailDefault");
    this.Remove("SchematicHolkSailTransparent");
    this.Remove("SchematicHolkSailWhite");
    this.Remove("SchematicHolkSailHound");
    this.Remove("SchematicHolkSailDruid");
    this.Remove("SchematicHolkSailWolf");
    this.Remove("SchematicHolkSailRaven");

    // Remove some hideous pieces
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
    // Adjust category
    Dictionary<string, Piece.PieceCategory> toAdjustCategory = new()
    {
      ["decor_dragon"] = Piece.PieceCategory.Furniture,
      ["piece_banner_sail1"] = Piece.PieceCategory.Furniture,
      ["piece_banner_sail2"] = Piece.PieceCategory.Furniture,
      ["piece_ropewall"] = Piece.PieceCategory.Furniture,
      ["piece_ropewall_big"] = Piece.PieceCategory.Furniture,
      ["piece_wisplampceiling"] = Piece.PieceCategory.Furniture,
    };
    foreach (var (piece, category) in PieceManager.GetAll(toAdjustCategory)) piece.Category = category;

    // Adjust comfort
    Dictionary<string, (int, Piece.ComfortGroup)> toAdjustComfort = new()
    {
      ["piece_wisplampceiling"] = (0, Piece.ComfortGroup.Fire),

      ["decor_dragon"] = (0, Piece.ComfortGroup.Banner),
      ["piece_ropewall"] = (0, Piece.ComfortGroup.Banner),
      ["piece_ropewall_big"] = (0, Piece.ComfortGroup.Banner),
    };
    foreach (var (piece, comfort) in PieceManager.GetAll(toAdjustComfort)) (piece.Comfort.Value, piece.Comfort.Group) = comfort;
  }
}
