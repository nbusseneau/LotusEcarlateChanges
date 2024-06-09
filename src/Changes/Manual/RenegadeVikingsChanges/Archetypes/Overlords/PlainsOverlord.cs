namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes.Overlords;

public class PlainsOverlord : ArchetypeBase
{
  private static readonly PlainsOverlord s_instance;
  public static PlainsOverlord Instance { get; } = s_instance ??= new PlainsOverlord();
  private PlainsOverlord()
  {
    this._drops.AddRange([
      new("THSwordKrom"),
    ]);
  }
}
