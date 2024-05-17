extern alias PotteryBarn;

using System.Collections.Generic;
using LotusEcarlateChanges.Model.Changes;

namespace LotusEcarlateChanges.Changes.Manual;

public class PotteryBarn : ManualChangesBase
{
  protected override void ApplyInternalDeferred()
  {
    // Remove some pieces
    // Extra ship
    this.Remove("Trailership");
    // Turf roofs (replaced by dedicated TurfRoofs mod)
    this.Remove("turf_roof");
    this.Remove("turf_roof_top");
    this.Remove("turf_roof_wall");
    // Infinite brazier
    this.Remove("CastleKit_brazier");
    // Duplicate cultivator pieces
    // this.Remove("GlowingMushroom");
    // this.Remove("vines");

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
    foreach (var kvp in toAdjust)
    {
      Plugin.Logger.LogDebug(kvp.Key);
      var piece = PieceManager[kvp.Key];
      (piece.Comfort.Value, piece.Comfort.Group) = kvp.Value;
    }

    // Relocate pieces to appropriate categories
    Dictionary<string, Piece.PieceCategory> categoryChanges = new()
    {
      ["goblin_fence"] = Piece.PieceCategory.Misc,
      ["goblin_woodwall_2m_ribs"] = Piece.PieceCategory.Misc,

      ["dvergrtown_wood_support"] = Piece.PieceCategory.BuildingWorkbench,
      ["goblin_pole"] = Piece.PieceCategory.BuildingWorkbench,
      ["goblin_pole_small"] = Piece.PieceCategory.BuildingWorkbench,
      ["goblin_roof_45d"] = Piece.PieceCategory.BuildingWorkbench,
      ["goblin_roof_45d_corner"] = Piece.PieceCategory.BuildingWorkbench,
      ["goblin_roof_cap"] = Piece.PieceCategory.BuildingWorkbench,
      ["goblin_stairs"] = Piece.PieceCategory.BuildingWorkbench,
      ["goblin_stepladder"] = Piece.PieceCategory.BuildingWorkbench,
      ["goblin_woodwall_1m"] = Piece.PieceCategory.BuildingWorkbench,
      ["goblin_woodwall_2m"] = Piece.PieceCategory.BuildingWorkbench,

      ["dverger_demister"] = Piece.PieceCategory.Furniture,
      ["dverger_demister_large"] = Piece.PieceCategory.Furniture,
      ["dvergrprops_bed"] = Piece.PieceCategory.Furniture,
      ["dvergrprops_chair"] = Piece.PieceCategory.Furniture,
      ["dvergrprops_banner"] = Piece.PieceCategory.Furniture,
      ["dvergrprops_curtain"] = Piece.PieceCategory.Furniture,
      ["dvergrprops_lantern_standing"] = Piece.PieceCategory.Furniture,
      ["trader_wagon_destructable"] = Piece.PieceCategory.Furniture,
      ["goblin_banner"] = Piece.PieceCategory.Furniture,
      ["root07"] = Piece.PieceCategory.Furniture,
      ["root08"] = Piece.PieceCategory.Furniture,
      ["root11"] = Piece.PieceCategory.Furniture,
      ["root12"] = Piece.PieceCategory.Furniture,
      ["Skull1"] = Piece.PieceCategory.Furniture,
      ["Skull2"] = Piece.PieceCategory.Furniture,
      ["StatueCorgi"] = Piece.PieceCategory.Furniture,
      ["StatueDeer"] = Piece.PieceCategory.Furniture,
      ["StatueEvil"] = Piece.PieceCategory.Furniture,
      ["StatueHare"] = Piece.PieceCategory.Furniture,
      ["StatueSeed"] = Piece.PieceCategory.Furniture,
      ["stonechest"] = Piece.PieceCategory.Furniture,
    };
    foreach (var kvp in categoryChanges)
    {
      Plugin.Logger.LogDebug(kvp.Key);
      var piece = PieceManager[kvp.Key];
      piece.Category = kvp.Value;
    }
  }
}
