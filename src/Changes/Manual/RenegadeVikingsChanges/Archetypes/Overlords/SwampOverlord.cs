namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes.Overlords;

public class SwampOverlord : ArchetypeBase
{
  private static readonly SwampOverlord s_instance;
  public static SwampOverlord Instance { get; } = s_instance ??= new SwampOverlord();
  private SwampOverlord()
  {
    this._drops.AddRange([
      new("BeltStrength"),
    ]);
  }
}
