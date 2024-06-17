extern alias MoreGates;

using Jotunn.Configs;
using LotusEcarlateChanges.Model.Changes;


namespace LotusEcarlateChanges.Changes.JotunnBased;

public class MoreGates() : JotunnBasedChangesBase("com.drakemods.Moregates")
{
  protected override void ApplyInternal()
  {
    // Remove lift and logs
    this.PieceManager.Remove([
      "h_4x4_lift",
      "h_loglong26",
      "h_loglong45",
      "h_logshort26",
      "h_logshort45",
    ]);

    // Relocate all pieces to BuildingWorkbench by default
    foreach (var piece in this.PieceManager) piece.Category = Piece.PieceCategory.BuildingWorkbench;

    // Relocate some pieces to specific categories for consistency
    this.PieceManager["h_chain"].Category = Piece.PieceCategory.Furniture;
    this.PieceManager["hayzestake_01"].Category = Piece.PieceCategory.Misc;

    // Relocate heavy draw bridges and gates to BuildingStonecutter
    string[] heavyPieces = [
      "h_drawbridge01",
      "h_drawbridge02",
      "lift_gate",
      "lift_gate2",
    ];
    foreach (var piece in this.PieceManager[heavyPieces]) piece.Category = Piece.PieceCategory.BuildingStonecutter;
  }

  protected override void ApplyOnPiecesRegisteredInternal()
  {
    var forge = ZNetScene.instance.GetPrefab(CraftingStations.Forge).GetComponent<CraftingStation>();

    // Set forge as required crafting station on heavy draw bridges and gates
    string[] heavyPieces = [
      "h_drawbridge01",
      "h_drawbridge02",
      "lift_gate",
      "lift_gate2",
    ];
    foreach (var piece in this.PieceManager[heavyPieces]) piece.CraftingStation = forge;

    // Add iron to gate with metal
    this.PieceManager["Hayze_gate_01"].Resources.Add("Iron", 1);

    // Add crystal to windows
    string[] windows = [
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
    foreach (var piece in this.PieceManager[windows]) piece.Resources.Add("Crystal", 2);
  }
}
