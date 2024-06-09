namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes.BlackForest;

public class Woodcutter : BlackForestArchetypeBase
{
  private static readonly Woodcutter s_instance;
  public static Woodcutter Instance { get; } = s_instance ??= new Woodcutter();
  private Woodcutter()
  {
    this._drops.AddRange([
      // 1 pine and a half, adjusted to ignore half of the regular wood in favor of core wood
      new("Wood", 0, 15),
      new("RoundLog", 30, 45),
      new("PineCone", 1, 2),
      new("Resin", 1, 3),
      new("Feathers", 1, 3),

      // 1 birch, adjusted to ignore half of the regular wood in favor of fine wood
      new("Wood", 0, 10),
      new("FineWood", 10, 20),
      new("BirchSeeds"),
      new("Resin"),
      new("Feathers"),

      // half-oak, adjusted to ignore half of the regular wood in favor of fine wood
      new("Wood", 0, 12),
      new("FineWood", 12, 25),
      new("Acorn"),
      new("Resin", 1, 2),
      new("Feathers"),
    ]);
  }
}
