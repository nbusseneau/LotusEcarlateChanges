namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes.Meadows;

public class Hunter : MeadowsArchetypeBase
{
  private static readonly Hunter s_instance;
  public static Hunter Instance { get; } = s_instance ??= new Hunter();
  private Hunter()
  {
    this._drops.AddRange([
      // 2-5 necks
      new("NeckTail", 2, 5),

      // 4-8 boars
      new("LeatherScraps", 4, 8),
      new("RawMeat", 4, 8),

      // 3-6 deers
      new("DeerHide", 3, 6),
      new("DeerMeat", 3, 6),

      // 1 fox
      new("FoxPelt_TW"),
      new("FoxMeat_TW"),

      // 2-4 gulls
      new("Feathers", 6, 12),
    ]);
  }
}
