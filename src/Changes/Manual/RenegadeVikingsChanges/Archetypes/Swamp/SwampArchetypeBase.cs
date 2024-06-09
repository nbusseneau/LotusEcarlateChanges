namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes.Swamp;

public abstract class SwampArchetypeBase : ArchetypeBase
{
  protected SwampArchetypeBase()
  {
    this._drops.AddRange([
      // chance for fishes to have been picked up near the shore
      new("fish6", 5f),

      // chance for uncommon pickables
      new("TurnipSeeds", 50f, 1, 3),

      // consumables
      new("Sausages", 20f),
      new("ShocklateSmoothie", 10f),
      new("TurnipStew", 10f),
      new("BlackSoup", 10f),

      new("MeadPoisonResist", 10f),
      new("MeadHealthMedium", 5f),
      new("MeadStaminaMinor", 5f),

      // specials
      new("Tankard", 5f),

      new("HelmetDverger", 3f),
      new("BeltStrength", 1f),
    ]);
  }
}
