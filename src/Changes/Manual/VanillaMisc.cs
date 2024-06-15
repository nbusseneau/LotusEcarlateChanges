using HarmonyLib;
using LotusEcarlateChanges.Model.Changes;

namespace LotusEcarlateChanges.Changes.Manual;

public class VanillaMisc : ManualChangesBase
{
  protected override void ApplyInternalDeferred()
  {
    var workbench = ZNetScene.instance.GetPrefab(Jotunn.Configs.CraftingStations.Workbench).GetComponent<CraftingStation>();
    var forge = ZNetScene.instance.GetPrefab(Jotunn.Configs.CraftingStations.Forge).GetComponent<CraftingStation>();

    // Relocate adornements from Misc to Furniture for consistency
    string[] adornements = [
      "darkwood_raven",
      "darkwood_wolf",
      "wood_dragon1",
    ];
    foreach (var piece in this.PieceManager[adornements]) piece.Category = Piece.PieceCategory.Furniture;

    // Rebalance some additional pieces
    this.PieceManager["piece_hexagonal_door"].CraftingStation = forge;
    this.PieceManager["piece_hexagonal_door"].Category = Piece.PieceCategory.BuildingStonecutter;

    this.PieceManager["darkwood_gate"].CraftingStation = workbench;

    var dvergrSharpStakes = this.PieceManager["piece_dvergr_sharpstakes"];
    dvergrSharpStakes.CraftingStation = workbench;
    dvergrSharpStakes.Resources.Clear();
    dvergrSharpStakes.Resources.Add("YggdrasilWood", 6);

    var dvergrStakewall = this.PieceManager["piece_dvergr_stake_wall"];
    dvergrStakewall.CraftingStation = workbench;
    dvergrStakewall.Resources.Clear();
    dvergrStakewall.Resources.Add("YggdrasilWood", 4);

    // Custom patches
    Plugin.Harmony.Patch(
      AccessTools.Method(typeof(Player.Food), nameof(Player.Food.CanEatAgain)),
      prefix: new HarmonyMethod(this.GetType(), nameof(CanEatAgainOverride))
    );
  }

  private const float BlinkingDurationPercentage = 10f; // can eat at 10% remaining duration to roughly match vanilla's 50% duration in terms of efficiency cutoff
  private static void CanEatAgainOverride(Player.Food __instance, ref bool __result, ref bool __runOriginal)
  {
    __runOriginal = false;
    __result = __instance.m_time < __instance.m_item.m_shared.m_foodBurnTime * BlinkingDurationPercentage / 100.0f;
  }
}
