extern alias Monstrum;

using LotusEcarlateChanges.Extensions;
using LotusEcarlateChanges.Model.Changes;
using Monstrum::CreatureManager;
using Monstrum::ItemManager;
using Monstrum::PieceManager;

namespace LotusEcarlateChanges.Changes.Manager;

public class Monstrum : ManagerChangesBase
{
  protected override void ApplyInternal()
  {
    var itemManager = this.RegisterItemManager(Item.registeredItems, Monstrum::ItemManager.PrefabManager.prefabs, Monstrum::ItemManager.PrefabManager.ZnetOnlyPrefabs);
    var pieceManager = this.RegisterPieceManager(BuildPiece.registeredPieces, PiecePrefabManager.piecePrefabs);
    var creatureManager = this.RegisterCreatureManager(Creature.registeredCreatures, Monstrum::CreatureManager.PrefabManager.prefabs);

    // Rugs
    var foxRug = pieceManager["rug_Fox_TW"];
    foxRug.RequiredItems.Requirements.Clear();
    foxRug.RequiredItems.Add("FoxPelt_TW", 4, true);
    foxRug.Category.Set(BuildPieceCategory.Furniture);
    var foxRugPiece = foxRug.Piece();
    foxRugPiece.Comfort.Value = 1;
    foxRugPiece.Comfort.Group = Piece.ComfortGroup.Carpet;

    var rottenRug = pieceManager["rug_Rotten_TW"];
    rottenRug.RequiredItems.Requirements.Clear();
    rottenRug.RequiredItems.Add("RottenPelt_TW", 4, true);
    rottenRug.Category.Set(BuildPieceCategory.Furniture);
    rottenRug.Piece().Comfort = foxRugPiece.Comfort;

    var bearRug = pieceManager["rug_BlackBear_TW"];
    bearRug.RequiredItems.Requirements.Clear();
    bearRug.RequiredItems.Add("BlackBearPelt_TW", 4, true);
    bearRug.Category.Set(BuildPieceCategory.Furniture);
    bearRug.Piece().Comfort = foxRugPiece.Comfort;

    var grizzlyRug = pieceManager["rug_GrizzlyBear_TW"];
    grizzlyRug.RequiredItems.Requirements.Clear();
    grizzlyRug.RequiredItems.Add("GrizzlyBearPelt_TW", 4, true);
    grizzlyRug.Category.Set(BuildPieceCategory.Furniture);
    grizzlyRug.Piece().Comfort = foxRugPiece.Comfort;

    // Saddles
    var saddleBoar = itemManager["SaddleBoar_TW"];
    saddleBoar.Crafting.Stations.Clear();
    saddleBoar.Crafting.Add(Monstrum::ItemManager.CraftingTable.Workbench, 2);
    saddleBoar.RequiredItems.Requirements.Clear();
    saddleBoar.RequiredItems.Add("RazorbackLeather_TW", 10);
    saddleBoar.RequiredItems.Add("RazorbackTusk_TW", 12);
    saddleBoar.RequiredItems.Add("Bronze", 10);

    var saddleBear = itemManager["SaddleBear_TW"];
    saddleBear.Crafting.Stations.Clear();
    saddleBear.Crafting.Add(Monstrum::ItemManager.CraftingTable.Workbench, 3);
    saddleBear.RequiredItems.Requirements.Clear();
    saddleBear.RequiredItems.Add("BlackBearPelt_TW", 10);
    saddleBear.RequiredItems.Add("GrizzlyBearPelt_TW", 10);
    saddleBear.RequiredItems.Add("Silver", 10);

    var saddleProwler = itemManager["SaddleProwler_TW"];
    saddleProwler.Crafting.Stations.Clear();
    saddleProwler.Crafting.Add(Monstrum::ItemManager.CraftingTable.Workbench, 4);
    saddleProwler.RequiredItems.Requirements.Clear();
    saddleProwler.RequiredItems.Add("ProwlerFang_TW", 10);
    saddleProwler.RequiredItems.Add("LinenThread", 20);
    saddleProwler.RequiredItems.Add("LoxPelt", 4);
    saddleProwler.RequiredItems.Add("BlackMetal", 10);

    // Food
    var cookedBearSteak = itemManager["CookedBearSteak_TW"];
    cookedBearSteak.Item().Food.Stamina = 13;
    cookedBearSteak.Item().Food.Duration = 1200;

    var mixedGrill = itemManager["MixedGrill_TW"];
    mixedGrill.Item().Food.Health = 70;
    mixedGrill.Item().Food.Stamina = 23;

    // Drops
    creatureManager["BossAsmodeus_TW"].Drops.drops.Remove("KnifeViper_TW");
    creatureManager["BossSvalt_TW"].Drops.drops.Remove("DualAxeDemonic_TW");
    creatureManager["BossVrykolathas_TW"].Drops.drops.Remove("ScytheVampiric_TW");
  }
}
