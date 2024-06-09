namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes.Plains;

public class Raider : PlainsArchetypeBase
{
  private static readonly Raider s_instance;
  public static Raider Instance { get; } = s_instance ??= new Raider();
  private Raider()
  {
    this._drops.AddRange([
      // 1-2 fuling villages
      new("BlackMetalScrap", 20, 30),
      new("Coins", 150, 300),
      new("Barley", 20, 40),
      new("Flax", 10, 20),
      new("Needle", 4, 10),

      // chance for boss summoning item
      new("GoblinTotem", 5f),
    ]);
  }
}
