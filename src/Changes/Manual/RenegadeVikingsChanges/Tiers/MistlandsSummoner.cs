using LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes.Mistlands;

namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Tiers;

public class MistlandsSummoner : TierBase
{
  private static readonly MistlandsSummoner s_instance;
  public static MistlandsSummoner Instance { get; } = s_instance ??= new MistlandsSummoner();
  private MistlandsSummoner()
  {
    this._weapons = [
      "BRV_SkeletonStaff",
      "BRV_AttackSummon_Skeleton",
      "BRV_AttackSummon_Bats",
      "BRV_AttackCluster_Bomb",
    ];

    this._shields = [];

    this._sets = [
      ["HelmetMage", "ArmorMageChest", "ArmorMageLegs", "CapeFeather", "Demister"],
      ["HelmetMage_Ashlands", "ArmorMageChest_Ashlands", "ArmorMageLegs_Ashlands", "CapeAsksvin", "Demister"],
      ["HelmetAshlandsMediumHood", "ArmorAshlandsMediumChest", "ArmorAshlandsMediumlegs", "CapeAsh", "Demister"],
    ];

    this._archetypes = [
      BugRaider.Instance,
      DvergrRaider.Instance,
      Miner.Instance,
      SapRunner.Instance,
      ScoutGatherer.Instance,
      Woodcutter.Instance,
    ];
  }
}
