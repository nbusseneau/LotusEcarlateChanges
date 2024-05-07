using System.Collections.Generic;
using System.Linq;
using LotusEcarlateChanges.Model.Manual;

namespace LotusEcarlateChanges.Changes;

public class Clutter : ManualChangesBase
{
  protected override void ApplyChangesInternal()
  {
    var clutterTool = ItemManager["$PlumgaClutterTool"];
    var workbench = ZNetScene.instance?.GetPrefab("piece_workbench")?.GetComponent<CraftingStation>();
    var forge = ZNetScene.instance?.GetPrefab("forge")?.GetComponent<CraftingStation>();
    var stonecutter = ZNetScene.instance?.GetPrefab("piece_stonecutter")?.GetComponent<CraftingStation>();
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

    // Relocate clutter pieces to Furniture, erase all comfort values, and set
    // workbench as requirement when none is defined
    foreach (var prefab in clutterTool.Pieces.Where(p => !toRemove.Contains(p.name)))
    {
      var piece = prefab.GetComponent<Piece>();
      piece.m_category = Piece.PieceCategory.Furniture;
      piece.m_comfort = 0;
      piece.m_craftingStation ??= workbench;
      if (!hammer.Pieces.Contains(prefab)) hammer.Pieces.Add(prefab);
    }

    // Remove Clutter Tool recipe
    var clutterToolRecipe = ObjectDB.instance.GetRecipe(clutterTool.ItemData);
    ObjectDB.instance.m_recipes.Remove(clutterToolRecipe);

    // Adjust comfort
    Dictionary<string, (int, Piece.ComfortGroup)> comfortToAdjust = new()
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
    foreach (var prefab in hammer.Pieces.Where(p => comfortToAdjust.ContainsKey(p.name)))
    {
      var piece = prefab.GetComponent<Piece>();
      (piece.m_comfort, piece.m_comfortGroup) = comfortToAdjust[prefab.name];
    }

    // Adjust required crafting table
    Dictionary<string, CraftingStation> requiredCraftingTableToAdjust = new()
    {
      ["$custompiece_blackdragonstatuelarge"] = forge,
      ["$custompiece_blackdragonstatuesmall"] = forge,
      ["$custompiece_dragonstatuelarge"] = forge,
      ["$custompiece_dragonstatuesmall"] = forge,
      ["$custompiece_lokistatue"] = forge,
      ["$custompiece_odinstatue"] = forge,
      ["$custompiece_gravestone"] = stonecutter,
      ["$custompiece_statuecorgi"] = stonecutter,
      ["$custompiece_statuedeer"] = stonecutter,
      ["$custompiece_statueevil_small"] = stonecutter,
      ["$custompiece_statuehare"] = stonecutter,
      ["$custompiece_statueseed"] = stonecutter,
      ["$custompiece_celticidol1"] = stonecutter,
      ["$custompiece_celticidol1small"] = stonecutter,
      ["$custompiece_celticidol2"] = stonecutter,
      ["$custompiece_celticidol3"] = stonecutter,
      ["$custompiece_celticidol4"] = stonecutter,
      ["$custompiece_celticidol5"] = stonecutter,
      ["$custompiece_celticidol6"] = stonecutter,
      ["$custompiece_celticidol7"] = stonecutter,
      ["$custompiece_celticidol8"] = stonecutter,
      ["$custompiece_celticidol9"] = stonecutter,
      ["$custompiece_celticidol10"] = stonecutter,
      ["$custompiece_celticidol11"] = stonecutter,
      ["$custompiece_celticidol12"] = stonecutter,
    };
    foreach (var prefab in hammer.Pieces.Where(p => requiredCraftingTableToAdjust.ContainsKey(p.name)))
    {
      var piece = prefab.GetComponent<Piece>();
      piece.m_craftingStation = requiredCraftingTableToAdjust[prefab.name];
    }
  }
}
