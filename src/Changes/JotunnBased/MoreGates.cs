extern alias MoreGates;

using System.Collections.Generic;
using Jotunn.Configs;
using LotusEcarlateChanges.Extensions;
using LotusEcarlateChanges.Model.Changes;

namespace LotusEcarlateChanges.Changes.JotunnBased;

public class MoreGates : JotunnBasedChangesBase
{
  protected override void ApplyInternal()
  {
    // Remove lift and logs
    this.Remove("h_4x4_lift");
    this.Remove("h_loglong26");
    this.Remove("h_loglong45");
    this.Remove("h_logshort26");
    this.Remove("h_logshort45");

    // Relocate custom MoreGates pieces to appropriate categories
    Dictionary<string, Piece.PieceCategory> toAdjust = new()
    {
      ["h_chain"] = Piece.PieceCategory.Furniture,
      ["hayzestake_01"] = Piece.PieceCategory.Misc,

      ["h_drawbridge01"] = Piece.PieceCategory.BuildingStonecutter,
      ["h_drawbridge02"] = Piece.PieceCategory.BuildingStonecutter,
      ["lift_gate"] = Piece.PieceCategory.BuildingStonecutter,
      ["lift_gate2"] = Piece.PieceCategory.BuildingStonecutter,

      ["Hayze_gate_01"] = Piece.PieceCategory.BuildingWorkbench,
      ["Hayze_gate_02"] = Piece.PieceCategory.BuildingWorkbench,
      ["Hayze_gate_03"] = Piece.PieceCategory.BuildingWorkbench,
      ["Hayze_gate_04"] = Piece.PieceCategory.BuildingWorkbench,
      ["Hayze_gate_05"] = Piece.PieceCategory.BuildingWorkbench,
      ["Hayze_gate_06"] = Piece.PieceCategory.BuildingWorkbench,
      ["h_door_01"] = Piece.PieceCategory.BuildingWorkbench,
      ["h_door_02"] = Piece.PieceCategory.BuildingWorkbench,
      ["h_door_03"] = Piece.PieceCategory.BuildingWorkbench,
      ["h_shutter_01"] = Piece.PieceCategory.BuildingWorkbench,
      ["h_trapdoor"] = Piece.PieceCategory.BuildingWorkbench,
      ["h_trapdoorbig"] = Piece.PieceCategory.BuildingWorkbench,
      ["h_trapdoor2"] = Piece.PieceCategory.BuildingWorkbench,
      ["h_trapdoorbig2"] = Piece.PieceCategory.BuildingWorkbench,
      ["Hayze_halfgate_01"] = Piece.PieceCategory.BuildingWorkbench,
      ["Hayze_halfgate_02"] = Piece.PieceCategory.BuildingWorkbench,
      ["h_window_01"] = Piece.PieceCategory.BuildingWorkbench,
      ["h_window_02"] = Piece.PieceCategory.BuildingWorkbench,
      ["h_window_03"] = Piece.PieceCategory.BuildingWorkbench,
      ["h_window_04"] = Piece.PieceCategory.BuildingWorkbench,
      ["h_window_05"] = Piece.PieceCategory.BuildingWorkbench,
      ["h_window_06"] = Piece.PieceCategory.BuildingWorkbench,
      ["h_window_07"] = Piece.PieceCategory.BuildingWorkbench,
      ["h_window_08"] = Piece.PieceCategory.BuildingWorkbench,
      ["h_window_09"] = Piece.PieceCategory.BuildingWorkbench,
      ["h_window_10"] = Piece.PieceCategory.BuildingWorkbench,
      ["h_window_11"] = Piece.PieceCategory.BuildingWorkbench,
      ["h_window_12"] = Piece.PieceCategory.BuildingWorkbench,
      ["h_window_13"] = Piece.PieceCategory.BuildingWorkbench,
      ["h_window_14"] = Piece.PieceCategory.BuildingWorkbench,
    };
    foreach (var (piece, category) in this.PieceManager.GetAll(toAdjust))
    {
      piece.Category = category;
    }
  }

  protected override void ApplyInternalDeferred()
  {
    var forge = ZNetScene.instance.GetPrefab(CraftingStations.Forge).GetComponent<CraftingStation>();

    Dictionary<string, CraftingStation> toAdjustStation = new()
    {
      ["h_drawbridge01"] = forge,
      ["h_drawbridge02"] = forge,
      ["lift_gate"] = forge,
      ["lift_gate2"] = forge,
    };
    foreach (var (piece, station) in this.PieceManager.GetAll(toAdjustStation))
    {
      piece.CraftingStation = station;
    }

    Dictionary<string, (string, int)> toAdjustResources = new()
    {
      // Add iron to gate with metal
      ["Hayze_gate_01"] = ("Iron", 1),

      // Add crystal to windows
      ["h_window_01"] = ("Crystal", 2),
      ["h_window_02"] = ("Crystal", 2),
      ["h_window_03"] = ("Crystal", 2),
      ["h_window_04"] = ("Crystal", 2),
      ["h_window_05"] = ("Crystal", 2),
      ["h_window_06"] = ("Crystal", 2),
      ["h_window_07"] = ("Crystal", 2),
      ["h_window_08"] = ("Crystal", 2),
      ["h_window_09"] = ("Crystal", 2),
      ["h_window_10"] = ("Crystal", 2),
      ["h_window_11"] = ("Crystal", 2),
      ["h_window_12"] = ("Crystal", 2),
      ["h_window_13"] = ("Crystal", 2),
      ["h_window_14"] = ("Crystal", 2),
    };
    foreach (var (piece, (itemName, amount)) in this.PieceManager.GetAll(toAdjustResources))
    {
      piece.Resources.Add(itemName, amount);
    }
  }
}
