using System.Collections.Generic;
using System.Linq;
using LotusEcarlateChanges.Model.Manual;

namespace LotusEcarlateChanges.Changes;

public class MoreGates : ManualChangesBase
{
  protected override void ApplyChangesInternal()
  {
    var hammer = ItemManager["Hammer"];
    var pieceManager = this.GetPieceManager(hammer);

    // Relocate custom MoreGates pieces to appropriate categories
    Dictionary<string, Piece.PieceCategory> categoryChanges = new()
    {
      ["h_chain"] = Piece.PieceCategory.Furniture,
      ["hayzestake_01"] = Piece.PieceCategory.Misc,

      ["h_drawbridge01"] = Piece.PieceCategory.BuildingWorkbench,
      ["h_drawbridge02"] = Piece.PieceCategory.BuildingWorkbench,
      ["lift_gate"] = Piece.PieceCategory.BuildingWorkbench,
      ["lift_gate2"] = Piece.PieceCategory.BuildingWorkbench,
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
      ["h_loglong26"] = Piece.PieceCategory.BuildingWorkbench,
      ["h_loglong45"] = Piece.PieceCategory.BuildingWorkbench,
      ["h_logshort26"] = Piece.PieceCategory.BuildingWorkbench,
      ["h_logshort45"] = Piece.PieceCategory.BuildingWorkbench,
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
    foreach (var prefab in hammer.Pieces.Where(p => categoryChanges.ContainsKey(p.name)))
    {
      var piece = prefab.GetComponent<Piece>();
      piece.m_category = categoryChanges[piece.name];
    }

    // Add iron to gate with metal
    pieceManager["Hayze_gate_01"]?.Resources.Add("Iron", 1);

    // Add crystal to window recipes
    List<string> windows = [
      "h_window_01",
      "h_window_02",
      "h_window_03",
      "h_window_04",
      "h_window_05",
      "h_window_06",
      "h_window_07",
      "h_window_08",
      "h_window_09",
      "h_window_10",
      "h_window_11",
      "h_window_12",
      "h_window_13",
      "h_window_14",
    ];
    foreach (var prefabName in windows)
    {
      pieceManager[prefabName]?.Resources.Add("Crystal", 2);
    }
  }
}
