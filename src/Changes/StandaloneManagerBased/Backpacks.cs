extern alias Backpacks;

using System;
using Backpacks::Backpacks;
using Backpacks::ItemManager;
using HarmonyLib;
using LotusEcarlateChanges.Extensions;
using LotusEcarlateChanges.Model.Changes;
using UnityEngine;

namespace LotusEcarlateChanges.Changes.StandaloneManagerBased;

public class Backpacks : StandaloneManagerBasedChangesBase
{
  private const float DefaultBackpackWeight = 4f;
  private const float WeightToMovespeedDecreaseRatio = 5f;
  private static SE_Backpack s_backpackEquipEffect;

  protected override void ApplyInternal()
  {
    // Disable default backpack
    var explorersBackpack = Backpacks::Backpacks.Backpacks.Backpack;
    explorersBackpack.Crafting.Stations.Clear();
    explorersBackpack.Crafting.Add(CraftingTable.Disabled, 1);

    // Set up custom backpack equip effect
    s_backpackEquipEffect = ScriptableObject.CreateInstance<SE_Backpack>();
    s_backpackEquipEffect.name = "Backpack";
    s_backpackEquipEffect.m_name = "$Backpack_Effect_Name";
    s_backpackEquipEffect.m_tooltip = "$Backpack_Effect_Tooltip";
    s_backpackEquipEffect.m_icon = explorersBackpack.Prefab.GetComponent<ItemDrop>().m_itemData.GetIcon();

    // Register custom patches
    Plugin.Harmony.Patch(
      AccessTools.Method(typeof(CustomBackpackConfig.Loader), nameof(CustomBackpackConfig.Loader.ApplyConfig)),
      postfix: new HarmonyMethod(this.GetType(), nameof(EditLoadedBackpacks))
    );
    Plugin.Harmony.Patch(
      AccessTools.Method(typeof(ObjectDB), nameof(ObjectDB.Awake)),
      postfix: new HarmonyMethod(this.GetType(), nameof(RegisterSEBackpack))
    );
    Plugin.Harmony.Patch(
      AccessTools.Method(typeof(ObjectDB), nameof(ObjectDB.CopyOtherDB)),
      postfix: new HarmonyMethod(this.GetType(), nameof(RegisterSEBackpack))
    );
  }

  private static void EditLoadedBackpacks()
  {
    foreach (var item in CustomBackpackConfig.Loader.loadedBackpacks.Values)
    {
      item.Name.Alias("$Backpack_Name");
      item.Description.Alias("$Backpack_Description");
      item.Item().Armor.EquipEffect = s_backpackEquipEffect;
    }
  }

  private static void RegisterSEBackpack(ObjectDB __instance)
  {
    var isAlreadyRegistered = __instance.GetStatusEffect(s_backpackEquipEffect.name.GetStableHashCode());
    if (!isAlreadyRegistered) __instance.m_StatusEffects.Add(s_backpackEquipEffect);
  }

  private class SE_Backpack : SE_Stats
  {
    public override void ModifySpeed(float baseSpeed, ref float speed, Character character, Vector3 dir)
    {
      var equippedBackpack = API.GetEquippedBackpack();
      var realBackpackWeight = equippedBackpack.GetWeight() - DefaultBackpackWeight;
      var movespeedDecrease = -realBackpackWeight / WeightToMovespeedDecreaseRatio / 100f;
      this.m_speedModifier = Math.Max(movespeedDecrease, -1f);
      base.ModifySpeed(baseSpeed, ref speed, character, dir);
    }
  }
}
