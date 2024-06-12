namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes.Meadows;

public class Gatherer : MeadowsArchetypeBase
{
  private static readonly Gatherer s_instance;
  public static Gatherer Instance { get; } = s_instance ??= new Gatherer();
  private Gatherer()
  {
    this._drops.AddRange([
      // pickables
      new("Stone", 20, 40),
      new("BFP_Clay", 20, 40),
      new("Flint", 15, 30),
      new("BFP_Straw", 15, 30),
      new("Raspberry", 5, 10),
      new("Mushroom", 5, 10),
      new("Dandelion", 3, 6),

      // additional chance for fishes to have been picked up near the shore
      new("fish1", 5f),
      new("fish2", 5f),
    ]);
  }
}
