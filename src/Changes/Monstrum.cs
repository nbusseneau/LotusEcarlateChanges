using PieceManager;
using LotusEcarlateChanges.Model.Reflection;
using LotusEcarlateChanges.Model.Reflection.Plugins;

namespace LotusEcarlateChanges.Changes;

public class Monstrum : ReflectionChangesBase<MonstrumPlugin>
{
  const int Workbench = 2; // Warfare uses its own custom ItemManager with a different CraftingTable enum

  protected override void ApplyChangesInternal()
  {
    // Rugs
    var foxRug = plugin.PieceManager["rug_Fox_TW"];
    foxRug.RequiredItems.Clear();
    foxRug.RequiredItems.Add("FoxPelt_TW", 4);
    foxRug.Category = (int)BuildPieceCategory.Furniture;
    foxRug.Comfort.Value = 1;
    foxRug.Comfort.Group = Piece.ComfortGroup.Carpet;

    var rottenRug = plugin.PieceManager["rug_Rotten_TW"];
    rottenRug.RequiredItems.Clear();
    rottenRug.RequiredItems.Add("RottenPelt_TW", 4);
    rottenRug.Category = foxRug.Category;
    rottenRug.Comfort = foxRug.Comfort;

    var bearRug = plugin.PieceManager["rug_BlackBear_TW"];
    bearRug.RequiredItems.Clear();
    bearRug.RequiredItems.Add("BlackBearPelt_TW", 4);
    bearRug.Category = foxRug.Category;
    bearRug.Comfort = foxRug.Comfort;

    var grizzlyRug = plugin.PieceManager["rug_GrizzlyBear_TW"];
    grizzlyRug.RequiredItems.Clear();
    grizzlyRug.RequiredItems.Add("GrizzlyBearPelt_TW", 4);
    grizzlyRug.Category = foxRug.Category;
    grizzlyRug.Comfort = foxRug.Comfort;

    // Saddles
    var saddleBoar = plugin.ItemManager["SaddleBoar_TW"];
    saddleBoar.Crafting.Clear();
    saddleBoar.Crafting.Add(Workbench, 2);
    saddleBoar.RequiredItems.Clear();
    saddleBoar.RequiredItems.Add("RazorbackLeather_TW", 10);
    saddleBoar.RequiredItems.Add("RazorbackTusk_TW", 12);
    saddleBoar.RequiredItems.Add("Bronze", 10);

    var saddleBear = plugin.ItemManager["SaddleBear_TW"];
    saddleBear.Crafting.Clear();
    saddleBear.Crafting.Add(Workbench, 3);
    saddleBear.RequiredItems.Clear();
    saddleBear.RequiredItems.Add("BlackBearPelt_TW", 10);
    saddleBear.RequiredItems.Add("GrizzlyBearPelt_TW", 10);
    saddleBear.RequiredItems.Add("Silver", 10);

    var saddleProwler = plugin.ItemManager["SaddleProwler_TW"];
    saddleProwler.Crafting.Clear();
    saddleProwler.Crafting.Add(Workbench, 4);
    saddleProwler.RequiredItems.Clear();
    saddleProwler.RequiredItems.Add("ProwlerFang_TW", 10);
    saddleProwler.RequiredItems.Add("LinenThread", 20);
    saddleProwler.RequiredItems.Add("LoxPelt", 4);
    saddleProwler.RequiredItems.Add("BlackMetal", 10);

    // Food
    var cookedBearSteak = plugin.ItemManager["CookedBearSteak_TW"];
    cookedBearSteak.Food.Stamina = 13;
    cookedBearSteak.Food.Duration = 1200;

    var mixedGrill = plugin.ItemManager["MixedGrill_TW"];
    mixedGrill.Food.Health = 70;
    mixedGrill.Food.Stamina = 23;

    // Drops
    plugin.CreatureManager["BossAsmodeus_TW"].Drops.Remove("KnifeViper_TW");
    plugin.CreatureManager["BossSvalt_TW"].Drops.Remove("DualAxeDemonic_TW");
    plugin.CreatureManager["BossVrykolathas_TW"].Drops.Remove("ScytheVampiric_TW");
  }
}
