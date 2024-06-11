using LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes.Swamp;

namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Tiers;

public class Swamp : TierBase
{
  private static readonly Swamp s_instance;
  public static Swamp Instance { get; } = s_instance ??= new Swamp();
  private Swamp()
  {
    this._weapons = [
      "AtgeirIron",
      "AxeIron",
      "MaceIron",
      "SpearElderbark",
      "SwordIron",

      "BattleaxeIron_TW",
      "BLV_HuntsmanBow",
      "ClaymoreIron_TW",
      "FistIron_TW",
      "SledgeIron_TW",
    ];

    this._shields = [
      "ShieldIronBuckler",
      "ShieldBanded",
      "ShieldIronTower",
    ];

    this._sets = [
      ["HelmetRoot", "ArmorRootChest", "ArmorRootLegs", "CapeRotten_TW"],
      ["HelmetIron", "ArmorIronChest", "ArmorIronLegs", "CapeDeerHide"],

      ["swamphelm", "swampchest", "swamplegs", "CapeRotten_TW"],
    ];

    this._archetypes = [
      Miner.Instance,
      Raider.Instance,
      ScoutGatherer.Instance,
      Woodcutter.Instance,
    ];
  }
}
