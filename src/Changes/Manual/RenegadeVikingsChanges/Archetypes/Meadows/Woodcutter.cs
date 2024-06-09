namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes.Meadows;

public class Woodcutter : MeadowsArchetypeBase
{
  private static readonly Woodcutter s_instance;
  public static Woodcutter Instance { get; } = s_instance ??= new Woodcutter();
  private Woodcutter()
  {
    this._drops.AddRange([
      // 2-3 beeches
      new("Wood", 40, 60),
      new("BeechSeeds", 3, 5),
      new("Resin", 1, 3),
      new("Feathers", 1, 3),

      // 1 pine, adjusted to ignore half of the regular wood in favor of core wood
      new("Wood", 0, 15),
      new("RoundLog", 15, 30),
      new("PineCone"),
      new("Resin"),
      new("Feathers"),
    ]);
  }
}
