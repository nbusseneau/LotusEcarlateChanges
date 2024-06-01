extern alias BowsBeforeHoes;

using BowsBeforeHoes::BowsBeforeHoes;
using BowsBeforeHoes::ItemManager;
using LotusEcarlateChanges.Model.Changes;

namespace LotusEcarlateChanges.Changes.StandaloneManagerBased;

public class BowsBeforeHoes : StandaloneManagerBasedChangesBase
{
  protected override void ApplyInternal()
  {
    var itemManager = this.RegisterItemManager(Item.registeredItems, PrefabManager.prefabs, PrefabManager.ZnetOnlyPrefabs);

    // Clear existing lists
    BowsBeforeHoesPlugin.QuiverList.Clear();
    BowsBeforeHoesPlugin.BowList.Clear();

    // Quivers
    itemManager.Keep([
      "BBH_BlackForest_Quiver",
      "BBH_PlainsLox_Quiver",
      "BBH_Seeker_Quiver",
    ]);

    var blackForestQuiver = itemManager["BBH_BlackForest_Quiver"].Item;
    blackForestQuiver.RequiredItems.Requirements.Clear();
    blackForestQuiver.RequiredItems.Add("FineWood", 10);
    blackForestQuiver.RequiredItems.Add("RoundLog", 10);
    blackForestQuiver.RequiredItems.Add("DeerHide", 2);
    blackForestQuiver.RequiredItems.Add("HardAntler", 1);
    blackForestQuiver.RequiredUpgradeItems.Requirements.Clear();
    blackForestQuiver.RequiredUpgradeItems.Add("FineWood", 5);
    blackForestQuiver.RequiredUpgradeItems.Add("RoundLog", 5);
    blackForestQuiver.RequiredUpgradeItems.Add("DeerHide", 2);
    blackForestQuiver.RequiredUpgradeItems.Add("HardAntler", 1);
    BowsBeforeHoesPlugin.QuiverList.Add(blackForestQuiver.Prefab);

    var loxQuiver = itemManager["BBH_PlainsLox_Quiver"].Item;
    loxQuiver.RequiredItems.Requirements.Clear();
    loxQuiver.RequiredItems.Add("FineWood", 10);
    loxQuiver.RequiredItems.Add("LinenThread", 20);
    loxQuiver.RequiredItems.Add("LoxPelt", 3);
    loxQuiver.RequiredUpgradeItems.Requirements.Clear();
    loxQuiver.RequiredUpgradeItems.Add("FineWood", 5);
    loxQuiver.RequiredUpgradeItems.Add("LinenThread", 10);
    loxQuiver.RequiredUpgradeItems.Add("LoxPelt", 3);
    BowsBeforeHoesPlugin.QuiverList.Add(loxQuiver.Prefab);

    var seekerQuiver = itemManager["BBH_Seeker_Quiver"].Item;
    seekerQuiver.RequiredItems.Requirements.Clear();
    seekerQuiver.RequiredItems.Add("YggdrasilWood", 10);
    seekerQuiver.RequiredItems.Add("Carapace", 20);
    seekerQuiver.RequiredItems.Add("Mandible", 2);
    seekerQuiver.RequiredUpgradeItems.Requirements.Clear();
    seekerQuiver.RequiredUpgradeItems.Add("YggdrasilWood", 5);
    seekerQuiver.RequiredUpgradeItems.Add("Carapace", 10);
    seekerQuiver.RequiredUpgradeItems.Add("Mandible", 2);
    BowsBeforeHoesPlugin.QuiverList.Add(seekerQuiver.Prefab);

    // Arrows
    itemManager.Keep([
      "TorchArrow",
      "MistTorchArrow",
    ]);

    var torchArrow = itemManager["TorchArrow"].Item;
    torchArrow.RequiredItems.Requirements.Clear();
    torchArrow.RequiredItems.Add("Wood", 8);
    torchArrow.RequiredItems.Add("Resin", 8);
    torchArrow.RequiredItems.Add("Feathers", 2);
    torchArrow.RequiredItems.Add("Tar", 1);
    torchArrow.Crafting.Stations.Clear();
    torchArrow.Crafting.Add(CraftingTable.Workbench, 3);

    var mistTorchArrow = itemManager["MistTorchArrow"].Item;
    mistTorchArrow.RequiredItems.Requirements.Clear();
    mistTorchArrow.RequiredItems.Add("Wood", 8);
    mistTorchArrow.RequiredItems.Add("Resin", 8);
    mistTorchArrow.RequiredItems.Add("Feathers", 2);
    mistTorchArrow.RequiredItems.Add("Eitr", 1);
    mistTorchArrow.Crafting.Stations.Clear();
    mistTorchArrow.Crafting.Add(CraftingTable.BlackForge, 1);
  }
}
