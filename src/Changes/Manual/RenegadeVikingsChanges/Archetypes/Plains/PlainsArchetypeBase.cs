namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes.Plains;

public abstract class PlainsArchetypeBase : ArchetypeBase
{
  protected PlainsArchetypeBase()
  {
    this._drops.AddRange([
      // consumables
      new("CookedLoxMeat", 10f),
      new("FishWraps", 10f),
      new("LoxPie", 10f),
      new("BloodPudding", 10f),
      new("Bread", 10f),

      new("BarleyWine", 10f), // fire resist
      new("MeadStaminaMedium", 10f),

      // specials
      new("tankardAnniversary", 5f),

      new("BeltStrength", 1f),
      new("ChickenEgg", 3f),
    ]);
  }
}
