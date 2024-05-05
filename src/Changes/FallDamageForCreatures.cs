using System.Collections.Generic;
using HarmonyLib;
using LotusEcarlateChanges.Model.Reflection;
using LotusEcarlateChanges.Model.Reflection.Plugins;

namespace LotusEcarlateChanges.Changes;

public class FallDamageForCreatures : ReflectionChangesBase<FallDamageForCreaturesPlugin>
{
  protected override void ApplyChangesInternal()
  {
    // Add spiders to blackedlisted monsters for fall damage
    List<string> toBlacklist = [
      "BrownSpider",
      "BrownSpider_Spawn",
      "ForestSpider",
      "FrigidSpider",
      "FrostSpider",
      "GreenSpider",
      "TanSpider",
      "TreeSpider",
      "TreeSpider_Spawn",
      "Spider_Boss",
      "Spider_Hatchling",
    ];

    var fallDamagePatchType = plugin.Assembly.GetType("Valheim.FallDamageForCreatures.FallDamagePatch");
    var blacklisted = (HashSet<int>)AccessTools.Property(fallDamagePatchType, "BlackListed").GetValue(null);
    foreach (var monsterName in toBlacklist) blacklisted.Add(monsterName.GetStableHashCode());
  }
}
