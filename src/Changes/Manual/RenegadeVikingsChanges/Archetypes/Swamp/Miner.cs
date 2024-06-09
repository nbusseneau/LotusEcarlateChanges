namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes.Swamp;

public class Miner : SwampArchetypeBase
{
  private static readonly Miner s_instance;
  public static Miner Instance { get; } = s_instance ??= new Miner();
  private Miner()
  {
    this._drops.AddRange([
      // ores
      new("IronScrap", 25, 30),

      // additional chance for Megingjord
      new("BeltStrength", 4f),
    ]);
  }
}
