using LotusEcarlateChanges.Model.Reflection;
using LotusEcarlateChanges.Model.Reflection.Plugins;

namespace LotusEcarlateChanges.Changes;

public class MonsterLabZ : ReflectionChangesBase<MonsterLabZPlugin>
{
  protected override void ApplyChangesInternal()
  {
    // Drops
    plugin.CreatureManager["BrownSpider"].Drops.Remove("Ooze");
    plugin.CreatureManager["TreeSpider"].Drops.Remove("Ooze");
    plugin.CreatureManager["GreenSpider"].Drops.Remove("Ooze");
    plugin.CreatureManager["Rainbow_Butterfly"].Drops.Remove("Ooze");
    plugin.CreatureManager["Rainbow_Butterfly"].Drops.Add("Amber");
    plugin.CreatureManager["Green_Butterfly"].Drops.Remove("Ooze");
    plugin.CreatureManager["Green_Butterfly"].Drops.Add("Amber");
  }
}
