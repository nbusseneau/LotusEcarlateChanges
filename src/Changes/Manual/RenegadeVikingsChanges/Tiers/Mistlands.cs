using LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes.Mistlands;

namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Tiers;

public class Mistlands : TierBase
{
  private static readonly Mistlands s_instance;
  public static Mistlands Instance { get; } = s_instance ??= new Mistlands();
  private Mistlands()
  {
    this._weapons = [
      "AtgeirHimminAfl",
      "AxeJotunBane",
      "KnifeSkollAndHati",
      "SpearCarapace",
      "SwordMistwalker",
      "THSwordKrom",

      "BastardDvergr_TW",
      "BattleaxeDvergr_TW",
      "BattlehammerDvergr_TW",
      "BLV_Crossbow",
      "BLV_SpineSnap",
      "FistDvergr_TW",
      "LanceDvergr_TW",
      "SledgeDemolisher_TW",
      "WarpikeDvergr_TW",
    ];

    this._shields = [
      "ShieldCarapace",
      "ShieldCarapaceBuckler",
    ];

    this._sets = [
      ["HelmetCarapace", "ArmorCarapaceChest", "ArmorCarapaceLegs", "CapeLinen", "Demister"],

      ["heavycarhelm", "heavycarchest", "heavycarlegs", "CapeFeather", "Demister"],
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
