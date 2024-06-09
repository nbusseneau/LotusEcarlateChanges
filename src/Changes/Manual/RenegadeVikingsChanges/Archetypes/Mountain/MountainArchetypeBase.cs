namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes.Mountain;

public abstract class MountainArchetypeBase : ArchetypeBase
{
  protected MountainArchetypeBase()
  {
    this._drops.AddRange([
      // consumables
      new("OnionSoup", 10f),
      new("CookedWolfMeat", 10f),
      new("Wolfjerky", 5f),
      new("WolfMeatSkewer", 5f),
      new("Eyescream", 5f),
      new("CookedEgg", 5f),
      new("CookedChickenMeat", 5f),
      new("MixedGrill_TW", 5f),

      new("MeadFrostResist", 10f),
      new("MeadHealthMedium", 5f),
      new("MeadStaminaMinor", 5f),

      // specials
      new("tankardAnniversary", 5f),
      new("Wishbone", 3f),

      new("FishingBait", 5f, 1, 5),
      new("FishingRod", 3f),
      new("BeltStrength", 1f),
      new("ChickenEgg", 1f),
    ]);
  }
}
