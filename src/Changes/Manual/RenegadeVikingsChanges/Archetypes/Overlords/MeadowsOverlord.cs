namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes.Overlords;

public class MeadowsOverlord : ArchetypeBase
{
  private static readonly MeadowsOverlord s_instance;
  public static MeadowsOverlord Instance { get; } = s_instance ??= new MeadowsOverlord();
  private MeadowsOverlord()
  {
    this._drops.AddRange([
      new("Thunderstone", 5),
      new("YmirRemains", 5),
      new("FishingBait", 5),
      new("FishingRod"),
    ]);
  }
}
