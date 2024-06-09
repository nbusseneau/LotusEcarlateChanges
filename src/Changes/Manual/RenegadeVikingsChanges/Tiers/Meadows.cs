using LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes.Meadows;

namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Tiers;

public class Meadows : TierBase
{
  private static readonly Meadows s_instance;
  public static Meadows Instance { get; } = s_instance ??= new Meadows();
  private Meadows()
  {
    this._weapons = [
      "AxeFlint",
      "Club",
      "KnifeFlint",
      "SpearFlint",

      "BLV_Bow",
      "SledgeStagbreaker_TW",
    ];

    this._shields = [
      "ShieldWood",
      "ShieldWoodTower",
    ];

    this._sets = [
      ["HelmetLeather", "ArmorLeatherChest", "ArmorLeatherLegs", "CapeDeerHide"],

      ["chiefhelmboar", "chiefchest", "chieflegs", "CapeDeerHide"],
      ["chiefhelmdeer", "chiefchest", "chieflegs", "CapeDeerHide"],
    ];

    this._archetypes = [
      Gatherer.Instance,
      Hunter.Instance,
      Scout.Instance,
      Woodcutter.Instance,
    ];
  }
}
