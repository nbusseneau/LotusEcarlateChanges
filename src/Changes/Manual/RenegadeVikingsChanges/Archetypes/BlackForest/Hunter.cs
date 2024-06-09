namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes.BlackForest;

public class Hunter : BlackForestArchetypeBase
{
  private static readonly Hunter s_instance;
  public static Hunter Instance { get; } = s_instance ??= new Hunter();
  private Hunter()
  {
    this._drops.AddRange([
      // 3-6 deers
      new("DeerHide", 3, 6),
      new("DeerMeat", 3, 6),

      // 2-3 razorbacks
      new("RazorbackLeather_TW", 2, 3),
      new("RazorbackTusk_TW", 1, 2),
      new("RawMeat", 2, 3),

      // 1 bear
      new("BlackBearPelt_TW"),
      new("BearSteak_TW"),

      // 1 troll
      new("TrollHide", 5),
      new("TrollBone_TW"),
      new("Coins", 20, 30),
    ]);
  }
}
