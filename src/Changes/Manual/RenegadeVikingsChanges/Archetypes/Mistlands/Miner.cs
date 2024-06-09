namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes.Mistlands;

public class Miner : MistlandsArchetypeBase
{
  private static readonly Miner s_instance;
  public static Miner Instance { get; } = s_instance ??= new Miner();
  private Miner()
  {
    this._drops.AddRange([
      // 1 giant brain
      new("Softtissue", 40, 80),
      new("BlackMarble", 40, 80),
    ]);
  }
}
