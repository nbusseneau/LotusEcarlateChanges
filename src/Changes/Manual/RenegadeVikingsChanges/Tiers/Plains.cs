using LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes.Plains;

namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Tiers;

public class Plains : TierBase
{
  private static readonly Plains s_instance;
  public static Plains Instance { get; } = s_instance ??= new Plains();
  private Plains()
  {
    this._weapons = [
      "AtgeirBlackmetal",
      "AxeBlackMetal",
      "KnifeBlackMetal",
      "KnifeSkollAndHati",
      "MaceNeedle",
      "SwordBlackmetal",

      "BLV_DraugrFangBow",
      "DualSwordScimitar_TW",
      "LanceBlackmetal_TW",
      "SledgeBlackmetal_TW",
      "TridentBlackmetal_TW",
      "WarpikeBlackmetal_TW",
    ];

    this._shields = [
      "ShieldBlackmetal",
      "ShieldBlackmetalTower",
    ];

    this._sets = [
      ["HelmetPadded", "ArmorPaddedCuirass", "ArmorPaddedGreaves", "CapeLinen"],

      ["obswolfhelm", "obswolfchest", "obswolflegs", "CapeLox"],
      ["norahhelm", "norahchest", "norahlegs", "CapeLinen"],
      ["bearhelm2", "bearchest2", "bearlegs2", "CapeLox"],
    ];

    this._archetypes = [
      HunterGatherer.Instance,
      Raider.Instance,
      Woodcutter.Instance,
    ];
  }
}