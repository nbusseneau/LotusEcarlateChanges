namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes.BlackForest;

public abstract class BlackForestArchetypeBase : ArchetypeBase
{
  protected BlackForestArchetypeBase()
  {
    this._drops.AddRange([
      // chance for fishes to have been picked up near the shore
      new("fish1", 5f),
      new("fish2", 5f),
      new("fish5", 5f),

      // chance for uncommon pickables
      new("CarrotSeeds", 50f, 1, 3),

      // spawners everywhere
      new("GreydwarfEye", 5, 15),
      new("AncientSeed", 1, 3),

      // consumables
      new("BoarJerky", 10f),
      new("DeerStew", 10f),
      new("CookedBearSteak_TW", 10f),
      new("BearJerky_TW", 5f),
      new("CarrotSoup", 5f),
      new("QueensJam", 5f),
      new("MinceMeatSauce", 5f),

      new("MeadTasty", 5f),
      new("MeadHealthMinor", 5f),
      new("MeadStaminaMinor", 5f),

      // specials
      new("Tankard", 5f),

      new("Thunderstone", 5f),
      new("YmirRemains", 5f),
      new("FishingBait", 5f, 1, 5),
      new("FishingRod", 3f),
      new("HelmetDverger", 3f),
      new("BeltStrength", 1f),
    ]);
  }
}
