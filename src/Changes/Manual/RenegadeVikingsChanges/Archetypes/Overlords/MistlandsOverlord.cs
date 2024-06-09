namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes.Overlords;

public class MistlandsOverlord : ArchetypeBase
{
  private static readonly MistlandsOverlord s_instance;
  public static MistlandsOverlord Instance { get; } = s_instance ??= new MistlandsOverlord();
  private MistlandsOverlord()
  {
    this._drops.AddRange([
      new("StaffRedTroll"),
    ]);
  }
}
