extern alias CapeAndTorchResistanceChanges;

using System.Collections.Generic;
using System.Linq;
using CapeAndTorchResistanceChanges::CapeAndTorchResistanceChanges;
using static CapeAndTorchResistanceChanges::CapeAndTorchResistanceChanges.CapeAndTorchResistanceChangesPlugin;
using HarmonyLib;
using LotusEcarlateChanges.Model.Changes;

namespace LotusEcarlateChanges.Changes.Manual;

public class CapeAndTorchResistanceChanges : ManualChangesBase
{
  public static readonly HitData.DamageType Water = (HitData.DamageType)NewResistances.NewDamageTypes.Water;
  public static readonly HitData.DamageType Cold = (HitData.DamageType)NewResistances.NewDamageTypes.Cold;
  private static readonly HashSet<HitData.DamageType> customDamageTypes = [Water, Cold,];

  protected override void ApplyInternal()
  {
    // Enforce settings
    TeleportInstantlyUpdatesWeather.Value = TeleportChange.InstantlyUpdateWeatherAndClearWetAndColdDebuff;
    TeleportGrantsTemporaryWetAndColdImmunity.Value = false;
    EnableCapeChanges.Value = CapeChanges.Disabled;
    EnableTorchChanges.Value = TorchChanges.ResistanceChangesAndDurability;
    EnableTrollArmorSetBonusChange.Value = false;
    TrollCapeWaterResistance.Value = WaterResistance.ImmuneExceptSwimming;
    LoxCapeColdResistance.Value = ColdResistance.Immune;

    // Custom patches
    Plugin.Harmony.Patch(
      AccessTools.Method(typeof(NewResistances.SE_Stats_GetDamageModifiersTooltipString_Patch), nameof(NewResistances.SE_Stats_GetDamageModifiersTooltipString_Patch.Postfix)),
      prefix: new HarmonyMethod(this.GetType(), nameof(NoOpPrefix))
    );
    Plugin.Harmony.Patch(
      AccessTools.Method(typeof(SE_Stats), nameof(SE_Stats.GetDamageModifiersTooltipString)),
      prefix: new HarmonyMethod(this.GetType(), nameof(TooltipPrefix)),
      postfix: new HarmonyMethod(this.GetType(), nameof(TooltipPostfix))
    );
  }

  private static void NoOpPrefix(ref bool __runOriginal) => __runOriginal = false;

  private static void TooltipPrefix(ref List<HitData.DamageModPair> mods, ref string __state)
  {
    var customMods = mods.Where(m => customDamageTypes.Contains(m.m_type));
    if (customMods.Any())
    {
      var text = "";
      foreach (var damageModPair in customMods)
      {
        switch (damageModPair.m_modifier)
        {
          case HitData.DamageModifier.Resistant:
            text += "\n$inventory_dmgmod: <color=orange>$inventory_resistant</color> VS ";
            break;
          case HitData.DamageModifier.Weak:
            text += "\n$inventory_dmgmod: <color=orange>$inventory_weak</color> VS ";
            break;
          case HitData.DamageModifier.Immune:
            text += "\n$inventory_dmgmod: <color=orange>$inventory_immune</color> VS ";
            break;
          case HitData.DamageModifier.VeryResistant:
            text += "\n$inventory_dmgmod: <color=orange>$inventory_veryresistant</color> VS ";
            break;
          case HitData.DamageModifier.VeryWeak:
            text += "\n$inventory_dmgmod: <color=orange>$inventory_veryweak</color> VS ";
            break;
        }
        text += "<color=orange>";
        if (damageModPair.m_type == Water) text += "$CapeAndTorchResistanceChanges_WaterResistance_Name";
        else if (damageModPair.m_type == Cold) text += "$CapeAndTorchResistanceChanges_ColdResistance_Name";
        text += "</color>";
      }

      mods = mods.Where(m => !customDamageTypes.Contains(m.m_type)).ToList();
      __state = text;
    }
  }

  private static void TooltipPostfix(ref string __result, string __state)
  {
    __result += __state;
  }
}
