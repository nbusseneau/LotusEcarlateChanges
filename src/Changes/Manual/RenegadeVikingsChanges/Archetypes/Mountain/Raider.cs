namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes.Mountain;

public class Raider : MountainArchetypeBase
{
  private static readonly Raider s_instance;
  public static Raider Instance { get; } = s_instance ??= new Raider();
  private Raider()
  {
    this._drops.AddRange([
      // 1 frost cave
      new("WolfHairBundle", 10, 20),
      new("WolfClaw", 1, 3),
      new("JuteRed", 10, 20),
      new("Crystal", 10, 20),
      new("Coins", 50, 150),
      new("Ruby", 2, 6),
      new("SilverNecklace", 1, 3),

      // chance for rare Tetra fishes
      new("fish4_cave", 1f),
    ]);
  }
}
