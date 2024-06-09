namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes.Mistlands;

public class Woodcutter : MistlandsArchetypeBase
{
  private static readonly Woodcutter s_instance;
  public static Woodcutter Instance { get; } = s_instance ??= new Woodcutter();
  private Woodcutter()
  {
    this._drops.AddRange([
      // 2-3 yggdrasil shoots, adjusted to ignore half of the regular wood in favor of yggdrasil wood
      new("Wood", 0, 30),
      new("YggdrasilWood", 40, 60),
      new("Resin", 2, 3),
      new("Feathers", 2, 3),
    ]);
  }
}
