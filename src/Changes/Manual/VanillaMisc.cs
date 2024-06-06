using LotusEcarlateChanges.Changes.JotunnBased;
using LotusEcarlateChanges.Model.Changes;

namespace LotusEcarlateChanges.Changes.Manual;

public class VanillaMisc : ManualChangesBase
{
  protected override void ApplyInternalDeferred()
  {
    var workbench = ZNetScene.instance.GetPrefab(Jotunn.Configs.CraftingStations.Workbench).GetComponent<CraftingStation>();
    var forge = ZNetScene.instance.GetPrefab(Jotunn.Configs.CraftingStations.Forge).GetComponent<CraftingStation>();

    // Relocate adornements from Misc to Furniture for consistency
    string[] adornements = [
      "darkwood_raven",
      "darkwood_wolf",
      "wood_dragon1",
    ];
    foreach (var piece in this.PieceManager[adornements]) piece.Category = Piece.PieceCategory.Furniture;

    // Rebalance some additional pieces
    this.PieceManager["piece_hexagonal_door"].CraftingStation = forge;
    this.PieceManager["piece_hexagonal_door"].Category = Piece.PieceCategory.BuildingStonecutter;

    this.PieceManager["darkwood_gate"].CraftingStation = workbench;

    var dvergrSharpStakes = this.PieceManager["piece_dvergr_sharpstakes"];
    dvergrSharpStakes.CraftingStation = workbench;
    dvergrSharpStakes.Resources.Clear();
    dvergrSharpStakes.Resources.Add("YggdrasilWood", 6);

    var dvergrStakewall = this.PieceManager["piece_dvergr_stake_wall"];
    dvergrStakewall.CraftingStation = workbench;
    dvergrStakewall.Resources.Clear();
    dvergrStakewall.Resources.Add("YggdrasilWood", 4);

    // Skills
    this.ItemManager["THSwordKrom"].Weapon.SkillType = CustomSkills.TwoHandedSwords;

    // Movespeed adjustments
    // Atgeirs
    this.ItemManager["AtgeirBronze"].Weapon.MovementModifier = -0.10f;
    this.ItemManager["AtgeirIron"].Weapon.MovementModifier = -0.10f;
    this.ItemManager["AtgeirBlackmetal"].Weapon.MovementModifier = -0.10f;
    this.ItemManager["AtgeirHimminAfl"].Weapon.MovementModifier = -0.10f;
    // Shields
    this.ItemManager["ShieldWood"].Weapon.MovementModifier = -0.10f;
    this.ItemManager["ShieldBanded"].Weapon.MovementModifier = -0.10f;
    this.ItemManager["ShieldSilver"].Weapon.MovementModifier = -0.10f;
    this.ItemManager["ShieldBlackmetal"].Weapon.MovementModifier = -0.10f;
    this.ItemManager["ShieldCarapace"].Weapon.MovementModifier = -0.10f;
  }
}
