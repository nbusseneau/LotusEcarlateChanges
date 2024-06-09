namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes.Meadows;

public abstract class MeadowsArchetypeBase : ArchetypeBase
{
  protected MeadowsArchetypeBase()
  {
    this._drops.AddRange([
      // chance for fishes to have been picked up near the shore
      new("fish1", 5f),
      new("fish2", 5f),

      // consumables
      new("NeckTailGrilled", 10f),
      new("CookedMeat", 10f),
      new("CookedDeerMeat", 10f),
      new("CookedFoxMeat_TW", 10f),
      new("FoxJerky_TW", 10f),

      // specials
      new("HardAntler", 5f),
    ]);
  }
}
