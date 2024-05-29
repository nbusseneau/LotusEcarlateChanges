using System.Collections.Generic;
using LotusEcarlateChanges.Changes.JotunnBased;
using LotusEcarlateChanges.Model.Changes;

namespace LotusEcarlateChanges.Changes.Manual;

public class VanillaMisc : ManualChangesBase
{
  protected override void ApplyInternalDeferred()
  {
    // Relocate some Misc pieces to Furniture for consistency
    HashSet<string> toFurniture = [
      "darkwood_raven",
      "darkwood_wolf",
      "wood_dragon1",
    ];
    foreach (var piece in PieceManager.GetAll(toFurniture)) piece.Category = Piece.PieceCategory.Furniture;

    // Skills
    ItemManager["THSwordKrom"].Weapon.SkillType = CustomSkills.TwoHandedSwords;

    // Movespeed adjustments
    // Atgeirs
    ItemManager["AtgeirBronze"].Weapon.MovementModifier = -0.10f;
    ItemManager["AtgeirIron"].Weapon.MovementModifier = -0.10f;
    ItemManager["AtgeirBlackmetal"].Weapon.MovementModifier = -0.10f;
    ItemManager["AtgeirHimminAfl"].Weapon.MovementModifier = -0.10f;
    // Shields
    ItemManager["ShieldWood"].Weapon.MovementModifier = -0.10f;
    ItemManager["ShieldBanded"].Weapon.MovementModifier = -0.10f;
    ItemManager["ShieldSilver"].Weapon.MovementModifier = -0.10f;
    ItemManager["ShieldBlackmetal"].Weapon.MovementModifier = -0.10f;
    ItemManager["ShieldCarapace"].Weapon.MovementModifier = -0.10f;
  }
}
