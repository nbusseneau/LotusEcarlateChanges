extern alias MaxAxe;

using static MaxAxe::neobotics.ValheimMods.MaxAxe;
using LotusEcarlateChanges.Model.Changes;

namespace LotusEcarlateChanges.Changes.Manual;

public class MaxAxe : ManualChangesBase
{
  protected override void ApplyInternal()
  {
    internalExcludes.Remove("ShieldCarapace");
    internalExcludes.Remove("ShieldCarapaceBuckler");
    internalExcludes.Add("ShieldWoodTower");
    ConfigExcludedPrefabs();
  }
}
