extern alias Monstrum;

using System.Linq;
using LotusEcarlateChanges.Model.Changes;
using Monstrum::CreatureManager;
using Monstrum::ItemManager;
using Monstrum::PieceManager;

namespace LotusEcarlateChanges.Changes.StandaloneManagerBased;

public class Monstrum : StandaloneManagerBasedChangesBase
{
  protected override void ApplyInternal()
  {
    var itemManager = this.RegisterItemManager(Item.registeredItems, Monstrum::ItemManager.PrefabManager.prefabs, Monstrum::ItemManager.PrefabManager.ZnetOnlyPrefabs);
    var pieceManager = this.RegisterPieceManager(BuildPiece.registeredPieces, PiecePrefabManager.piecePrefabs);
    var creatureManager = this.RegisterCreatureManager(Creature.registeredCreatures, Creature.registeredSpawners, Monstrum::CreatureManager.PrefabManager.prefabs);

    // Rugs
    var (foxRug, foxRugWrapper) = pieceManager["rug_Fox_TW"];
    foxRug.RequiredItems.Requirements.Clear();
    foxRug.RequiredItems.Add("FoxPelt_TW", 4, true);
    foxRug.Category.Set(BuildPieceCategory.Furniture);
    foxRugWrapper.Comfort.Value = 1;
    foxRugWrapper.Comfort.Group = Piece.ComfortGroup.Carpet;

    var (rottenRug, rottenRugWrapper) = pieceManager["rug_Rotten_TW"];
    rottenRug.RequiredItems.Requirements.Clear();
    rottenRug.RequiredItems.Add("RottenPelt_TW", 4, true);
    rottenRug.Category.Set(BuildPieceCategory.Furniture);
    rottenRugWrapper.Comfort = foxRugWrapper.Comfort;

    var (bearRug, bearRugWrapper) = pieceManager["rug_BlackBear_TW"];
    bearRug.RequiredItems.Requirements.Clear();
    bearRug.RequiredItems.Add("BlackBearPelt_TW", 4, true);
    bearRug.Category.Set(BuildPieceCategory.Furniture);
    bearRugWrapper.Comfort = foxRugWrapper.Comfort;

    var (grizzlyRug, grizzlyRugWrapper) = pieceManager["rug_GrizzlyBear_TW"];
    grizzlyRug.RequiredItems.Requirements.Clear();
    grizzlyRug.RequiredItems.Add("GrizzlyBearPelt_TW", 4, true);
    grizzlyRug.Category.Set(BuildPieceCategory.Furniture);
    grizzlyRugWrapper.Comfort = foxRugWrapper.Comfort;

    // Saddles
    var saddleBoar = itemManager["SaddleBoar_TW"].Item;
    saddleBoar.Crafting.Stations.Clear();
    saddleBoar.Crafting.Add(Monstrum::ItemManager.CraftingTable.Workbench, 2);
    saddleBoar.RequiredItems.Requirements.Clear();
    saddleBoar.RequiredItems.Add("RazorbackLeather_TW", 10);
    saddleBoar.RequiredItems.Add("RazorbackTusk_TW", 12);
    saddleBoar.RequiredItems.Add("Bronze", 10);

    var saddleBear = itemManager["SaddleBear_TW"].Item;
    saddleBear.Crafting.Stations.Clear();
    saddleBear.Crafting.Add(Monstrum::ItemManager.CraftingTable.Workbench, 3);
    saddleBear.RequiredItems.Requirements.Clear();
    saddleBear.RequiredItems.Add("BlackBearPelt_TW", 10);
    saddleBear.RequiredItems.Add("GrizzlyBearPelt_TW", 10);
    saddleBear.RequiredItems.Add("Silver", 10);

    var saddleProwler = itemManager["SaddleProwler_TW"].Item;
    saddleProwler.Crafting.Stations.Clear();
    saddleProwler.Crafting.Add(Monstrum::ItemManager.CraftingTable.Workbench, 4);
    saddleProwler.RequiredItems.Requirements.Clear();
    saddleProwler.RequiredItems.Add("ProwlerFang_TW", 10);
    saddleProwler.RequiredItems.Add("LinenThread", 20);
    saddleProwler.RequiredItems.Add("LoxPelt", 4);
    saddleProwler.RequiredItems.Add("BlackMetal", 10);

    // Food
    var cookedBearSteak = itemManager["CookedBearSteak_TW"].Wrapper;
    cookedBearSteak.Food.Stamina = 13;
    cookedBearSteak.Food.Duration = 1200;

    var mixedGrill = itemManager["MixedGrill_TW"].Wrapper;
    mixedGrill.Food.Health = 70;
    mixedGrill.Food.Stamina = 23;

    // Drops
    creatureManager["BossAsmodeus_TW"].Creature.Drops.drops.Remove("KnifeViper_TW");
    creatureManager["BossSvalt_TW"].Creature.Drops.drops.Remove("DualAxeDemonic_TW");
    creatureManager["BossVrykolathas_TW"].Creature.Drops.drops.Remove("ScytheVampiric_TW");

    creatureManager["Fox_TW"].Creature.Drops["FoxMeat_TW"].DropChance = 100f;
    creatureManager["Razorback_TW"].Creature.Drops["RawMeat"].Amount = new Range(1, 2);
    creatureManager["Razorback_TW"].Creature.Drops["RawMeat"].DropChance = 100f;
    creatureManager["BlackBear_TW"].Creature.Drops["BearSteak_TW"].DropChance = 100f;
    creatureManager["GrizzlyBear_TW"].Creature.Drops["GrizzlyBearPelt_TW"].DropChance = 100f;
    creatureManager["GrizzlyBear_TW"].Creature.Drops["BearSteak_TW"].DropChance = 100f;
    creatureManager["Prowler_TW"].Creature.Drops["ProwlerFang_TW"].DropChance = 100f;

    // Spawns
    var razorbackSpawner = creatureManager["Razorback_TW"].Spawners.Single();
    razorbackSpawner.CheckSpawnInterval = 150;
    razorbackSpawner.SpawnChance = 40f;
    razorbackSpawner.Maximum = 3;

    foreach (var spawner in creatureManager["BlackBear_TW"].Spawners) spawner.SpawnChance = 7f;
  }
}
