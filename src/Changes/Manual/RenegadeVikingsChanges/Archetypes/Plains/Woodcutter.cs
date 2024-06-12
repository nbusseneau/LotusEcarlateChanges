namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes.Plains;

public class Woodcutter : PlainsArchetypeBase
{
  private static readonly Woodcutter s_instance;
  public static Woodcutter Instance { get; } = s_instance ??= new Woodcutter();
  private Woodcutter()
  {
    this._drops.AddRange([
      // 3-4 birches, adjusted to ignore half of the regular wood in favor of fine wood
      new("Wood", 0, 40),
      new("FineWood", 40, 80),
      new("BirchSeeds", 2, 3),
      new("Resin", 2, 4),
      new("Feathers", 2, 4),
    ]);
  }
}
