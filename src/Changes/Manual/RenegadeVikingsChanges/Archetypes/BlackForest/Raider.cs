namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes.BlackForest;

public class Raider : BlackForestArchetypeBase
{
  private static readonly Raider s_instance;
  public static Raider Instance { get; } = s_instance ??= new Raider();
  private Raider()
  {
    this._drops.AddRange([
      // 1 burial chambers
      new("MushroomYellow", 5, 10),
      new("BoneFragments", 15, 30),
      new("Feathers", 10, 20),
      new("ArrowFlint", 30, 60),
      new("Coins", 30, 60),
      new("Amber", 3, 6),
      new("AmberPearl", 2, 4),
      new("Ruby", 1, 3),
      new("SurtlingCore", 3, 7),
    ]);
  }
}
