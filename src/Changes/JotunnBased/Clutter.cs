extern alias Clutter;

using Jotunn.Configs;
using LotusEcarlateChanges.Model.Changes;

namespace LotusEcarlateChanges.Changes.JotunnBased;

public class Clutter() : JotunnBasedChangesBase("com.plumga.Clutter")
{
  protected override void ApplyInternal()
  {
    // Remove clutter tool and some pieces
    this.ItemManager.Remove("$PlumgaClutterTool");
    this.PieceManager.Remove([
      "$custompiece_fancychest",
      "$custompiece_fancychest_public",
      "$custompiece_stonechest",
      "$custompiece_stonechest_public",
    ]);

    // Relocate all pieces to Furniture and erase comfort values
    foreach (var piece in this.PieceManager)
    {
      piece.Category = Piece.PieceCategory.Furniture;
      piece.Comfort.Value = 0;
    }

    // Set comfort for chairs / carpets / tables
    string[] chairs = [
      "$custompiece_coolchair",
      "$custompiece_couch1",
      "$custompiece_couch2",
      "$custompiece_couch3",
      "$custompiece_couch4",
      "$custompiece_couchbed1",
      "$custompiece_couchbed2",
    ];
    foreach (var piece in this.PieceManager[chairs]) (piece.Comfort.Value, piece.Comfort.Group) = (1, Piece.ComfortGroup.Chair);

    string[] carpets = [
      "$custompiece_rug_deer_tablecloth",
      "$custompiece_rug_fur_tablecloth",
      "$custompiece_rug_wolf_tablecloth",
    ];
    foreach (var piece in this.PieceManager[carpets]) (piece.Comfort.Value, piece.Comfort.Group) = (1, Piece.ComfortGroup.Carpet);

    string[] tables = [
      "$custompiece_bloodytable",
      "$custompiece_rectangulartable",
      "$custompiece_roundtable",
      "$custompiece_roundtablewithcloth",
    ];
    foreach (var piece in this.PieceManager[tables]) (piece.Comfort.Value, piece.Comfort.Group) = (1, Piece.ComfortGroup.Table);
  }

  protected override void ApplyInternalDeferred()
  {
    var workbench = ZNetScene.instance.GetPrefab(CraftingStations.Workbench).GetComponent<CraftingStation>();
    var forge = ZNetScene.instance.GetPrefab(CraftingStations.Forge).GetComponent<CraftingStation>();
    var stonecutter = ZNetScene.instance.GetPrefab(CraftingStations.Stonecutter).GetComponent<CraftingStation>();

    // Relocate all pieces to Hammer and set workbench as default required crafting station
    foreach (var piece in this.PieceManager)
    {
      piece.CraftingStation = workbench;
      Jotunn.Managers.PieceManager.Instance.RegisterPieceInPieceTable(piece.Prefab, "Hammer");
    }

    // Set forge as required crafting station on metal statues
    string[] metalStatues = [
      "$custompiece_blackdragonstatuelarge",
      "$custompiece_blackdragonstatuesmall",
      "$custompiece_dragonstatuelarge",
      "$custompiece_dragonstatuesmall",
      "$custompiece_lokistatue",
      "$custompiece_odinstatue",
    ];
    foreach (var piece in this.PieceManager[metalStatues]) piece.CraftingStation = forge;

    // Set stonecutter as required crafting station on stone statues
    string[] stoneStatues = [
      "$custompiece_gravestone",
      "$custompiece_statuecorgi",
      "$custompiece_statuedeer",
      "$custompiece_statueevil_small",
      "$custompiece_statuehare",
      "$custompiece_statueseed",
      "$custompiece_celticidol1",
      "$custompiece_celticidol1small",
      "$custompiece_celticidol2",
      "$custompiece_celticidol3",
      "$custompiece_celticidol4",
      "$custompiece_celticidol5",
      "$custompiece_celticidol6",
      "$custompiece_celticidol7",
      "$custompiece_celticidol8",
      "$custompiece_celticidol9",
      "$custompiece_celticidol10",
      "$custompiece_celticidol11",
      "$custompiece_celticidol12",
    ];
    foreach (var piece in this.PieceManager[stoneStatues]) piece.CraftingStation = stonecutter;
  }
}
