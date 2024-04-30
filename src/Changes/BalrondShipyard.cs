using System.Collections.Generic;
using System.Linq;
using LotusEcarlateChanges.Model.Manual;

namespace LotusEcarlateChanges.Changes;

public class BalrondShipyard : ManualChangesBase
{
  protected override void ApplyChangesInternal()
  {
    var hammer = ItemManager["Hammer"];

    // Adjust comfort
    Dictionary<string, (int, Piece.ComfortGroup)> toAdjust = new()
    {
      ["piece_wisplampceiling"] = (0, Piece.ComfortGroup.Fire),
      ["decor_dragon"] = (0, Piece.ComfortGroup.Banner),
      ["piece_ropewall"] = (0, Piece.ComfortGroup.Banner),
      ["piece_ropewall_big"] = (0, Piece.ComfortGroup.Banner),
    };
    foreach (var prefab in hammer.Pieces.Where(p => toAdjust.ContainsKey(p.name)))
    {
      var piece = prefab.GetComponent<Piece>();
      (piece.m_comfort, piece.m_comfortGroup) = toAdjust[prefab.name];
    }

    // Remove some pieces
    HashSet<string> piecesToRemove = [
      // Extra ships
      "Knarr",
      "Holk",
      // Hideous pieces
      "piece_chest_cargo",
      "piece_chest_tarred",
      "piece_iron_wall_torch",
    ];
    hammer.Pieces.RemoveAll(p => piecesToRemove.Contains(p.name));
    ObjectDB.instance.m_items.RemoveAll(p => piecesToRemove.Contains(p.name));

    // Pirate items
    HashSet<string> itemsToRemove = [
      "CapeSailor",
      "HelmetPirateBandana",
      "HelmetPirateHat",
      "SwordSaber",
      "SledgeAnchor",
      "ShieldSteering",
    ];
    foreach (var itemName in itemsToRemove)
    {
      var item = ItemManager[itemName];
      var recipe = ObjectDB.instance.GetRecipe(item.ItemData);
      ObjectDB.instance.m_recipes.Remove(recipe);
    }
  }
}
