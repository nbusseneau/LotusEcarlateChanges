namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes.Mistlands;

public class BugRaider : MistlandsArchetypeBase
{
  private static readonly BugRaider s_instance;
  public static BugRaider Instance { get; } = s_instance ??= new BugRaider();
  private BugRaider()
  {
    this._drops.AddRange([
      // 1 infested mine
      new("bugmeat", 10, 20),
      new("Carapace", 20, 40),
      new("Mandible", 4, 8),
      new("VenomousFang_TW", 2, 4),
      new("DarkCrystal_TW", 1, 3),
      new("GiantBloodSack", 5, 15),
      new("RoyalJelly", 25, 50),
      new("Coins", 50, 150),
      new("Lantern", 50f),
      new("DvergrKeyFragment", 1, 3),
      new("BlackCore", 3, 8),
    ]);
  }
}
