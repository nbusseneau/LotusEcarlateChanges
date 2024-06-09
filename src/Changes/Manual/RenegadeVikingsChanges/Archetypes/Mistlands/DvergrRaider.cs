namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes.Mistlands;

public class DvergrRaider : MistlandsArchetypeBase
{
  private static readonly DvergrRaider s_instance;
  public static DvergrRaider Instance { get; } = s_instance ??= new DvergrRaider();
  private DvergrRaider()
  {
    this._drops.AddRange([
      // 1 dvergr structure
      new("Softtissue", 5, 15),
      new("BlackMarble", 5, 20),
      new("JuteBlue", 5, 10),
      new("DarkCrystal_TW", 2, 4),
      new("Coins", 50, 100),
      new("Lantern", 50f),
      new("DvergrNeedle"),
    ]);
  }
}
