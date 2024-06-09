extern alias BowsBeforeHoes;

using BowsBeforeHoes::BowsBeforeHoes;
using BowsBeforeHoes::ItemManager;
using HarmonyLib;
using LotusEcarlateChanges.Model.Changes;

namespace LotusEcarlateChanges.Changes.StandaloneManagerBased;

public class BowsBeforeHoes : StandaloneManagerBasedChangesBase
{
  protected override void ApplyInternal()
  {
    var itemManager = this.RegisterItemManager(Item.registeredItems, PrefabManager.prefabs, PrefabManager.ZnetOnlyPrefabs);

    // Clear existing lists
    BowsBeforeHoesPlugin.QuiverList.Clear();
    BowsBeforeHoesPlugin.BowList.Clear();

    // Quivers
    itemManager.Keep([
      "BBH_BlackForest_Quiver",
      "BBH_BlackForest_QuiverViewOnly",
      "BBH_PlainsLox_Quiver",
      "BBH_PlainsLox_QuiverViewOnly",
      "BBH_Seeker_Quiver",
      "BBH_Seeker_QuiverViewOnly",
    ]);

    var (blackForestQuiver, blackForestQuiverWrapper) = itemManager["BBH_BlackForest_Quiver"];
    blackForestQuiver.RequiredItems.Requirements.Clear();
    blackForestQuiver.RequiredItems.Add("FineWood", 10);
    blackForestQuiver.RequiredItems.Add("RoundLog", 10);
    blackForestQuiver.RequiredItems.Add("DeerHide", 4);
    blackForestQuiver.RequiredItems.Add("HardAntler", 1);
    blackForestQuiver.RequiredUpgradeItems.Requirements.Clear();
    blackForestQuiver.RequiredUpgradeItems.Add("FineWood", 5);
    blackForestQuiver.RequiredUpgradeItems.Add("RoundLog", 5);
    blackForestQuiver.RequiredUpgradeItems.Add("DeerHide", 2);
    blackForestQuiver.RequiredUpgradeItems.Add("HardAntler", 1);
    blackForestQuiverWrapper.Armor.MovementModifier = 0f;
    blackForestQuiverWrapper.SharedData.m_maxQuality = 2;
    BowsBeforeHoesPlugin.QuiverList.Add(blackForestQuiver.Prefab);

    var (loxQuiver, loxQuiverWrapper) = itemManager["BBH_PlainsLox_Quiver"];
    loxQuiver.RequiredItems.Requirements.Clear();
    loxQuiver.RequiredItems.Add("FineWood", 10);
    loxQuiver.RequiredItems.Add("LinenThread", 30);
    loxQuiver.RequiredItems.Add("LoxPelt", 3);
    loxQuiver.RequiredUpgradeItems.Requirements.Clear();
    loxQuiver.RequiredUpgradeItems.Requirements.Clear();
    loxQuiver.RequiredUpgradeItems.Add("FineWood", 5);
    loxQuiver.RequiredUpgradeItems.Add("LinenThread", 15);
    loxQuiver.RequiredUpgradeItems.Add("LoxPelt", 2);
    loxQuiverWrapper.Armor.MovementModifier = 0f;
    loxQuiverWrapper.SharedData.m_maxQuality = 3;
    BowsBeforeHoesPlugin.QuiverList.Add(loxQuiver.Prefab);

    var (seekerQuiver, seekerQuiverWrapper) = itemManager["BBH_Seeker_Quiver"];
    seekerQuiver.RequiredItems.Requirements.Clear();
    seekerQuiver.RequiredItems.Add("YggdrasilWood", 20);
    seekerQuiver.RequiredItems.Add("Carapace", 20);
    seekerQuiver.RequiredItems.Add("Mandible", 3);
    seekerQuiver.RequiredUpgradeItems.Requirements.Clear();
    seekerQuiver.RequiredUpgradeItems.Requirements.Clear();
    seekerQuiver.RequiredUpgradeItems.Add("YggdrasilWood", 10);
    seekerQuiver.RequiredUpgradeItems.Add("Carapace", 10);
    seekerQuiver.RequiredUpgradeItems.Add("Mandible", 2);
    seekerQuiverWrapper.Armor.MovementModifier = 0f;
    seekerQuiverWrapper.SharedData.m_maxQuality = 4;
    BowsBeforeHoesPlugin.QuiverList.Add(seekerQuiver.Prefab);

    // Arrows
    itemManager.Keep([
      "TorchArrow",
      "bow_projectile_torch",
      "MistTorchArrow",
      "bow_projectile_misttorch",
    ]);

    var torchArrow = itemManager["TorchArrow"].Item;
    torchArrow.RequiredItems.Requirements.Clear();
    torchArrow.RequiredItems.Add("Wood", 8);
    torchArrow.RequiredItems.Add("Resin", 8);
    torchArrow.RequiredItems.Add("Feathers", 2);
    torchArrow.RequiredItems.Add("Tar", 1);
    torchArrow.Crafting.Stations.Clear();
    torchArrow.Crafting.Add(CraftingTable.Workbench, 3);

    var mistTorchArrow = itemManager["MistTorchArrow"].Item;
    mistTorchArrow.RequiredItems.Requirements.Clear();
    mistTorchArrow.RequiredItems.Add("Wood", 8);
    mistTorchArrow.RequiredItems.Add("Resin", 8);
    mistTorchArrow.RequiredItems.Add("Feathers", 2);
    mistTorchArrow.RequiredItems.Add("Eitr", 1);
    mistTorchArrow.Crafting.Stations.Clear();
    mistTorchArrow.Crafting.Add(CraftingTable.BlackForge, 1);

    // Custom patches
    Plugin.Harmony.Patch(
      AccessTools.Method(typeof(DummyItemDataThingy), nameof(DummyItemDataThingy.GetDefaultContainerSize)),
      prefix: new HarmonyMethod(this.GetType(), nameof(SetQuiverSizeOnCraft))
    );
    Plugin.Harmony.Patch(
      AccessTools.Method(typeof(DummyItemDataThingy), nameof(DummyItemDataThingy.Upgraded)),
      prefix: new HarmonyMethod(this.GetType(), nameof(InterceptQuiverQualityOnUpgrade)),
      postfix: new HarmonyMethod(this.GetType(), nameof(RestoreQuiverQualityAfterUpgrade))
    );
  }

  private static void SetQuiverSizeOnCraft(ref Vector2i __result, ref bool __runOriginal)
  {
    __runOriginal = false;
    __result = new Vector2i(1, 1);
  }

  private static int s_quiverQualityCache;
  private static void InterceptQuiverQualityOnUpgrade(DummyItemDataThingy __instance)
  {
    // Absolute kludge to ensure quiver size is equal to quiver quality, because trying to manipulate
    // ItemContainer.Resize() or DummyItemDataThingy.Inventory does't work as intended
    s_quiverQualityCache = __instance.Item.m_quality;
    __instance.Item.m_quality -= 2;
  }
  private static void RestoreQuiverQualityAfterUpgrade(DummyItemDataThingy __instance) => __instance.Item.m_quality = s_quiverQualityCache;
}
