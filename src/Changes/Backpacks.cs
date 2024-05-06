using System;
using System.Collections;
using System.Reflection;
using HarmonyLib;
using LotusEcarlateChanges.Model.Reflection;
using LotusEcarlateChanges.Model.Reflection.Objects;
using LotusEcarlateChanges.Model.Reflection.Plugins;
using UnityEngine;

namespace LotusEcarlateChanges.Changes;

public class Backpacks : ReflectionChangesBase<BackpacksPlugin>
{
  const float DefaultBackpackWeight = 4f;
  const float WeightToMovespeedDecreaseRatio = 5f;
  static MethodInfo getEquippedBackpackMethod;
  static IDictionary loadedBackpacks;
  static SE_Stats backpackEquipEffect;

  protected override void ApplyChangesInternal()
  {
    getEquippedBackpackMethod = AccessTools.Method(plugin.Assembly.GetType("Backpacks.API"), "GetEquippedBackpack");
    loadedBackpacks = (IDictionary)AccessTools.Field(plugin.Assembly.GetType("Backpacks.CustomBackpackConfig+Loader"), "loadedBackpacks").GetValue(null);

    backpackEquipEffect = ScriptableObject.CreateInstance<SE_Backpack>();
    backpackEquipEffect.name = "Backpack";
    backpackEquipEffect.m_name = "$Backpack_Effect_Name";
    backpackEquipEffect.m_tooltip = "$Backpack_Effect_Tooltip";

    Plugin.Harmony.Patch(
      AccessTools.Method(plugin.Assembly.GetType("Backpacks.CustomBackpackConfig+Loader"), "ApplyConfig"),
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
    foreach (var value in loadedBackpacks.Values)
    {
      Item item = new(value);
      item.Name.Alias("$Backpack_Name");
      item.Description.Alias("$Backpack_Description");
      item.Armor.EquipEffect = backpackEquipEffect;
      item.Armor.EquipEffect.m_icon = item.ItemData.GetIcon();
    }
  }

  private static void RegisterSEBackpack(ObjectDB __instance)
  {
    if (backpackEquipEffect is not null && !__instance.GetStatusEffect(backpackEquipEffect.name.GetStableHashCode()))
    {
      __instance.m_StatusEffects.Add(backpackEquipEffect);
    }
  }

  public class SE_Backpack : SE_Stats
  {
    public override void ModifySpeed(float baseSpeed, ref float speed)
    {
      var equippedBackpack = (ItemDrop.ItemData)getEquippedBackpackMethod.Invoke(null, []);
      var realBackpackWeight = equippedBackpack.GetWeight() - DefaultBackpackWeight;
      var movespeedDecrease = -realBackpackWeight / WeightToMovespeedDecreaseRatio / 100f;
      this.m_speedModifier = Math.Max(movespeedDecrease, -1f);
      base.ModifySpeed(baseSpeed, ref speed);
    }
  }
}
