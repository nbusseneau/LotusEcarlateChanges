namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes.Mountain;

public class ScoutGatherer : MountainArchetypeBase
{
  private static readonly ScoutGatherer s_instance;
  public static ScoutGatherer Instance { get; } = s_instance ??= new ScoutGatherer();
  private ScoutGatherer()
  {
    this._drops.AddRange([
      // 5-10 wolf
      new("WolfMeat", 5, 10),
      new("WolfPelt", 5, 10),
      new("WolfFang", 2, 4),

      // 3-5 drakes
      new("FreezeGland", 3, 5),

      // 1 stone golem
      new("Crystal", 8, 12), 

      // 1 grizzly
      new("GrizzlyBearPelt_TW"),
      new("BearSteak_TW"),

      // 1-3 outdoors chests
      new("ArrowFrost", 15, 30),
      new("OnionSeeds", 50f, 1, 3),
      new("Obsidian", 15, 30),
      new("Coins", 150, 300),
      new("Amber", 3, 18),
      new("AmberPearl", 6, 15),
      new("Ruby", 3, 6),

      // chance for boss summoning item
      new("DragonEgg", 5f),
    ]);
  }
}
