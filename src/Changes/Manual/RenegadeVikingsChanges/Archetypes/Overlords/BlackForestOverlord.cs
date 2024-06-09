namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes.Overlords;

public class BlackForestOverlord : ArchetypeBase
{
  private static readonly BlackForestOverlord s_instance;
  public static BlackForestOverlord Instance { get; } = s_instance ??= new BlackForestOverlord();
  private BlackForestOverlord()
  {
    this._drops.AddRange([
      new("HelmetDverger"),
    ]);
  }
}
