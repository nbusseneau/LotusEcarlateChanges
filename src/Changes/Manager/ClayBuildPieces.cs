extern alias ClayBuildPieces;

using ClayBuildPieces::ClayBuildPieces.Functions;
using ClayBuildPieces::PieceManager;
using HarmonyLib;
using LotusEcarlateChanges.Extensions;
using LotusEcarlateChanges.Model.Changes;

namespace LotusEcarlateChanges.Changes.Manager;

public class ClayBuildPieces : ManagerChangesBase
{
  protected override void ApplyInternal()
  {
    var pieceManager = this.RegisterPieceManager(BuildPiece.registeredPieces, PiecePrefabManager.piecePrefabs);

    // Remove armor stand and chest
    this.Remove("BFP_ClayArmorStand");
    this.Remove("BFP_ClayChest");

    foreach (var piece in pieceManager)
    {
      // Relocate custom ClayBuildPieces pieces to BuildingWorkbench
      if (piece.Category.custom == "ClayBuildPieces") piece.Category.Set(BuildPieceCategory.BuildingWorkbench);
      // Relocate Misc pieces to Furniture
      if (piece.Category.Category == BuildPieceCategory.Misc) piece.Category.Set(BuildPieceCategory.Furniture);
    }

    // Relocate clay collector to Crafting and change recipe
    var collector = pieceManager["BCP_ClayCollector"];
    collector.Category.Set(BuildPieceCategory.Crafting);
    collector.RequiredItems.Requirements.Clear();
    collector.RequiredItems.Add("Stone", 20, true);
    collector.RequiredItems.Add("Bronze", 10, true);
    collector.RequiredItems.Add("FineWood", 20, true);
    collector.RequiredItems.Add("SurtlingCore", 5, true);
    collector.RequiredItems.Add("BFP_Clay", 30, true);

    // Adjust comfort
    pieceManager["BFP_ClayCorgi"].Piece().Comfort.Value = 0;
    pieceManager["BFP_ClayDeer"].Piece().Comfort.Value = 0;
    pieceManager["BFP_ClayHare"].Piece().Comfort.Value = 0;

    // Custom patches
    Plugin.Harmony.Patch(
      AccessTools.Method(typeof(SetupPrefabs), nameof(SetupPrefabs.SetupArmorStand)),
      prefix: new HarmonyMethod(this.GetType(), nameof(NoOpPrefix))
    );
  }

  private static void NoOpPrefix(ref bool __runOriginal) => __runOriginal = false;
}
