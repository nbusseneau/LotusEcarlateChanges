extern alias ClayBuildPieces;

using ClayBuildPieces::ClayBuildPieces.Functions;
using ClayBuildPieces::PieceManager;
using HarmonyLib;
using LotusEcarlateChanges.Model.Changes;

namespace LotusEcarlateChanges.Changes.StandaloneManagerBased;

public class ClayBuildPieces : StandaloneManagerBasedChangesBase
{
  protected override void ApplyInternal()
  {
    var pieceManager = this.RegisterPieceManager(BuildPiece.registeredPieces, PiecePrefabManager.piecePrefabs);

    // Remove armor stand and chest
    pieceManager.Remove([
      "BFP_ClayArmorStand",
      "BFP_ClayChest",
    ]);

    foreach (var (piece, _) in pieceManager)
    {
      // Relocate custom ClayBuildPieces pieces to BuildingWorkbench
      if (piece.Category.custom == "ClayBuildPieces") piece.Category.Set(BuildPieceCategory.BuildingWorkbench);
      // Relocate Misc pieces to Furniture
      if (piece.Category.Category == BuildPieceCategory.Misc) piece.Category.Set(BuildPieceCategory.Furniture);
    }

    // Relocate clay light post to BuildingWorkbench
    var lightpost = pieceManager["BFP_ClayLightPost"].BuildPiece;
    lightpost.Category.Set(BuildPieceCategory.BuildingWorkbench);

    // Relocate clay collector to Crafting and change recipe
    var collector = pieceManager["BCP_ClayCollector"].BuildPiece;
    collector.Category.Set(BuildPieceCategory.Crafting);
    collector.RequiredItems.Requirements.Clear();
    collector.RequiredItems.Add("Stone", 20, true);
    collector.RequiredItems.Add("Bronze", 10, true);
    collector.RequiredItems.Add("FineWood", 20, true);
    collector.RequiredItems.Add("SurtlingCore", 5, true);
    collector.RequiredItems.Add("BFP_Clay", 30, true);

    // Remove comfort on statues
    string[] statues = [
      "BFP_ClayCorgi",
      "BFP_ClayDeer",
      "BFP_ClayHare",
    ];
    foreach (var (_, wrapper) in pieceManager[statues]) wrapper.Comfort.Value = 0;


    // Custom patches
    Plugin.Harmony.Patch(
      AccessTools.Method(typeof(SetupPrefabs), nameof(SetupPrefabs.SetupArmorStand)),
      prefix: new HarmonyMethod(this.GetType(), nameof(NoOpPrefix))
    );
  }

  private static void NoOpPrefix(ref bool __runOriginal) => __runOriginal = false;
}
