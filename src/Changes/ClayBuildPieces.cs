using HarmonyLib;
using PieceManager;
using LotusEcarlateChanges.Model.Reflection;
using LotusEcarlateChanges.Model.Reflection.Plugins;

namespace LotusEcarlateChanges.Changes;

public class ClayBuildPieces : ReflectionChangesBase<ClayBuildPiecesPlugin>
{
  protected override void ApplyChangesInternal()
  {
    // Remove armor stand and chest
    this.Remove("BFP_ClayArmorStand");
    this.Remove("BFP_ClayChest");

    foreach (var piece in plugin.PieceManager.GetAll())
    {
      // Relocate custom ClayBuildPieces pieces to Building
      if (piece.CustomCategory == "ClayBuildPieces") piece.Category = (int)BuildPieceCategory.Building;
      // Relocate Misc pieces to Furniture
      if (piece.Category == (int)BuildPieceCategory.Misc) piece.Category = (int)BuildPieceCategory.Furniture;
    }

    // Relocate clay collector to Crafting
    plugin.PieceManager["BCP_ClayCollector"].Category = (int)BuildPieceCategory.Crafting;

    // Adjust comfort
    plugin.PieceManager["BFP_ClayCorgi"].Comfort.Value = 0;
    plugin.PieceManager["BFP_ClayDeer"].Comfort.Value = 0;
    plugin.PieceManager["BFP_ClayHare"].Comfort.Value = 0;

    // Custom patches
    Plugin.Harmony.Patch(
      AccessTools.Method(plugin.Assembly.GetType("ClayBuildPieces.Functions.SetupPrefabs"), "SetupArmorStand"),
      prefix: new HarmonyMethod(this.GetType(), nameof(NoOpPrefix))
    );
  }

  private static void NoOpPrefix(ref bool __runOriginal) => __runOriginal = false;
}
