namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes.Mountain;

public class Miner : MountainArchetypeBase
{
  private static readonly Miner s_instance;
  public static Miner Instance { get; } = s_instance ??= new Miner();
  private Miner()
  {
    this._drops.AddRange([
      // ores
      new("SilverOre", 20, 30),

      // additional chance for Megingjord
      new("BeltStrength", 4f),
    ]);
  }
}
