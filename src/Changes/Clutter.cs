using System.Collections.Generic;
using System.Linq;
using LotusEcarlateChanges.Model.Manual;

namespace LotusEcarlateChanges.Changes;

public class Clutter : ManualChangesBase
{
  protected override void ApplyChangesInternal()
  {
    var clutterTool = ItemManager["$PlumgaClutterTool"];
    var hammer = ItemManager["Hammer"];

    // Remove some pieces
    HashSet<string> toRemove = [
      // Chests
      "$custompiece_fancychest",
      "$custompiece_fancychest_public",
      "$custompiece_stonechest",
      "$custompiece_stonechest_public",
      // Big evil statue (already added by PotteryBarn)
      "$custompiece_statueevil_large",
    ];

    // Relocate clutter pieces to Furniture and erase all comfort values
    foreach (var prefab in clutterTool.Pieces.Where(p => !toRemove.Contains(p.name)))
    {
      var piece = prefab.GetComponent<Piece>();
      piece.m_category = Piece.PieceCategory.Furniture;
      piece.m_comfort = 0;
      hammer.Pieces.Add(prefab);
    }

    // Remove Clutter Tool recipe
    var clutterToolRecipe = ObjectDB.instance.GetRecipe(clutterTool.ItemData);
    ObjectDB.instance.m_recipes.Remove(clutterToolRecipe);

    // Adjust comfort
    Dictionary<string, (int, Piece.ComfortGroup)> toAdjust = new()
    {
      ["$custompiece_coolchair"] = (1, Piece.ComfortGroup.Chair),
      ["$custompiece_couch1"] = (1, Piece.ComfortGroup.Chair),
      ["$custompiece_couch2"] = (1, Piece.ComfortGroup.Chair),
      ["$custompiece_couch3"] = (1, Piece.ComfortGroup.Chair),
      ["$custompiece_couch4"] = (1, Piece.ComfortGroup.Chair),
      ["$custompiece_couchbed1"] = (1, Piece.ComfortGroup.Chair),
      ["$custompiece_couchbed2"] = (1, Piece.ComfortGroup.Chair),
      ["$custompiece_rug_deer_tablecloth"] = (1, Piece.ComfortGroup.Carpet),
      ["$custompiece_rug_fur_tablecloth"] = (1, Piece.ComfortGroup.Carpet),
      ["$custompiece_rug_wolf_tablecloth"] = (1, Piece.ComfortGroup.Carpet),
      ["$custompiece_bloodytable"] = (1, Piece.ComfortGroup.Table),
      ["$custompiece_rectangulartable"] = (1, Piece.ComfortGroup.Table),
      ["$custompiece_roundtable"] = (1, Piece.ComfortGroup.Table),
      ["$custompiece_roundtablewithcloth"] = (1, Piece.ComfortGroup.Table),

    };
    foreach (var prefab in hammer.Pieces.Where(p => toAdjust.ContainsKey(p.name)))
    {
      var piece = prefab.GetComponent<Piece>();
      (piece.m_comfort, piece.m_comfortGroup) = toAdjust[prefab.name];
    }
  }
}
