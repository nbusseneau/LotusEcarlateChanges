namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes.Meadows;

public class Scout : MeadowsArchetypeBase
{
  private static readonly Scout s_instance;
  public static Scout Instance { get; } = s_instance ??= new Scout();
  private Scout()
  {
    this._drops.AddRange([
      // some bones from dolmens
      new("BoneFragments", 3, 6),

      // 1-3 outdoors chests
      new("Amber", 1, 3),
      new("ArrowFlint", 30, 60),
      new("Coins", 15, 45),
      new("Feathers", 3, 9),
      new("Flint", 6, 12),

      // 1 beehive
      new("Honey", 2, 3),
      new("QueenBee"),
    ]);
  }
}
