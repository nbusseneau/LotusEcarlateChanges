extern alias Clutter;

using System.Collections.Generic;
using System.Linq;
using Jotunn.Configs;
using Jotunn.Utils;
using LotusEcarlateChanges.Extensions;
using LotusEcarlateChanges.Model.Changes;
using LotusEcarlateChanges.Model.Wrappers;

namespace LotusEcarlateChanges.Changes.Jotunn;

public class Clutter : JotunnChangesBase
{
  private static IEnumerable<PieceWrapper> pieces;

  protected override void ApplyInternal()
  {
    pieces = ModRegistry.GetPieces("com.plumga.Clutter").Select(p => p.Piece());

    // Remove clutter tool and some pieces
    this.Remove("$PlumgaClutterTool");
    // Chests
    this.Remove("custompiece_fancychest");
    this.Remove("custompiece_fancychest_public");
    this.Remove("custompiece_stonechest");
    this.Remove("custompiece_stonechest_public");

    // Relocate clutter pieces to Furniture and erase all comfort values
    foreach (var piece in pieces)
    {
      piece.Category = Piece.PieceCategory.Furniture;
      piece.Comfort.Value = 0;
    }

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
    foreach (var (piece, comfort) in this.PieceManager.GetAll(toAdjust))
    {
      (piece.Comfort.Value, piece.Comfort.Group) = comfort;
    }
  }

  protected override void ApplyInternalDeferred()
  {
    var workbench = ZNetScene.instance.GetPrefab(CraftingStations.Workbench).GetComponent<CraftingStation>();
    var forge = ZNetScene.instance.GetPrefab(CraftingStations.Forge).GetComponent<CraftingStation>();
    var stonecutter = ZNetScene.instance.GetPrefab(CraftingStations.Stonecutter).GetComponent<CraftingStation>();

    // Relocate to Hammer and set workbench as default crafting table
    foreach (var piece in pieces)
    {
      piece.CraftingStation = workbench;
      this.PieceManager.RegisterPieceInPieceTable(piece.Prefab, "Hammer");
    }

    // Adjust required crafting table
    Dictionary<string, CraftingStation> toAdjust = new()
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
    foreach (var (piece, station) in this.PieceManager.GetAll(toAdjust))
    {
      piece.CraftingStation = station;
    }
  }
}
