extern alias FallDamageForCreatures;

using System.Collections.Generic;
using FallDamageForCreatures::Valheim.FallDamageForCreatures;
using LotusEcarlateChanges.Model.Changes;

namespace LotusEcarlateChanges.Changes.Manual;

public class FallDamageForCreatures : ManualChangesBase
{
  protected override void ApplyInternal()
  {
    // Monsters blacklisted for fall damage
    HashSet<string> toBlacklist = [
      // Mistlands
      "SeekerBrood",
      "Tick",

      // Ashlands
      "BlobLava",
    ];

    foreach (var monsterName in toBlacklist) FallDamagePatch.BlackListed.Add(monsterName.GetStableHashCode());
  }
}
