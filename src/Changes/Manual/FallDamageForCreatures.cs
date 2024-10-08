extern alias FallDamageForCreatures;

using System.Collections.Generic;
using FallDamageForCreatures::Valheim.FallDamageForCreatures;
using LotusEcarlateChanges.Model.Changes;

namespace LotusEcarlateChanges.Changes.Manual;

public class FallDamageForCreatures : ManualChangesBase
{
  protected override void ApplyInternal()
  {
    // Add Mistlands small insects and MonsterLabZ spiders to blackedlisted monsters for fall damage
    HashSet<string> toBlacklist = [
      "SeekerBrood",
      "Tick",
      "BlobLava",
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
