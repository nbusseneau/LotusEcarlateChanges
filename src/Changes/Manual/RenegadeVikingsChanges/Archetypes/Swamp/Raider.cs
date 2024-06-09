namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes.Swamp;

public class Raider : SwampArchetypeBase
{
  private static readonly Raider s_instance;
  public static Raider Instance { get; } = s_instance ??= new Raider();
  private Raider()
  {
    this._drops.AddRange([
      // 1 crypt, ignoring most of the loot farmed outdoors by scouts
      new("IronScrap", 10, 15),
      new("Chain", 2, 4),
      new("ArrowIron", 30, 60),
      new("ArrowPoison", 30, 60),
      new("WitheredBone", 5, 15),
      new("Coins", 100, 200),
      new("Amber", 10, 20),
      new("AmberPearl", 7, 15),
      new("Ruby", 5, 10),
    ]);
  }
}
