extern alias MonsterLabZ;

using LotusEcarlateChanges.Model.Changes;
using MonsterLabZ::ItemManager;
using MonsterLabZ::CreatureManager;

namespace LotusEcarlateChanges.Changes.StandaloneManagerBased;

public class MonsterLabZ : StandaloneManagerBasedChangesBase
{
  protected override void ApplyInternal()
  {
    var itemManager = this.RegisterItemManager(Item.registeredItems, MonsterLabZ::ItemManager.PrefabManager.prefabs, MonsterLabZ::ItemManager.PrefabManager.ZnetOnlyPrefabs);
    var creatureManager = this.RegisterCreatureManager(Creature.registeredCreatures, MonsterLabZ::CreatureManager.PrefabManager.prefabs);
    var locationManager = this.RegisterLocationManager(MonsterLabZ::LocationManager.Location.registeredLocations);

    // Damage
    var dwarfGoblinShamanFireballDamages = itemManager["DwarfGoblinShaman_attack_fireball"].Wrapper.Weapon.Damages;
    dwarfGoblinShamanFireballDamages.m_fire = 50f;
    itemManager["DwarfGoblinShaman_attack_fireball"].Wrapper.Weapon.Damages = dwarfGoblinShamanFireballDamages;

    var dwarfGoblinShamanBoatFireballDamages = itemManager["DwarfGoblinShamanBoat_attack_fireball"].Wrapper.Weapon.Damages;
    dwarfGoblinShamanBoatFireballDamages.m_fire = 50f;
    itemManager["DwarfGoblinShamanBoat_attack_fireball"].Wrapper.Weapon.Damages = dwarfGoblinShamanBoatFireballDamages;

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

    creatureManager["DwarfGoblin"].Drops.drops["Coins"].Amount = new(0, 15);
    creatureManager["DwarfGoblin"].Drops.drops["Amber"] = new() { Amount = new(0, 3) };
    creatureManager["DwarfGoblin"].Drops.drops["Ruby"] = new() { DropChance = 50f };

    creatureManager["DwarfGoblinShaman"].Drops.drops["Coins"].Amount = new(0, 25);
    creatureManager["DwarfGoblinShaman"].Drops.drops["Amber"] = new() { Amount = new(0, 3) };
    creatureManager["DwarfGoblinShaman"].Drops.drops["Ruby"] = new() { DropChance = 50f };

    // Spawns
    creatureManager.Remove([
      "ML_AshHatchling",
      "ML_AshHuldra",
      "ML_FrostHatchling",
      "FireGolem",
      "ObsidianGolem",
      "DwarfGoblinLoot",
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

    creatureManager["DwarfGoblin"].GroupSize = new(2, 4);
    creatureManager["DwarfGoblin"].Maximum = 4;
    creatureManager["DwarfGoblinShaman"].CanHaveStars = false;

    // Locations
    locationManager.Remove([
      "AshHuldraQueen_Altar",
      "AshlandsCave_01",
      "AshlandsCave_02",
      "Mystical_Well0",
    ]);
  }
}
