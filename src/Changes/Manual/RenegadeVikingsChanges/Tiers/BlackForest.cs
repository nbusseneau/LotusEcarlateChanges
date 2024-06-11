using LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes.BlackForest;

namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Tiers;

public class BlackForest : TierBase
{
  private static readonly BlackForest s_instance;
  public static BlackForest Instance { get; } = s_instance ??= new BlackForest();
  private BlackForest()
  {
    this._weapons = [
      "AtgeirBronze",
      "AxeBronze",
      "MaceBronze",
      "SpearBronze",
      "SwordBronze",

      "MaceChitin_TW",
      "BastardBone_TW",
      "BastardChitin_TW",
      "BattlehammerTrollbone_TW",
      "BLV_FineWoodBow",
      "FistBronze_TW",
      "FistChitin_TW",
      "WarpikeBone_TW",
      "WarpikeChitin_TW",
    ];

    this._shields = [
      "ShieldBronzeBuckler",
      "ShieldBoneTower",

      "ShieldChitinBuckler_TW",
      "ShieldChitin_TW",
    ];

    this._sets = [
      ["HelmetTrollLeather", "ArmorTrollLeatherChest", "ArmorTrollLeatherLegs", "CapeTrollHide"],
      ["HelmetBronze", "ArmorBronzeChest", "ArmorBronzeLegs", "CapeDeerHide"],

      ["heavybronzehelm", "heavybronzechest", "heavybronzelegs", "CapeTrollHide"],
    ];

    this._archetypes = [
      CopperMiner.Instance,
      Hunter.Instance,
      Raider.Instance,
      TinGatherer.Instance,
      Woodcutter.Instance,
    ];
  }
}
