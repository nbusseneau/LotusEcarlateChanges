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
    creatureManager["BrownSpider"].Drops.drops["SpiderFang"].DropChance = 100f;
    creatureManager["TreeSpider"].Drops.drops.Remove("Ooze");
    creatureManager["TreeSpider"].Drops.drops["SpiderFang"].DropChance = 100f;
    creatureManager["GreenSpider"].Drops.drops.Remove("Ooze");
    creatureManager["GreenSpider"].Drops.drops["SpiderFang"].DropChance = 100f;
    creatureManager["Rainbow_Butterfly"].Drops.drops.Remove("Ooze");
    creatureManager["Rainbow_Butterfly"].Drops.drops["Amber"] = new();
    creatureManager["Green_Butterfly"].Drops.drops.Remove("Ooze");
    creatureManager["Green_Butterfly"].Drops.drops["Amber"] = new();

    // Spawns
    creatureManager.Remove([
      "ML_AshHatchling",
      "ML_AshHuldra",
      "ML_FrostHatchling",
      "FireGolem",
    ]);

    creatureManager["TreeSpider"].SpawnChance = 5f;
    creatureManager["TreeSpider"].Maximum = 3;
    creatureManager["TreeSpider"].GroupSize = new(2, 3);
    creatureManager["GreenSpider"].SpawnChance = 5f;
    creatureManager["GreenSpider"].Maximum = 1;

    creatureManager["ML_DraugrShip"].Biome = Heightmap.Biome.Ocean;
    creatureManager["ML_DraugrShip"].RequiredWeather = Weather.None;
    creatureManager["ML_DraugrShip"].SpecificSpawnArea = MonsterLabZ::CreatureManager.SpawnArea.Everywhere;
    creatureManager["ML_GoblinShip"].Biome = Heightmap.Biome.Ocean;
    creatureManager["ML_GoblinShip"].RequiredWeather = Weather.None;
    creatureManager["ML_GoblinShip"].SpecificSpawnArea = MonsterLabZ::CreatureManager.SpawnArea.Everywhere;

    // Locations
    locationManager.Remove([
      "AshHuldraQueen_Altar",
      "AshlandsCave_01",
      "AshlandsCave_02",
      "Mystical_Well0",
    ]);
  }
}
