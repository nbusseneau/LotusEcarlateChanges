extern alias MonsterLabZ;

using LotusEcarlateChanges.Model.Changes;
using MonsterLabZ::CreatureManager;

namespace LotusEcarlateChanges.Changes.StandaloneManagerBased;

public class MonsterLabZ : StandaloneManagerBasedChangesBase
{
  protected override void ApplyInternal()
  {
    var creatureManager = this.RegisterCreatureManager(Creature.registeredCreatures, PrefabManager.prefabs);
    var locationManager = this.RegisterLocationManager(MonsterLabZ::LocationManager.Location.registeredLocations);

    // Drops
    creatureManager["BrownSpider"].Drops.drops.Remove("Ooze");
    creatureManager["TreeSpider"].Drops.drops.Remove("Ooze");
    creatureManager["GreenSpider"].Drops.drops.Remove("Ooze");
    creatureManager["Rainbow_Butterfly"].Drops.drops.Remove("Ooze");
    creatureManager["Rainbow_Butterfly"].Drops.drops["Amber"] = new();
    creatureManager["Green_Butterfly"].Drops.drops.Remove("Ooze");
    creatureManager["Green_Butterfly"].Drops.drops["Amber"] = new();

    // Spawns
    creatureManager.Remove([
      "ML_AshHatchling",
      "ML_AshHuldra",
      "FireGolem",
    ]);

    // Locations
    locationManager.Remove([
      "AshHuldraQueen_Altar",
      "AshlandsCave_01",
      "AshlandsCave_02",
      "Mystical_Well0",
    ]);
  }
}
