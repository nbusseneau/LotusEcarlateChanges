extern alias FallDamageForCreatures;

using System.Collections.Generic;
using FallDamageForCreatures::Valheim.FallDamageForCreatures;
using LotusEcarlateChanges.Model.Changes;

namespace LotusEcarlateChanges.Changes;

public class FallDamageForCreatures : ChangesBase
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

    foreach (var monsterName in toBlacklist) FallDamagePatch.BlackListed.Add(monsterName.GetStableHashCode());
  }
}
