extern alias MonsterLabZ;

using LotusEcarlateChanges.Model.Changes;
using MonsterLabZ::CreatureManager;

namespace LotusEcarlateChanges.Changes.StandaloneManagerBased;

public class MonsterLabZ : StandaloneManagerBasedChangesBase
{
  protected override void ApplyInternal()
  {
    var creatureManager = this.RegisterCreatureManager(Creature.registeredCreatures, PrefabManager.prefabs);

    // Drops
    creatureManager["BrownSpider"].Drops.drops.Remove("Ooze");
    creatureManager["TreeSpider"].Drops.drops.Remove("Ooze");
    creatureManager["GreenSpider"].Drops.drops.Remove("Ooze");
    creatureManager["Rainbow_Butterfly"].Drops.drops.Remove("Ooze");
    creatureManager["Rainbow_Butterfly"].Drops.drops["Amber"] = new();
    creatureManager["Green_Butterfly"].Drops.drops.Remove("Ooze");
    creatureManager["Green_Butterfly"].Drops.drops["Amber"] = new();
  }
}
