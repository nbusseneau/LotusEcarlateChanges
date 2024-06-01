using LotusEcarlateChanges.Changes.JotunnBased;
using LotusEcarlateChanges.Model.Changes;

namespace LotusEcarlateChanges.Changes.Manual;

public class VanillaMisc : ManualChangesBase
{
  protected override void ApplyInternalDeferred()
  {
    // Relocate adornements from Misc to Furniture for consistency
    string[] adornements = [
      "darkwood_raven",
      "darkwood_wolf",
      "wood_dragon1",
    ];
    foreach (var piece in this.PieceManager[adornements]) piece.Category = Piece.PieceCategory.Furniture;

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
