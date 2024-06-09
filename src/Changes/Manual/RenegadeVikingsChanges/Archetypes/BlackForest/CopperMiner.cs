namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes.BlackForest;

public class CopperMiner : BlackForestArchetypeBase
{
  private static readonly CopperMiner s_instance;
  public static CopperMiner Instance { get; } = s_instance ??= new CopperMiner();
  private CopperMiner()
  {
    this._drops.AddRange([
      // ores
      new("CopperOre", 20, 30),
    ]);
  }
}
