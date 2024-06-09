using LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes.Mistlands;

namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Tiers;

public class MistlandsMage : TierBase
{
  private static readonly MistlandsMage s_instance;
  public static MistlandsMage Instance { get; } = s_instance ??= new MistlandsMage();
  private MistlandsMage()
  {
    this._weapons = [
      "BLV_FireStaff",
      "BLV_IceStaff",
    ];

    this._shields = [];

    this._sets = [
      ["HelmetMage", "ArmorMageChest", "ArmorMageLegs", "CapeFeather", "Demister"],

      ["runeknighthelm", "runeknightchest", "runeknightlegs", "CapeLinen", "Demister"],
      ["druidhelm", "druidchest", "druidlegs", "CapeLox", "Demister"],
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
