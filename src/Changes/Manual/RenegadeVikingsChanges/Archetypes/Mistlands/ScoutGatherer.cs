namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes.Mistlands;

public class ScoutGatherer : MistlandsArchetypeBase
{
  private static readonly ScoutGatherer s_instance;
  public static ScoutGatherer Instance { get; } = s_instance ??= new ScoutGatherer();
  private ScoutGatherer()
  {
    this._drops.AddRange([
      // pickables
      new("MushroomJotunpuffs", 5, 10),
      new("MushroomMagecap", 5, 10),

      // small minables
      new("CopperScrap", 3, 8),
      new("IronScrap", 3, 8),

      // 4-8 dvergr
      new("Coins", 10, 75),
      new("BlackMarble", 2, 4),
      new("Softtissue", 2, 4),
      new("DarkCrystal_TW", 1, 2),

      // 4-8 seekers
      new("bugmeat", 4, 8),
      new("Carapace", 4, 8),
      new("DarkCrystal_TW", 1, 2),
      new("VenomousFang_TW", 1, 2),

      // 1-2 seeker soldiers
      new("bugmeat", 1, 2),
      new("Carapace", 2, 6),
      new("Mandible", 1, 2),
      new("DarkCrystal_TW", 0, 1),
      new("VenomousFang_TW", 0, 1),

      // 1 gjall
      new("Bilebag"),
      new("DarkCrystal_TW", 0, 1),
      new("VenomousFang_TW"),

      // 4-8 ticks
      new("GiantBloodSack", 4, 8),
      new("VenomousFang_TW"),

      // 4-8 hares
      new("ScaleHide", 4, 16),
      new("haremeat", 4, 8),

      // chance for fishes to have been picked up near the shore
      new("fish9", 5f),
    ]);
  }
}
