using LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes.Mountain;

namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Tiers;

public class Mountain : TierBase
{
  private static readonly Mountain s_instance;
  public static Mountain Instance { get; } = s_instance ??= new Mountain();
  private Mountain()
  {
    this._weapons = [
      "KnifeSilver",
      "MaceSilver",
      "SpearWolfFang",
      "SwordSilver",

      "BastardSilver_TW",
      "BattleaxeCrystal_TW",
      "BLV_DraugrFangBow",
      "FistSilver_TW",
      "WarpikeObsidian_TW",
    ];

    this._shields = [
      "ShieldSilver",
      "ShieldSerpentscale",
    ];

    this._sets = [
      ["HelmetFenring", "ArmorFenringChest", "ArmorFenringLegs", "CapeWolf"],
      ["HelmetDrake", "ArmorWolfChest", "ArmorWolfLegs", "CapeWolf"],

      ["heavybearhelm", "heavybearchest", "heavybearlegs", "CapeWolf"],
    ];

    this._archetypes = [
      Miner.Instance,
      Raider.Instance,
      ScoutGatherer.Instance,
    ];
  }
}
