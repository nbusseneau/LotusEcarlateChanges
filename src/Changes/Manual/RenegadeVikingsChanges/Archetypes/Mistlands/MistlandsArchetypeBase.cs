namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes.Mistlands;

public abstract class MistlandsArchetypeBase : ArchetypeBase
{
  protected MistlandsArchetypeBase()
  {
    this._drops.AddRange([
      // consumables
      new("cookedbugmeat", 5f),
      new("cookedharemeat", 5f),
      new("Meatplatter", 5f),
      new("HoneyGlazedChicken", 5f),
      new("Mistharesupreme", 5f),
      new("Salad", 5f),
      new("MushroomOmelette", 5f),
      new("fishandbread", 5f),
      new("MagicallyStuffedShroom", 5f),
      new("YggdrasilPorridge", 5f),
      new("SeekerAspic", 5f),

      new("MeadStaminaLingering", 5f),
      new("MeadHealthMajor", 5f),
      new("MeadBaseEitrMinor", 5f),

      // specials
      new("Tankard_dvergr", 5f),
      new("Demister", 3f),

      new("ChickenEgg", 1f),
    ]);
  }
}
