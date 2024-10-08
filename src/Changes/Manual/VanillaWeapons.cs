using static LotusEcarlateChanges.Changes.Constants.Weapon;
using LotusEcarlateChanges.Changes.JotunnBased;
using LotusEcarlateChanges.Model.Changes;

namespace LotusEcarlateChanges.Changes.Manual;

public class VanillaWeapons : ManualChangesBase
{
  protected override void ApplyOnObjectDBAwakeInternal()
  {
    // Movespeed and skills adjustments
    // Atgeirs
    string[] atgeirs = [
      "AtgeirBronze",
      "AtgeirIron",
      "AtgeirBlackmetal",
      "AtgeirHimminAfl",
    ];
    foreach (var atgeir in this.ItemManager[atgeirs]) atgeir.Weapon.MovementModifier = MovementModifier.TwoHanded;

    // Bows
    string[] bows = [
      "Bow",
      "BowFineWood",
      "BowHuntsman",
      "BowDraugrFang",
      "BowSpineSnap",
      "BowAshlands",
      "BowAshlandsBlood",
      "BowAshlandsRoot",
      "BowAshlandsStorm",
    ];
    foreach (var bow in this.ItemManager[bows]) bow.Weapon.MovementModifier = MovementModifier.TwoHanded;

    // Crossbows
    string[] crossbows = [
      "CrossbowArbalest",
      "CrossbowRipper",
      "CrossbowRipperBlood",
      "CrossbowRipperLightning",
      "CrossbowRipperNature",
    ];
    foreach (var crossbow in this.ItemManager[crossbows]) crossbow.Weapon.MovementModifier = MovementModifier.TwoHanded;

    // Dual axes
    string[] dualAxes = [
      "AxeBerzerkr",
      "AxeBerzerkrBlood",
      "AxeBerzerkrLightning",
      "AxeBerzerkrNature",
    ];
    foreach (var dualAxe in this.ItemManager[dualAxes]) dualAxe.Weapon.MovementModifier = MovementModifier.TwoHanded;

    // Two-handed swords
    string[] twoHandedSwords = [
      "THSwordKrom",
      "THSwordSlayer",
      "THSwordSlayerBlood",
      "THSwordSlayerLightning",
      "THSwordSlayerNature",
    ];
    foreach (var twoHandedSword in this.ItemManager[twoHandedSwords])
    {
      twoHandedSword.Weapon.MovementModifier = MovementModifier.TwoHanded;
      twoHandedSword.Weapon.SkillType = CustomSkills.TwoHandedSwords;
    }

    // Staffs
    string[] staffs = [
      "StaffIceShards",
      "StaffFireball",
      "StaffShield",
      "StaffSkeleton",
      "StaffClusterbomb",
      "StaffGreenRoots",
      "StaffLightning",
      "StaffRedTroll",
    ];
    foreach (var staff in this.ItemManager[staffs]) staff.Weapon.MovementModifier = MovementModifier.TwoHanded;

    // Shields
    string[] shields = [
      "ShieldWood",
      "ShieldBanded",
      "ShieldSilver",
      "ShieldBlackmetal",
      "ShieldCarapace",
      "ShieldFlametal",
    ];
    foreach (var shield in this.ItemManager[shields]) shield.Weapon.MovementModifier = MovementModifier.Shield;

    // Tower shields
    string[] towerShields = [
      "ShieldWoodTower",
      "ShieldBoneTower",
      "ShieldIronTower",
      "ShieldSerpentscale",
      "ShieldBlackmetalTower",
      "ShieldFlametalTower",
    ];
    foreach (var towerShield in this.ItemManager[towerShields])
    {
      towerShield.Weapon.MovementModifier = MovementModifier.TowerShield;
      towerShield.Weapon.ParryBonus = ParryBonus.TowerShield;
    }

    // Bronze-tier costs
    var bronzeAtgeir = this.ItemManager["AtgeirBronze"];
    bronzeAtgeir.Resources.Clear();
    bronzeAtgeir.Resources.Add("RoundLog", 5, 0);
    bronzeAtgeir.Resources.Add("Bronze", 4, 4);
    bronzeAtgeir.Resources.Add("LeatherScraps", 2, 0);

    var bronzeAxe = this.ItemManager["AxeBronze"];
    bronzeAxe.Resources.Clear();
    bronzeAxe.Resources.Add("RoundLog", 3, 0);
    bronzeAxe.Resources.Add("Bronze", 4, 4);
    bronzeAxe.Resources.Add("LeatherScraps", 2, 1);

    var bronzeBuckler = this.ItemManager["ShieldBronzeBuckler"];
    bronzeBuckler.Resources.Clear();
    bronzeBuckler.Resources.Add("RoundLog", 4, 2);
    bronzeBuckler.Resources.Add("Bronze", 5, 5);

    var bronzeMace = this.ItemManager["MaceBronze"];
    bronzeMace.Resources.Clear();
    bronzeMace.Resources.Add("RoundLog", 3, 0);
    bronzeMace.Resources.Add("Bronze", 4, 4);
    bronzeMace.Resources.Add("LeatherScraps", 3, 0);

    var bronzePickaxe = this.ItemManager["PickaxeBronze"];
    bronzePickaxe.Resources.Clear();
    bronzePickaxe.Resources.Add("RoundLog", 3, 1);
    bronzePickaxe.Resources.Add("Bronze", 5, 5);

    var bronzeSpear = this.ItemManager["SpearBronze"];
    bronzeSpear.Resources.Clear();
    bronzeSpear.Resources.Add("RoundLog", 5, 2);
    bronzeSpear.Resources.Add("Bronze", 3, 3);
    bronzeSpear.Resources.Add("DeerHide", 2, 1);

    var bronzeSword = this.ItemManager["SwordBronze"];
    bronzeSword.Resources.Clear();
    bronzeSword.Resources.Add("RoundLog", 2);
    bronzeSword.Resources.Add("Bronze", 4, 4);
    bronzeSword.Resources.Add("LeatherScraps", 2, 1);

    var cultivator = this.ItemManager["Cultivator"];
    cultivator.Resources.Clear();
    cultivator.Resources.Add("RoundLog", 5, 1);
    cultivator.Resources.Add("Bronze", 3, 1);
  }
}
