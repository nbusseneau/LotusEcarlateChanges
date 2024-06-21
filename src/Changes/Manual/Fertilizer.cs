using System;
using HarmonyLib;
using LotusEcarlateChanges.Model.Changes;
using UnityEngine;

namespace LotusEcarlateChanges.Changes.Manual;

public class Fertilizer : ManualChangesBase
{
  private static bool s_defeatedEikthyrCache = false;
  private static bool s_defeatedGdkingCache = false;

  protected override void ApplyInternal()
  {
    // Custom patches
    Plugin.Harmony.Patch(
      AccessTools.Method(typeof(Pickable), nameof(Pickable.GetHoverText)),
      postfix: new HarmonyMethod(this.GetType(), nameof(PickableFertilizeHoverText))
    );
    Plugin.Harmony.Patch(
      AccessTools.Method(typeof(Plant), nameof(Plant.GetHoverText)),
      postfix: new HarmonyMethod(this.GetType(), nameof(PlantFertilizeHoverText))
    );
    Plugin.Harmony.Patch(
      AccessTools.Method(typeof(Player), nameof(Player.Interact)),
      prefix: new HarmonyMethod(this.GetType(), nameof(Fertilize))
    );
  }

  private static void PickableFertilizeHoverText(Pickable __instance, ref string __result)
  {
    if (!__instance.m_picked || __instance.m_enabled == 0) return;
    __result += FertilizeHoverText();
  }

  private static void PlantFertilizeHoverText(Plant __instance, ref string __result)
  {
    if (__instance.m_status != Plant.Status.Healthy) return;
    __result += FertilizeHoverText();
  }

  private static string FertilizeHoverText()
  {
    if (!s_defeatedEikthyrCache && !ZoneSystem.instance.GetGlobalKey(GlobalKeys.defeated_eikthyr)) return string.Empty;
    else s_defeatedEikthyrCache = true;
    if (!s_defeatedGdkingCache && ZoneSystem.instance.GetGlobalKey(GlobalKeys.defeated_gdking)) s_defeatedGdkingCache = true;

    var ymirFleshHoverText = s_defeatedGdkingCache ? " / 1 $item_ymirremains" : string.Empty;
    var fertilizeHoverText = $"\n[<color=yellow><b>$KEY_Use</b></color>] $AncientSeedFertilizer_Fertilize (3 $item_ancientseed{ymirFleshHoverText})";
    return Localization.instance.Localize(fertilizeHoverText);
  }

  private static void Fertilize(Player __instance, GameObject go, bool hold, ref bool __runOriginal)
  {
    if (!s_defeatedEikthyrCache || __instance.InAttack() || __instance.InDodge() || hold && Time.time - __instance.m_lastHoverInteractTime < 0.2f) return;
    Component component = go.GetComponentInParent<Pickable>() is { } pickable && pickable.m_picked && pickable.m_enabled != 0 ? pickable : null;
    component ??= go.GetComponentInParent<Plant>() is { } plant && plant.m_status == Plant.Status.Healthy ? plant : null;
    if (component is null) return;

    __instance.m_lastHoverInteractTime = Time.time;
    if (TryFertilize(Player.m_localPlayer, component)) __runOriginal = false;
  }

  private static bool TryFertilize(Player player, Component component)
  {
    return component switch
    {
      Pickable pickable => TryFertilize(player, pickable),
      Plant plant => TryFertilize(player, plant),
      _ => throw new NotImplementedException("This should never happen 🙈"),
    };
  }

  private static bool TryFertilize(Player player, Pickable pickable)
  {
    if (!pickable.m_nview.IsValid()) return false;
    return TryFertilizeInternal(player, pickable, () =>
    {
      pickable.m_nview.ClaimOwnership();
      pickable.m_nview.InvokeRPC(ZNetView.Everybody, nameof(Pickable.RPC_SetPicked), false);
    });
  }

  private static bool TryFertilize(Player player, Plant plant)
  {
    if (!plant.m_nview.IsValid()) return false;
    return TryFertilizeInternal(player, plant, () =>
    {
      plant.m_nview.ClaimOwnership();
      plant.Grow();
    });
  }

  private static readonly int s_ancientSeedsRequired = 3;
  private static bool TryFertilizeInternal(Player player, Component component, Action onFertilize)
  {
    var usedAncientSeeds = player.m_inventory.GetItem("$item_ancientseed") is { } ancientSeed && player.m_inventory.CountItems("$item_ancientseed") >= s_ancientSeedsRequired && player.m_inventory.RemoveItem(ancientSeed, s_ancientSeedsRequired);
    var usedYmirFlesh = s_defeatedGdkingCache && !usedAncientSeeds && player.m_inventory.GetItem("$item_ymirremains") is { } ymirFlesh && player.m_inventory.RemoveOneItem(ymirFlesh);
    if (!usedAncientSeeds && !usedYmirFlesh)
    {
      player.Message(MessageHud.MessageType.Center, "$AncientSeedFertilizer_FertilizerRequired", 0, null);
      return false;
    }
    onFertilize();
    player.DoInteractAnimation(component.transform.position);
    return true;
  }
}
