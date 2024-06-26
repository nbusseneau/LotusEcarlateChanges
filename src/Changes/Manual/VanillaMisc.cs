using HarmonyLib;
using LotusEcarlateChanges.Model.Changes;

namespace LotusEcarlateChanges.Changes.Manual;

public class VanillaMisc : ManualChangesBase
{
  protected override void ApplyInternal()
  {
    // Custom patches
    Plugin.Harmony.Patch(
      AccessTools.Method(typeof(Player.Food), nameof(Player.Food.CanEatAgain)),
      prefix: new HarmonyMethod(this.GetType(), nameof(CanEatAgainOverride))
    );

    Plugin.Harmony.Patch(
      AccessTools.Method(typeof(Player), nameof(Player.Awake)),
      prefix: new HarmonyMethod(this.GetType(), nameof(ModifyBlockStaminaDrain))
    );
    Plugin.Harmony.Patch(
      AccessTools.Method(typeof(SEMan), nameof(SEMan.ModifyDodgeStaminaUsage)),
      prefix: new HarmonyMethod(this.GetType(), nameof(ModifyDodgeStaminaUsageOverride))
    );
    Plugin.Harmony.Patch(
      AccessTools.Method(typeof(SEMan), nameof(SEMan.ModifyJumpStaminaUsage)),
      prefix: new HarmonyMethod(this.GetType(), nameof(ModifyJumpStaminaUsageOverride))
    );
  }

  private const float BlinkingDurationPercentage = 10f; // can eat at 10% remaining duration to roughly match vanilla's 50% duration in terms of efficiency cutoff
  private static void CanEatAgainOverride(Player.Food __instance, ref bool __result, ref bool __runOriginal)
  {
    __runOriginal = false;
    __result = __instance.m_time < __instance.m_item.m_shared.m_foodBurnTime * BlinkingDurationPercentage / 100.0f;
  }

  private static void ModifyBlockStaminaDrain(Player __instance) => __instance.m_blockStaminaDrain = 10f;

  private static void ModifyDodgeStaminaUsageOverride(SEMan __instance, float baseStaminaUse, ref float staminaUse, bool minZero)
  {
    // ignore calls to non-Player characters
    if (__instance.m_character is not Player player) return;

    // ignore calls coming from Player.GetEquipmentModifierPlusSE
    if (baseStaminaUse == 1f && !minZero) return;

    // reset entering value to basic stamina usage, ignoring any equipment modifiers
    staminaUse = player.m_dodgeStaminaUsage;
  }

  private static void ModifyJumpStaminaUsageOverride(SEMan __instance, float baseStaminaUse, ref float staminaUse, bool minZero)
  {
    // ignore calls to non-Player characters
    if (__instance.m_character is not Player player) return;

    // ignore calls coming from Player.GetEquipmentModifierPlusSE
    if (baseStaminaUse == 1f && !minZero) return;

    // reset entering value to basic stamina usage, ignoring any equipment modifiers
    staminaUse = player.m_jumpStaminaUsage;
  }

  protected override void ApplyApplyOnObjectDBAwakeInternal()
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
  }
}
