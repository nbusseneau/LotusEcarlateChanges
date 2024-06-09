namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes.BlackForest;

public class TinGatherer : BlackForestArchetypeBase
{
  private static readonly TinGatherer s_instance;
  public static TinGatherer Instance { get; } = s_instance ??= new TinGatherer();
  private TinGatherer()
  {
    this._drops.AddRange([
      // ores
      new("TinOre", 10, 15),

      // pickables
      new("Mushroom", 5, 10),
      new("Blueberries", 5, 10),
      new("Thistle", 3, 6),
    ]);
  }
}
