using System.Collections.Generic;
using System.Linq;
using LotusEcarlateChanges.Model.Manual;
using LotusEcarlateChanges.Model.Wrappers;

namespace LotusEcarlateChanges.Changes;

public class PotteryBarn : ManualChangesBase
{
  protected override void ApplyChangesInternal()
  {
    var hammer = ItemManager["Hammer"];

    // Adjust comfort
    Dictionary<string, (int, Piece.ComfortGroup)> toAdjust = new()
    {
      ["ArmorStand_Female"] = (0, Piece.ComfortGroup.None),
      ["ArmorStand_Male"] = (0, Piece.ComfortGroup.None),
      ["goblin_banner"] = (1, Piece.ComfortGroup.Banner),
      ["dvergrprops_banner"] = (1, Piece.ComfortGroup.Banner),
      ["dvergrprops_bed"] = (1, Piece.ComfortGroup.Bed),
      ["dvergrprops_chair"] = (1, Piece.ComfortGroup.Chair),
    };
    foreach (var prefab in hammer.Pieces.Where(p => toAdjust.ContainsKey(p.name)))
    {
      var piece = prefab.GetComponent<Piece>();
      (piece.m_comfort, piece.m_comfortGroup) = toAdjust[prefab.name];
    }

    // Remove some pieces
    HashSet<string> toRemove = [
      // Extra ship
      "Trailership",
      // Turf roofs (replaced by dedicated TurfRoofs mod)
      "turf_roof",
      "turf_roof_top",
      "turf_roof_wall",
      // Infinite brazier
      "CastleKit_brazier",
    ];
    hammer.Pieces.RemoveAll(p => toRemove.Contains(p.name));
    ObjectDB.instance.m_items.RemoveAll(p => toRemove.Contains(p.name));

    // Relocate pieces
    HashSet<string> toMisc = [
      "goblin_fence",
      "goblin_woodwall_2m_ribs",
    ];
    foreach (var prefab in hammer.Pieces.Where(p => toMisc.Contains(p.name)))
    {
      var piece = prefab.GetComponent<Piece>();
      piece.m_category = Piece.PieceCategory.Misc;
    }

    HashSet<string> toBuilding = [
      "dvergrtown_wood_support",
      "goblin_pole",
      "goblin_pole_small",
      "goblin_roof_45d",
      "goblin_roof_45d_corner",
      "goblin_roof_cap",
      "goblin_stairs",
      "goblin_stepladder",
      "goblin_woodwall_1m",
      "goblin_woodwall_2m",
    ];
    foreach (var prefab in hammer.Pieces.Where(p => toBuilding.Contains(p.name)))
    {
      var piece = prefab.GetComponent<Piece>();
      piece.m_category = Piece.PieceCategory.Building;
    }

    HashSet<string> toFurniture = [
      "dverger_demister",
      "dverger_demister_large",
      "dvergrprops_bed",
      "dvergrprops_chair",
      "dvergrprops_banner",
      "dvergrprops_curtain",
      "dvergrprops_lantern_standing",
      "trader_wagon_destructable",
      "goblin_banner",
      "root07",
      "root08",
      "root11",
      "root12",
      "Skull1",
      "Skull2",
      "StatueCorgi",
      "StatueDeer",
      "StatueEvil",
      "StatueHare",
      "StatueSeed",
      "stonechest",
    ];
    foreach (var prefab in hammer.Pieces.Where(p => toFurniture.Contains(p.name)))
    {
      var piece = prefab.GetComponent<Piece>();
      piece.m_category = Piece.PieceCategory.Furniture;
    }

    // Remove cultivator pieces
    var cultivator = ItemManager["Cultivator"];
    HashSet<string> cultivatorToRemove = [
      "GlowingMushroom",
      "vines",
    ];
    cultivator.Pieces.RemoveAll(p => cultivatorToRemove.Contains(p.name));
    ObjectDB.instance.m_items.RemoveAll(p => cultivatorToRemove.Contains(p.name));
  }
}
