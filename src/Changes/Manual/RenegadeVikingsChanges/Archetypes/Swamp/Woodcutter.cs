namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes.Swamp;

public class Woodcutter : SwampArchetypeBase
{
  private static readonly Woodcutter s_instance;
  public static Woodcutter Instance { get; } = s_instance ??= new Woodcutter();
  private Woodcutter()
  {
    this._drops.AddRange([
      // 1-2 fir
      new("Wood", 10, 20),
      new("FirCone"),
      new("Resin", 1, 3),
      new("Feathers", 1, 3),

      // 3-5 ancient trees, adjusted to ignore half of the regular wood in favor of ancient bark
      new("Wood", 0, 25),
      new("ElderBark", 25, 50),

      // 2-3 gucksacks
      new("Guck", 8, 21),
    ]);
  }
}
