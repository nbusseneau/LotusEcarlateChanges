namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes.Overlords;

public class MountainOverlord : ArchetypeBase
{
  private static readonly MountainOverlord s_instance;
  public static MountainOverlord Instance { get; } = s_instance ??= new MountainOverlord();
  private MountainOverlord()
  {
    this._drops.AddRange([
      new("ChickenEgg", 2),
    ]);
  }
}
