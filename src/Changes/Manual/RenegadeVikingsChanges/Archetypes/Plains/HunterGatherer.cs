namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes.Plains;

public class HunterGatherer : PlainsArchetypeBase
{
  private static readonly HunterGatherer s_instance;
  public static HunterGatherer Instance { get; } = s_instance ??= new HunterGatherer();
  private HunterGatherer()
  {
    this._drops.AddRange([
      // pickables
      new("Cloudberry", 30, 60),

      // 2-3 lox
      new("LoxPelt", 4, 6),
      new("LoxMeat", 8, 12),
      new("LoxBone_TW", 2, 3),

      // 3-6 deathsquitos
      new("Needle", 3, 6),

      // 1 prowler
      new("ProwlerFang_TW"),

      // 3-6 growths
      new("Tar", 3, 6),

      new("fish7", 0.1f, 1, 1),
    ]);
  }
}
