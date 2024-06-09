namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes.Swamp;

public class ScoutGatherer : SwampArchetypeBase
{
  private static readonly ScoutGatherer s_instance;
  public static ScoutGatherer Instance { get; } = s_instance ??= new ScoutGatherer();
  private ScoutGatherer()
  {
    this._drops.AddRange([
      // pickables
      new("Mushroom", 5, 10),
      new("Thistle", 4, 8),

      // 1-2 rotten elks
      new("RottenPelt_TW", 1, 2),
      new("RottingElkMeat_TW", 50f),

      // 5-10 draugrs
      new("Entrails", 5, 10),

      // 1-2 blobs
      new("Ooze", 1, 2),

      // 3-6 leeches
      new("Bloodbag", 3, 6),

      // 3-4 surtlings
      new("SurtlingCore", 1, 2),

      // 1-3 outdoors chests
      new("Chain", 1, 3),
      new("ArrowIron", 30, 45),
      new("ArrowPoison", 30, 45),
      new("WitheredBone", 1, 3),
      new("Coins", 60, 180),
      new("Amber", 3, 15),
      new("AmberPearl", 3, 9),
      new("Ruby", 3, 9),

      // 1 abomination
      new("Root", 5),
      new("Guck", 3, 4),
    ]);
  }
}
