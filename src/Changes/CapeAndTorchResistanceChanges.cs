using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using LotusEcarlateChanges.Model.Reflection;
using LotusEcarlateChanges.Model.Reflection.Plugins;

namespace LotusEcarlateChanges.Changes;

public class CapeAndTorchResistanceChanges : ReflectionChangesBase<CapeAndTorchResistanceChangesPlugin>
{
  public static readonly HitData.DamageType Water = (HitData.DamageType)1024;
  public static readonly HitData.DamageType Cold = (HitData.DamageType)2048;
  private static readonly HashSet<HitData.DamageType> customDamageTypes = [Water, Cold,];

  protected override void ApplyChangesInternal()
  {
    // Custom patches
    Plugin.Harmony.Patch(
      AccessTools.Method(plugin.Assembly.GetType("CapeAndTorchResistanceChanges.NewResistances+SE_Stats_GetDamageModifiersTooltipString_Patch"), "Postfix"),
      prefix: new HarmonyMethod(this.GetType(), nameof(NoOpPrefix))
    );
  }

  private static void NoOpPrefix(ref bool __runOriginal) => __runOriginal = false;

  [HarmonyPatch(typeof(SE_Stats), nameof(SE_Stats.GetDamageModifiersTooltipString))]
  private static class InterceptGetDamageModifiersTooltipString
  {
    private static void Prefix(ref List<HitData.DamageModPair> mods, ref string __state)
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

    private static void Postfix(ref string __result, string __state)
    {
      __result += __state;
    }
  }
}
