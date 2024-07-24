extern alias WorldAdvancementProgression;

using WorldAdvancementProgression::VentureValheim.Progression;
using HarmonyLib;
using LotusEcarlateChanges.Model.Changes;

namespace LotusEcarlateChanges.Changes.Manual;

public class WorldAdvancementProgression : ManualChangesBase
{
  protected override void ApplyInternal()
  {
    // Fix world keys for chicken farming
    KeyManager.Instance.FoodKeysList["ChickenMeat"] = KeyManager.BOSS_KEY_SWAMP;
    KeyManager.Instance.FoodKeysList["ChickenEgg"] = KeyManager.BOSS_KEY_SWAMP;

    // Custom patches
    Plugin.Harmony.Patch(
      AccessTools.Method(typeof(KeyManager), nameof(KeyManager.IsActionBlocked), [typeof(ItemDrop.ItemData), typeof(int), typeof(bool), typeof(bool), typeof(bool)]),
      prefix: new HarmonyMethod(this.GetType(), nameof(AllowPoisonArrowsAfterTheElder))
    );
  }

  private static void AllowPoisonArrowsAfterTheElder(KeyManager __instance, ItemDrop.ItemData item, ref bool __result, ref bool __runOriginal)
  {
    if (item?.m_dropPrefab is not { } prefab) return;
    var itemName = Utils.GetPrefabName(prefab);
    if (itemName == "ArrowPoison" && __instance.HasKey(KeyManager.BOSS_KEY_BLACKFOREST))
    {
      __runOriginal = false;
      __result = false;
    }
  }
}
