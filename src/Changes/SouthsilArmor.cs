using UnityEngine;
using LotusEcarlateChanges.Model.Reflection;
using LotusEcarlateChanges.Model.Reflection.Plugins;
using LotusEcarlateChanges.Extensions;
using ItemManager;
using LotusEcarlateChanges.Model;

namespace LotusEcarlateChanges.Changes;

public class SouthsilArmor : ReflectionChangesBase<SouthsilArmorPlugin>
{
  protected override void ApplyChangesInternal()
  {
    // Chieftain
    this.Keep("chiefhelmboar");
    this.Keep("chiefhelmdeer");
    this.Keep("chiefchest");
    this.Keep("chieflegs");

    var chieftainHelmBoar = plugin.ItemManager["chiefhelmboar"];
    chieftainHelmBoar.Name.Alias("$SouthsilArmor_ChieftainHelmBoar_Name");
    chieftainHelmBoar.Description.Alias("$SouthsilArmor_ChieftainHelmBoar_Description");
    chieftainHelmBoar.Crafting.Clear();
    chieftainHelmBoar.Crafting.Add((int)CraftingTable.Workbench, 2);
    chieftainHelmBoar.RequiredItems.Clear();
    chieftainHelmBoar.RequiredItems.Add("DeerHide", 2);
    chieftainHelmBoar.RequiredItems.Add("LeatherScraps", 2);
    chieftainHelmBoar.RequiredItems.Add("FoxPelt_TW", 1);
    chieftainHelmBoar.RequiredItems.Add("TrophyBoar", 2);
    chieftainHelmBoar.RequiredUpgradeItems.Clear();
    chieftainHelmBoar.RequiredUpgradeItems.Add("DeerHide", 1);
    chieftainHelmBoar.RequiredUpgradeItems.Add("LeatherScraps", 1);
    chieftainHelmBoar.Armor.ArmorBase = 2;
    chieftainHelmBoar.Armor.ArmorPerLevel = 2;
    chieftainHelmBoar.Armor.MovementModifier = -0.01f;
    chieftainHelmBoar.Armor.Weight = 4;
    var chieftainBoarEquipEffect = chieftainHelmBoar.Armor.EquipEffect;
    chieftainBoarEquipEffect.m_name = "$SouthsilArmor_ChieftainHelmBoar_Effect_Name";
    chieftainBoarEquipEffect.m_tooltip = "$SouthsilArmor_ChieftainHelmBoar_Effect_Tooltip";
    chieftainHelmBoar.Prefab.FixItemLayer();

    var chieftainHelmDeer = plugin.ItemManager["chiefhelmdeer"];
    chieftainHelmDeer.Name.Alias("$SouthsilArmor_ChieftainHelmDeer_Name");
    chieftainHelmDeer.Description.Alias("$SouthsilArmor_ChieftainHelmDeer_Description");
    chieftainHelmDeer.Crafting.Clear();
    chieftainHelmDeer.Crafting.Add((int)CraftingTable.Workbench, 2);
    chieftainHelmDeer.RequiredItems.Clear();
    chieftainHelmDeer.RequiredItems.Add("DeerHide", 2);
    chieftainHelmDeer.RequiredItems.Add("LeatherScraps", 2);
    chieftainHelmDeer.RequiredItems.Add("FoxPelt_TW", 1);
    chieftainHelmDeer.RequiredItems.Add("TrophyDeer", 2);
    chieftainHelmDeer.RequiredUpgradeItems.Clear();
    chieftainHelmDeer.RequiredUpgradeItems.Add("DeerHide", 1);
    chieftainHelmDeer.RequiredUpgradeItems.Add("LeatherScraps", 1);
    chieftainHelmDeer.Armor.ArmorBase = 2;
    chieftainHelmDeer.Armor.ArmorPerLevel = 2;
    chieftainHelmDeer.Armor.MovementModifier = -0.01f;
    chieftainHelmDeer.Armor.Weight = 4;
    var chieftainDeerEquipEffect = chieftainHelmDeer.Armor.EquipEffect;
    chieftainDeerEquipEffect.m_name = "$SouthsilArmor_ChieftainHelmDeer_Effect_Name";
    chieftainDeerEquipEffect.m_tooltip = "$SouthsilArmor_ChieftainHelmDeer_Effect_Tooltip";
    chieftainDeerEquipEffect.m_speedModifier = 0;
    chieftainDeerEquipEffect.m_runStaminaDrainModifier = 0;
    chieftainDeerEquipEffect.m_staminaRegenMultiplier = 1.4f;
    chieftainHelmDeer.Prefab.FixItemLayer();

    var chieftainChest = plugin.ItemManager["chiefchest"];
    chieftainChest.Name.Alias("$SouthsilArmor_ChieftainChest_Name");
    chieftainChest.Description.Alias("$SouthsilArmor_ChieftainChest_Description");
    chieftainChest.Crafting.Clear();
    chieftainChest.Crafting.Add((int)CraftingTable.Workbench, 2);
    chieftainChest.RequiredItems.Clear();
    chieftainChest.RequiredItems.Add("DeerHide", 6);
    chieftainChest.RequiredItems.Add("FoxPelt_TW", 3);
    chieftainChest.RequiredItems.Add("ShieldWood", 1);
    chieftainChest.RequiredItems.Add("Feathers", 5);
    chieftainChest.RequiredUpgradeItems.Clear();
    chieftainChest.RequiredUpgradeItems.Add("DeerHide", 3);
    chieftainChest.RequiredUpgradeItems.Add("LeatherScraps", 3);
    chieftainChest.Armor.ArmorBase = 6;
    chieftainChest.Armor.ArmorPerLevel = 3;
    chieftainChest.Armor.MovementModifier = -0.06f;
    chieftainChest.Armor.Weight = 12;

    var chieftainLegs = plugin.ItemManager["chieflegs"];
    chieftainLegs.Name.Alias("$SouthsilArmor_ChieftainLegs_Name");
    chieftainLegs.Description.Alias("$SouthsilArmor_ChieftainLegs_Description");
    chieftainLegs.Crafting.Clear();
    chieftainLegs.Crafting.Add((int)CraftingTable.Workbench, 2);
    chieftainLegs.RequiredItems.Clear();
    chieftainLegs.RequiredItems.Add("DeerHide", 4);
    chieftainLegs.RequiredItems.Add("FoxPelt_TW", 2);
    chieftainLegs.RequiredItems.Add("KnifeFlint", 2);
    chieftainLegs.RequiredItems.Add("AxeFlint", 1);
    chieftainLegs.RequiredUpgradeItems.Clear();
    chieftainLegs.RequiredUpgradeItems.Add("DeerHide", 2);
    chieftainLegs.RequiredUpgradeItems.Add("LeatherScraps", 2);
    chieftainLegs.Armor.ArmorBase = 4;
    chieftainLegs.Armor.ArmorPerLevel = 3;
    chieftainLegs.Armor.MovementModifier = -0.03f;
    chieftainLegs.Armor.Weight = 8;

    // Battleswine
    this.Keep("heavybronzehelm");
    this.Keep("heavybronzechest");
    this.Keep("heavybronzelegs");

    var battleswineHelm = plugin.ItemManager["heavybronzehelm"];
    battleswineHelm.Name.Alias("$SouthsilArmor_BattleswineHelm_Name");
    battleswineHelm.Description.Alias("$SouthsilArmor_BattleswineHelm_Description");
    battleswineHelm.Crafting.Clear();
    battleswineHelm.Crafting.Add((int)CraftingTable.Forge, 2);
    battleswineHelm.RequiredItems.Clear();
    battleswineHelm.RequiredItems.Add("Bronze", 2);
    battleswineHelm.RequiredItems.Add("RazorbackLeather_TW", 2);
    battleswineHelm.RequiredItems.Add("BlackBearPelt_TW", 1);
    battleswineHelm.RequiredItems.Add("RazorbackTusk_TW", 4);
    battleswineHelm.RequiredUpgradeItems.Clear();
    battleswineHelm.RequiredUpgradeItems.Add("Bronze", 1);
    battleswineHelm.RequiredUpgradeItems.Add("DeerHide", 1);
    battleswineHelm.Armor.ArmorBase = 6;
    battleswineHelm.Armor.ArmorPerLevel = 3;
    battleswineHelm.Armor.MovementModifier = -0.02f;
    battleswineHelm.Armor.Weight = 6;
    battleswineHelm.Prefab.FixItemLayer();

    var battleswineChest = plugin.ItemManager["heavybronzechest"];
    battleswineChest.Name.Alias("$SouthsilArmor_BattleswineChest_Name");
    battleswineChest.Description.Alias("$SouthsilArmor_BattleswineChest_Description");
    battleswineChest.Crafting.Clear();
    battleswineChest.Crafting.Add((int)CraftingTable.Forge, 2);
    battleswineChest.RequiredItems.Clear();
    battleswineChest.RequiredItems.Add("Bronze", 8);
    battleswineChest.RequiredItems.Add("RazorbackLeather_TW", 6);
    battleswineChest.RequiredItems.Add("BlackBearPelt_TW", 3);
    battleswineChest.RequiredItems.Add("TrophyRazorback_TW", 1);
    battleswineChest.RequiredUpgradeItems.Clear();
    battleswineChest.RequiredUpgradeItems.Add("Bronze", 4);
    battleswineChest.RequiredUpgradeItems.Add("DeerHide", 2);
    battleswineChest.Armor.ArmorBase = 18;
    battleswineChest.Armor.ArmorPerLevel = 4;
    battleswineChest.Armor.MovementModifier = -0.10f;
    battleswineChest.Armor.Weight = 18;

    var battleswineLegs = plugin.ItemManager["heavybronzelegs"];
    battleswineLegs.Name.Alias("$SouthsilArmor_BattleswineLegs_Name");
    battleswineLegs.Description.Alias("$SouthsilArmor_BattleswineLegs_Description");
    battleswineLegs.Crafting.Clear();
    battleswineLegs.Crafting.Add((int)CraftingTable.Forge, 2);
    battleswineLegs.RequiredItems.Clear();
    battleswineLegs.RequiredItems.Add("Bronze", 5);
    battleswineLegs.RequiredItems.Add("RazorbackLeather_TW", 3);
    battleswineLegs.RequiredItems.Add("BlackBearPelt_TW", 2);
    battleswineLegs.RequiredUpgradeItems.Clear();
    battleswineLegs.RequiredUpgradeItems.Add("Bronze", 3);
    battleswineLegs.RequiredUpgradeItems.Add("DeerHide", 1);
    battleswineLegs.Armor.ArmorBase = 12;
    battleswineLegs.Armor.ArmorPerLevel = 3;
    battleswineLegs.Armor.MovementModifier = -0.06f;
    battleswineLegs.Armor.Weight = 12;

    var battleswineSetEffect = ScriptableObject.CreateInstance<SE_Stats>();
    battleswineSetEffect.m_name = "$SouthsilArmor_BattleswineSet_Effect_Name";
    battleswineSetEffect.m_tooltip = "$SouthsilArmor_BattleswineSet_Effect_Tooltip";
    battleswineSetEffect.m_icon = battleswineHelm.ItemData.GetIcon();
    battleswineSetEffect.m_skillLevel = Skills.SkillType.Spears;
    battleswineSetEffect.m_skillLevelModifier = 15;
    battleswineSetEffect.m_skillLevel2 = CustomSkills.Warpikes;
    battleswineSetEffect.m_skillLevelModifier2 = 15;

    battleswineHelm.Set.Effect = battleswineSetEffect;
    battleswineHelm.Set.Name = "Battleswine";
    battleswineHelm.Set.Size = 3;
    battleswineChest.Set = battleswineHelm.Set;
    battleswineLegs.Set = battleswineHelm.Set;

    // Draugr
    this.Keep("swamphelm");
    this.Keep("swampchest");
    this.Keep("swamplegs");

    var draugrHelm = plugin.ItemManager["swamphelm"];
    draugrHelm.Name.Alias("$SouthsilArmor_DraugrHelm_Name");
    draugrHelm.Description.Alias("$SouthsilArmor_DraugrHelm_Description");
    draugrHelm.Crafting.Clear();
    draugrHelm.Crafting.Add((int)CraftingTable.Forge, 3);
    draugrHelm.RequiredItems.Clear();
    draugrHelm.RequiredItems.Add("Iron", 12);
    draugrHelm.RequiredItems.Add("RottenPelt_TW", 2);
    draugrHelm.RequiredItems.Add("WitheredBone", 2);
    draugrHelm.RequiredItems.Add("TrophyCrawler_TW", 1);
    draugrHelm.RequiredUpgradeItems.Clear();
    draugrHelm.RequiredUpgradeItems.Add("Iron", 3);
    draugrHelm.RequiredUpgradeItems.Add("RottenPelt_TW", 1);
    draugrHelm.RequiredUpgradeItems.Add("WitheredBone", 1);
    draugrHelm.Armor.ArmorBase = 9;
    draugrHelm.Armor.ArmorPerLevel = 3;
    draugrHelm.Armor.MovementModifier = -0.02f;
    draugrHelm.Armor.Weight = 6;
    draugrHelm.Prefab.FixItemLayer();

    var draugrChest = plugin.ItemManager["swampchest"];
    draugrChest.Name.Alias("$SouthsilArmor_DraugrChest_Name");
    draugrChest.Description.Alias("$SouthsilArmor_DraugrChest_Description");
    draugrChest.Crafting.Clear();
    draugrChest.Crafting.Add((int)CraftingTable.Forge, 3);
    draugrChest.RequiredItems.Clear();
    draugrChest.RequiredItems.Add("Iron", 36);
    draugrChest.RequiredItems.Add("RottenPelt_TW", 4);
    draugrChest.RequiredItems.Add("WitheredBone", 6);
    draugrChest.RequiredUpgradeItems.Clear();
    draugrChest.RequiredUpgradeItems.Add("Iron", 9);
    draugrChest.RequiredUpgradeItems.Add("RottenPelt_TW", 1);
    draugrChest.RequiredUpgradeItems.Add("WitheredBone", 3);
    draugrChest.Armor.ArmorBase = 27;
    draugrChest.Armor.ArmorPerLevel = 4;
    draugrChest.Armor.MovementModifier = -0.10f;
    draugrChest.Armor.Weight = 18;

    var draugrLegs = plugin.ItemManager["swamplegs"];
    draugrLegs.Name.Alias("$SouthsilArmor_DraugrLegs_Name");
    draugrLegs.Description.Alias("$SouthsilArmor_DraugrLegs_Description");
    draugrLegs.Crafting.Clear();
    draugrLegs.Crafting.Add((int)CraftingTable.Forge, 3);
    draugrLegs.RequiredItems.Clear();
    draugrLegs.RequiredItems.Add("Iron", 24);
    draugrLegs.RequiredItems.Add("RottenPelt_TW", 2);
    draugrLegs.RequiredItems.Add("WitheredBone", 4);
    draugrLegs.RequiredItems.Add("TrophySkeleton", 4);
    draugrLegs.RequiredUpgradeItems.Clear();
    draugrLegs.RequiredUpgradeItems.Add("Iron", 6);
    draugrLegs.RequiredUpgradeItems.Add("RottenPelt_TW", 1);
    draugrLegs.RequiredUpgradeItems.Add("WitheredBone", 2);
    draugrLegs.Armor.ArmorBase = 18;
    draugrLegs.Armor.ArmorPerLevel = 3;
    draugrLegs.Armor.MovementModifier = -0.06f;
    draugrLegs.Armor.Weight = 12;

    var draugrSetEffect = draugrHelm.Set.Effect;
    draugrSetEffect.m_name = "$SouthsilArmor_DraugrSet_Effect_Name";
    draugrSetEffect.m_tooltip = "$SouthsilArmor_DraugrSet_Effect_Tooltip";
    draugrSetEffect.m_mods.Clear();
    draugrSetEffect.m_mods.Add(new()
    {
      m_type = HitData.DamageType.Poison,
      m_modifier = HitData.DamageModifier.Resistant,
    });

    draugrHelm.Set.Name = "Draugr";
    draugrHelm.Set.Size = 3;
    draugrChest.Set = draugrHelm.Set;
    draugrLegs.Set = draugrHelm.Set;

    // Grizzly
    this.Keep("heavybearhelm");
    this.Keep("heavybearchest");
    this.Keep("heavybearlegs");

    var grizzlyHelm = plugin.ItemManager["heavybearhelm"];
    grizzlyHelm.Name.Alias("$SouthsilArmor_GrizzlyHelm_Name");
    grizzlyHelm.Description.Alias("$SouthsilArmor_GrizzlyHelm_Description");
    grizzlyHelm.Crafting.Clear();
    grizzlyHelm.Crafting.Add((int)CraftingTable.Forge, 3);
    grizzlyHelm.RequiredItems.Clear();
    grizzlyHelm.RequiredItems.Add("Silver", 5);
    grizzlyHelm.RequiredItems.Add("GrizzlyBearPelt_TW", 1);
    grizzlyHelm.RequiredItems.Add("TrophyHatchling", 2);
    grizzlyHelm.RequiredUpgradeItems.Clear();
    grizzlyHelm.RequiredUpgradeItems.Add("Silver", 2);
    grizzlyHelm.RequiredUpgradeItems.Add("WolfPelt", 1);
    grizzlyHelm.Armor.ArmorBase = 14;
    grizzlyHelm.Armor.ArmorPerLevel = 4;
    grizzlyHelm.Armor.MovementModifier = -0.02f;
    grizzlyHelm.Armor.Weight = 6;
    grizzlyHelm.Prefab.FixItemLayer();

    var grizzlyChest = plugin.ItemManager["heavybearchest"];
    grizzlyChest.Name.Alias("$SouthsilArmor_GrizzlyChest_Name");
    grizzlyChest.Description.Alias("$SouthsilArmor_GrizzlyChest_Description");
    grizzlyChest.Crafting.Clear();
    grizzlyChest.Crafting.Add((int)CraftingTable.Forge, 3);
    grizzlyChest.RequiredItems.Clear();
    grizzlyChest.RequiredItems.Add("Silver", 20);
    grizzlyChest.RequiredItems.Add("GrizzlyBearPelt_TW", 2);
    grizzlyChest.RequiredItems.Add("TrophyHatchling", 2);
    grizzlyChest.RequiredItems.Add("ClaymoreIron_TW", 1);
    grizzlyChest.RequiredUpgradeItems.Clear();
    grizzlyChest.RequiredUpgradeItems.Add("Silver", 8);
    grizzlyChest.RequiredUpgradeItems.Add("WolfPelt", 3);
    grizzlyChest.Armor.ArmorBase = 27;
    grizzlyChest.Armor.ArmorPerLevel = 4;
    grizzlyChest.Armor.MovementModifier = -0.10f;
    grizzlyChest.Armor.Weight = 18;

    var grizzlyLegs = plugin.ItemManager["heavybearlegs"];
    grizzlyLegs.Name.Alias("$SouthsilArmor_GrizzlyLegs_Name");
    grizzlyLegs.Description.Alias("$SouthsilArmor_GrizzlyLegs_Description");
    grizzlyLegs.Crafting.Clear();
    grizzlyLegs.Crafting.Add((int)CraftingTable.Forge, 3);
    grizzlyLegs.RequiredItems.Clear();
    grizzlyLegs.RequiredItems.Add("Silver", 10);
    grizzlyLegs.RequiredItems.Add("GrizzlyBearPelt_TW", 1);
    grizzlyLegs.RequiredItems.Add("KnifeSilver", 2);
    grizzlyLegs.RequiredItems.Add("TankardAnniversary", 1);
    grizzlyLegs.RequiredUpgradeItems.Clear();
    grizzlyLegs.RequiredUpgradeItems.Add("Silver", 5);
    grizzlyLegs.RequiredUpgradeItems.Add("WolfPelt", 2);
    grizzlyLegs.Armor.ArmorBase = 18;
    grizzlyLegs.Armor.ArmorPerLevel = 3;
    grizzlyLegs.Armor.MovementModifier = -0.06f;
    grizzlyLegs.Armor.Weight = 12;

    var grizzlySetEffect = grizzlyHelm.Set.Effect;
    grizzlySetEffect.m_name = "$SouthsilArmor_GrizzlySet_Effect_Name";
    grizzlySetEffect.m_tooltip = "$SouthsilArmor_GrizzlySet_Effect_Tooltip";
    grizzlySetEffect.m_skillLevel = Skills.SkillType.Swords;
    grizzlySetEffect.m_skillLevelModifier = 15;
    grizzlySetEffect.m_skillLevel2 = CustomSkills.TwoHandedSwords;
    grizzlySetEffect.m_skillLevelModifier2 = 15;
    grizzlySetEffect.m_mods.Clear();
    grizzlySetEffect.m_mods.Add(new()
    {
      m_type = HitData.DamageType.Frost,
      m_modifier = HitData.DamageModifier.Resistant,
    });
    grizzlySetEffect.m_staminaRegenMultiplier = 1;

    grizzlyHelm.Set.Name = "Grizzly";
    grizzlyHelm.Set.Size = 3;
    grizzlyChest.Set = grizzlyHelm.Set;
    grizzlyLegs.Set = grizzlyHelm.Set;

    // Feral
    this.Keep("obswolfhelm");
    this.Keep("obswolfchest");
    this.Keep("obswolflegs");

    var feralHelm = plugin.ItemManager["obswolfhelm"];
    feralHelm.Name.Alias("$SouthsilArmor_FeralHelm_Name");
    feralHelm.Description.Alias("$SouthsilArmor_FeralHelm_Description");
    feralHelm.Crafting.Clear();
    feralHelm.Crafting.Add((int)CraftingTable.Forge, 2);
    feralHelm.RequiredItems.Clear();
    feralHelm.RequiredItems.Add("BlackMetal", 4);
    feralHelm.RequiredItems.Add("WolfHairBundle", 10);
    feralHelm.RequiredItems.Add("TrophyProwler_TW", 2);
    feralHelm.RequiredItems.Add("Ruby", 5);
    feralHelm.RequiredUpgradeItems.Clear();
    feralHelm.RequiredUpgradeItems.Add("BlackMetal", 2);
    feralHelm.RequiredUpgradeItems.Add("WolfHairBundle", 5);
    feralHelm.Armor.ArmorBase = 7;
    feralHelm.Armor.ArmorPerLevel = 2;
    feralHelm.Armor.MovementModifier = 0;
    feralHelm.Armor.Weight = 1;
    feralHelm.Prefab.FixItemLayer();

    var feralChest = plugin.ItemManager["obswolfchest"];
    feralChest.Name.Alias("$SouthsilArmor_FeralChest_Name");
    feralChest.Description.Alias("$SouthsilArmor_FeralChest_Description");
    feralChest.Crafting.Clear();
    feralChest.Crafting.Add((int)CraftingTable.Forge, 2);
    feralChest.RequiredItems.Clear();
    feralChest.RequiredItems.Add("BlackMetal", 12);
    feralChest.RequiredItems.Add("LoxPelt", 4);
    feralChest.RequiredItems.Add("ProwlerFang_TW", 12);
    feralChest.RequiredItems.Add("TrophyUlv", 4);
    feralChest.RequiredUpgradeItems.Clear();
    feralChest.RequiredUpgradeItems.Add("BlackMetal", 6);
    feralChest.RequiredUpgradeItems.Add("LoxPelt", 1);
    feralChest.RequiredUpgradeItems.Add("ProwlerFang_TW", 3);
    feralChest.Armor.ArmorBase = 21;
    feralChest.Armor.ArmorPerLevel = 3;
    feralChest.Armor.MovementModifier = -0.01f;
    feralChest.Armor.Weight = 6;
    feralChest.Armor.DamageModifiers.Clear();

    var feralLegs = plugin.ItemManager["obswolflegs"];
    feralLegs.Name.Alias("$SouthsilArmor_FeralLegs_Name");
    feralLegs.Description.Alias("$SouthsilArmor_FeralLegs_Description");
    feralLegs.Crafting.Clear();
    feralLegs.Crafting.Add((int)CraftingTable.Forge, 2);
    feralLegs.RequiredItems.Clear();
    feralLegs.RequiredItems.Add("BlackMetal", 8);
    feralLegs.RequiredItems.Add("LinenThread", 20);
    feralLegs.RequiredItems.Add("WolfClaw", 5);
    feralLegs.RequiredUpgradeItems.Clear();
    feralLegs.RequiredUpgradeItems.Add("BlackMetal", 4);
    feralLegs.RequiredUpgradeItems.Add("LinenThread", 10);
    feralLegs.Armor.ArmorBase = 14;
    feralLegs.Armor.ArmorPerLevel = 3;
    feralLegs.Armor.MovementModifier = -0.01f;
    feralLegs.Armor.Weight = 3;

    var feralSetEffect = feralHelm.Set.Effect;
    feralSetEffect.m_name = "$SouthsilArmor_FeralSet_Effect_Name";
    feralSetEffect.m_tooltip = "$SouthsilArmor_FeralSet_Effect_Tooltip";
    feralSetEffect.m_skillLevel = Skills.SkillType.Sneak;
    feralSetEffect.m_skillLevelModifier = 15;
    feralSetEffect.m_skillLevel2 = Skills.SkillType.Knives;
    feralSetEffect.m_skillLevelModifier2 = 15;
    feralSetEffect.m_runStaminaDrainModifier = 0;
    feralSetEffect.m_jumpStaminaUseModifier = 0;
    feralSetEffect.m_speedModifier = 0;
    feralSetEffect.m_stealthModifier = 0;

    feralHelm.Set.Name = "Feral";
    feralHelm.Set.Size = 3;
    feralChest.Set = feralHelm.Set;
    feralLegs.Set = feralHelm.Set;

    // Shieldmaiden
    this.Keep("norahhelm");
    this.Keep("norahhelmalt");
    this.Keep("norahchest");
    this.Keep("norahlegs");

    var shieldmaidenHelm = plugin.ItemManager["norahhelm"];
    shieldmaidenHelm.Name.Alias("$SouthsilArmor_ShieldmaidenHelm_Name");
    shieldmaidenHelm.Description.Alias("$SouthsilArmor_ShieldmaidenHelm_Description");
    shieldmaidenHelm.Crafting.Clear();
    shieldmaidenHelm.Crafting.Add((int)CraftingTable.Forge, 2);
    shieldmaidenHelm.RequiredItems.Clear();
    shieldmaidenHelm.RequiredItems.Add("LinenThread", 10);
    shieldmaidenHelm.RequiredItems.Add("Coins", 500);
    shieldmaidenHelm.RequiredUpgradeItems.Clear();
    shieldmaidenHelm.RequiredUpgradeItems.Add("LinenThread", 10);
    shieldmaidenHelm.Armor.ArmorBase = 10;
    shieldmaidenHelm.Armor.ArmorPerLevel = 2;
    shieldmaidenHelm.Armor.MovementModifier = 0;
    shieldmaidenHelm.Armor.Weight = 3;

    var shieldmaidenHelmAlt = plugin.ItemManager["norahhelmalt"];
    shieldmaidenHelmAlt.Name.Alias("$SouthsilArmor_ShieldmaidenHelmAlt_Name");
    shieldmaidenHelmAlt.Description.Alias("$SouthsilArmor_ShieldmaidenHelmAlt_Description");
    shieldmaidenHelmAlt.Crafting.Clear();
    shieldmaidenHelmAlt.Crafting.Add((int)CraftingTable.Forge, 2);
    shieldmaidenHelmAlt.RequiredItems.Clear();
    shieldmaidenHelmAlt.RequiredItems.Add("LinenThread", 10);
    shieldmaidenHelmAlt.RequiredItems.Add("LoxPelt", 1); ;
    shieldmaidenHelmAlt.RequiredUpgradeItems.Clear();
    shieldmaidenHelmAlt.RequiredUpgradeItems.Add("LinenThread", 10);
    shieldmaidenHelmAlt.Armor.ArmorBase = 10;
    shieldmaidenHelmAlt.Armor.ArmorPerLevel = 2;
    shieldmaidenHelmAlt.Armor.MovementModifier = 0;
    shieldmaidenHelmAlt.Armor.Weight = 3;
    shieldmaidenHelmAlt.Prefab.FixItemLayer();

    var shieldmaidenChest = plugin.ItemManager["norahchest"];
    shieldmaidenChest.Name.Alias("$SouthsilArmor_ShieldmaidenChest_Name");
    shieldmaidenChest.Description.Alias("$SouthsilArmor_ShieldmaidenChest_Description");
    shieldmaidenChest.Crafting.Clear();
    shieldmaidenChest.Crafting.Add((int)CraftingTable.Forge, 2);
    shieldmaidenChest.RequiredItems.Clear();
    shieldmaidenChest.RequiredItems.Add("Iron", 12);
    shieldmaidenChest.RequiredItems.Add("LinenThread", 30);
    shieldmaidenChest.RequiredItems.Add("LoxPelt", 4);
    shieldmaidenChest.RequiredItems.Add("KnifeSilver", 1);
    shieldmaidenChest.RequiredUpgradeItems.Clear();
    shieldmaidenChest.RequiredUpgradeItems.Add("Iron", 3);
    shieldmaidenChest.RequiredUpgradeItems.Add("LinenThread", 15);
    shieldmaidenChest.RequiredUpgradeItems.Add("LoxPelt", 1);
    shieldmaidenChest.Armor.ArmorBase = 30;
    shieldmaidenChest.Armor.ArmorPerLevel = 3;
    shieldmaidenChest.Armor.MovementModifier = -0.04f;
    shieldmaidenChest.Armor.Weight = 10;

    var shieldmaidenLegs = plugin.ItemManager["norahlegs"];
    shieldmaidenLegs.Name.Alias("$SouthsilArmor_ShieldmaidenLegs_Name");
    shieldmaidenLegs.Description.Alias("$SouthsilArmor_ShieldmaidenLegs_Description");
    shieldmaidenLegs.Crafting.Clear();
    shieldmaidenLegs.Crafting.Add((int)CraftingTable.Forge, 2);
    shieldmaidenLegs.RequiredItems.Clear();
    shieldmaidenLegs.RequiredItems.Add("Iron", 8);
    shieldmaidenLegs.RequiredItems.Add("LinenThread", 20);
    shieldmaidenLegs.RequiredItems.Add("LoxPelt", 2);
    shieldmaidenLegs.RequiredUpgradeItems.Clear();
    shieldmaidenLegs.RequiredUpgradeItems.Add("Iron", 2);
    shieldmaidenLegs.RequiredUpgradeItems.Add("LinenThread", 10);
    shieldmaidenLegs.RequiredUpgradeItems.Add("LoxPelt", 2);
    shieldmaidenLegs.Armor.ArmorBase = 20;
    shieldmaidenLegs.Armor.ArmorPerLevel = 2;
    shieldmaidenLegs.Armor.MovementModifier = -0.02f;
    shieldmaidenLegs.Armor.Weight = 5;

    var shieldMaidenSetEffect = shieldmaidenHelm.Set.Effect;
    shieldMaidenSetEffect.m_name = "$SouthsilArmor_ShieldmaidenSet_Effect_Name";
    shieldMaidenSetEffect.m_tooltip = "$SouthsilArmor_ShieldmaidenSet_Effect_Tooltip";
    shieldMaidenSetEffect.m_skillLevel = Skills.SkillType.Clubs;
    shieldMaidenSetEffect.m_skillLevelModifier = 15;
    shieldMaidenSetEffect.m_skillLevel2 = Skills.SkillType.Blocking;
    shieldMaidenSetEffect.m_skillLevelModifier2 = 15;

    shieldmaidenHelm.Set.Name = "Shieldmaiden";
    shieldmaidenHelm.Set.Size = 3;
    shieldmaidenHelmAlt.Set = shieldmaidenHelm.Set;
    shieldmaidenChest.Set = shieldmaidenHelm.Set;
    shieldmaidenLegs.Set = shieldmaidenHelm.Set;

    // Berserker
    this.Keep("bearhelm2");
    this.Keep("bearchest2");
    this.Keep("bearlegs2");

    var berserkerHelm = plugin.ItemManager["bearhelm2"];
    berserkerHelm.Name.Alias("$SouthsilArmor_BerserkerHelm_Name");
    berserkerHelm.Description.Alias("$SouthsilArmor_BerserkerHelm_Description");
    berserkerHelm.Crafting.Clear();
    berserkerHelm.Crafting.Add((int)CraftingTable.Forge, 3);
    berserkerHelm.RequiredItems.Clear();
    berserkerHelm.RequiredItems.Add("BlackMetal", 10);
    berserkerHelm.RequiredItems.Add("LinenThread", 10);
    berserkerHelm.RequiredUpgradeItems.Clear();
    berserkerHelm.RequiredUpgradeItems.Add("BlackMetal", 5);
    berserkerHelm.RequiredUpgradeItems.Add("LinenThread", 5);
    berserkerHelm.Armor.ArmorBase = 16;
    berserkerHelm.Armor.ArmorPerLevel = 4;
    berserkerHelm.Armor.MovementModifier = -0.02f;
    berserkerHelm.Armor.Weight = 6;

    var berserkerChest = plugin.ItemManager["bearchest2"];
    berserkerChest.Name.Alias("$SouthsilArmor_BerserkerChest_Name");
    berserkerChest.Description.Alias("$SouthsilArmor_BerserkerChest_Description");
    berserkerChest.Crafting.Clear();
    berserkerChest.Crafting.Add((int)CraftingTable.Forge, 3);
    berserkerChest.RequiredItems.Clear();
    berserkerChest.RequiredItems.Add("BlackMetal", 30);
    berserkerChest.RequiredItems.Add("LinenThread", 30);
    berserkerChest.RequiredItems.Add("Chain", 10);
    berserkerChest.RequiredUpgradeItems.Clear();
    berserkerChest.RequiredUpgradeItems.Add("BlackMetal", 15);
    berserkerChest.RequiredUpgradeItems.Add("LinenThread", 15);
    berserkerChest.Armor.ArmorBase = 48;
    berserkerChest.Armor.ArmorPerLevel = 5;
    berserkerChest.Armor.MovementModifier = -0.10f;
    berserkerChest.Armor.Weight = 18;

    var berserkerLegs = plugin.ItemManager["bearlegs2"];
    berserkerLegs.Name.Alias("$SouthsilArmor_BerserkerLegs_Name");
    berserkerLegs.Description.Alias("$SouthsilArmor_BerserkerLegs_Description");
    berserkerLegs.Crafting.Clear();
    berserkerLegs.Crafting.Add((int)CraftingTable.Forge, 3);
    berserkerLegs.RequiredItems.Clear();
    berserkerLegs.RequiredItems.Add("BlackMetal", 20);
    berserkerLegs.RequiredItems.Add("LinenThread", 20);
    berserkerLegs.RequiredUpgradeItems.Clear();
    berserkerLegs.RequiredUpgradeItems.Add("BlackMetal", 10);
    berserkerLegs.RequiredUpgradeItems.Add("LinenThread", 10);
    berserkerLegs.Armor.ArmorBase = 32;
    berserkerLegs.Armor.ArmorPerLevel = 5;
    berserkerLegs.Armor.MovementModifier = -0.06f;
    berserkerLegs.Armor.Weight = 12;
    berserkerLegs.Armor.DamageModifiers.Clear();

    var berserkerSetEffect = berserkerHelm.Set.Effect;
    berserkerSetEffect.m_name = "$SouthsilArmor_BerserkerSet_Effect_Name";
    berserkerSetEffect.m_tooltip = "$SouthsilArmor_BerserkerSet_Effect_Tooltip";
    berserkerSetEffect.m_skillLevel = CustomSkills.TwoHandedAxes;
    berserkerSetEffect.m_skillLevelModifier = 15;
    berserkerSetEffect.m_skillLevel2 = CustomSkills.TwoHandedHammers;
    berserkerSetEffect.m_skillLevelModifier2 = 15;
    berserkerSetEffect.m_healthRegenMultiplier = 1;
    berserkerSetEffect.m_staminaRegenMultiplier = 1;

    berserkerHelm.Set.Name = "Berserker";
    berserkerHelm.Set.Size = 3;
    berserkerChest.Set = berserkerHelm.Set;
    berserkerLegs.Set = berserkerHelm.Set;

    // Gjall-hunter
    this.Keep("heavycarhelm");
    this.Keep("heavycarchest");
    this.Keep("heavycarlegs");

    var gjallhunterHelm = plugin.ItemManager["heavycarhelm"];
    gjallhunterHelm.Name.Alias("$SouthsilArmor_GjallhunterHelm_Name");
    gjallhunterHelm.Description.Alias("$SouthsilArmor_GjallhunterHelm_Description");
    gjallhunterHelm.Crafting.Clear();
    gjallhunterHelm.Crafting.Add((int)CraftingTable.BlackForge, 1);
    gjallhunterHelm.RequiredItems.Clear();
    gjallhunterHelm.RequiredItems.Add("Carapace", 8);
    gjallhunterHelm.RequiredItems.Add("Mandible", 2);
    gjallhunterHelm.RequiredItems.Add("TrophyGjall", 2);
    gjallhunterHelm.RequiredUpgradeItems.Clear();
    gjallhunterHelm.RequiredUpgradeItems.Add("Carapace", 4);
    gjallhunterHelm.RequiredUpgradeItems.Add("Mandible", 1);
    gjallhunterHelm.Armor.ArmorBase = 12;
    gjallhunterHelm.Armor.ArmorPerLevel = 3;
    gjallhunterHelm.Armor.MovementModifier = 0;
    gjallhunterHelm.Armor.Weight = 3;
    gjallhunterHelm.Armor.EquipEffect = null;
    gjallhunterHelm.Prefab.FixItemLayer();

    var gjallhunterChest = plugin.ItemManager["heavycarchest"];
    gjallhunterChest.Name.Alias("$SouthsilArmor_GjallhunterChest_Name");
    gjallhunterChest.Description.Alias("$SouthsilArmor_GjallhunterChest_Description");
    gjallhunterChest.Crafting.Clear();
    gjallhunterChest.Crafting.Add((int)CraftingTable.BlackForge, 1);
    gjallhunterChest.RequiredItems.Clear();
    gjallhunterChest.RequiredItems.Add("Carapace", 20);
    gjallhunterChest.RequiredItems.Add("Mandible", 6);
    gjallhunterChest.RequiredItems.Add("ScaleHide", 10);
    gjallhunterChest.RequiredItems.Add("TrophySkeleton", 4);
    gjallhunterChest.RequiredUpgradeItems.Clear();
    gjallhunterChest.RequiredUpgradeItems.Add("Carapace", 10);
    gjallhunterChest.RequiredUpgradeItems.Add("Mandible", 3);
    gjallhunterChest.RequiredUpgradeItems.Add("ScaleHide", 5);
    gjallhunterChest.Armor.ArmorBase = 36;
    gjallhunterChest.Armor.ArmorPerLevel = 4;
    gjallhunterChest.Armor.MovementModifier = -0.04f;
    gjallhunterChest.Armor.Weight = 10;

    var gjallhunterLegs = plugin.ItemManager["heavycarlegs"];
    gjallhunterLegs.Name.Alias("$SouthsilArmor_GjallhunterLegs_Name");
    gjallhunterLegs.Description.Alias("$SouthsilArmor_GjallhunterLegs_Description");
    gjallhunterLegs.Crafting.Clear();
    gjallhunterLegs.Crafting.Add((int)CraftingTable.BlackForge, 1);
    gjallhunterLegs.RequiredItems.Clear();
    gjallhunterLegs.RequiredItems.Add("Carapace", 12);
    gjallhunterLegs.RequiredItems.Add("Mandible", 2);
    gjallhunterLegs.RequiredItems.Add("ScaleHide", 4);
    gjallhunterLegs.RequiredItems.Add("TrophySkeleton", 4);
    gjallhunterLegs.RequiredUpgradeItems.Clear();
    gjallhunterLegs.RequiredUpgradeItems.Add("Carapace", 6);
    gjallhunterLegs.RequiredUpgradeItems.Add("Mandible", 1);
    gjallhunterLegs.RequiredUpgradeItems.Add("ScaleHide", 2);
    gjallhunterLegs.Armor.ArmorBase = 24;
    gjallhunterLegs.Armor.ArmorPerLevel = 3;
    gjallhunterLegs.Armor.MovementModifier = -0.02f;
    gjallhunterLegs.Armor.Weight = 5;

    var gjallhunterSetEffect = gjallhunterHelm.Set.Effect;
    gjallhunterSetEffect.m_name = "$SouthsilArmor_GjallhunterSet_Effect_Name";
    gjallhunterSetEffect.m_tooltip = "$SouthsilArmor_GjallhunterSet_Effect_Tooltip";
    gjallhunterSetEffect.m_skillLevel = Skills.SkillType.Bows;
    gjallhunterSetEffect.m_skillLevelModifier = 15;
    gjallhunterSetEffect.m_skillLevel2 = Skills.SkillType.Crossbows;
    gjallhunterSetEffect.m_skillLevelModifier2 = 15;
    gjallhunterSetEffect.m_staminaRegenMultiplier = 1;

    gjallhunterHelm.Set.Name = "Gjallhunter";
    gjallhunterHelm.Set.Size = 3;
    gjallhunterChest.Set = gjallhunterHelm.Set;
    gjallhunterLegs.Set = gjallhunterHelm.Set;

    // Rune-knight
    this.Keep("runeknighthelm");
    this.Keep("runeknightchest");
    this.Keep("runeknightlegs");

    var runeknightHelm = plugin.ItemManager["runeknighthelm"];
    runeknightHelm.Name.Alias("$SouthsilArmor_RuneknightHelm_Name");
    runeknightHelm.Description.Alias("$SouthsilArmor_RuneknightHelm_Description");
    runeknightHelm.Crafting.Clear();
    runeknightHelm.Crafting.Add((int)CraftingTable.BlackForge, 1);
    runeknightHelm.RequiredItems.Clear();
    runeknightHelm.RequiredItems.Add("BlackMetal", 10);
    runeknightHelm.RequiredItems.Add("Eitr", 15);
    runeknightHelm.RequiredItems.Add("DarkCrystal_TW", 5);
    runeknightHelm.RequiredUpgradeItems.Clear();
    runeknightHelm.RequiredUpgradeItems.Add("BlackMetal", 5);
    runeknightHelm.RequiredUpgradeItems.Add("Eitr", 5);
    runeknightHelm.Armor.ArmorBase = 18;
    runeknightHelm.Armor.ArmorPerLevel = 4;
    runeknightHelm.Armor.MovementModifier = -0.02f;
    runeknightHelm.Armor.Weight = 5;
    runeknightHelm.Prefab.FixItemLayer();

    var runeknightChest = plugin.ItemManager["runeknightchest"];
    runeknightChest.Name.Alias("$SouthsilArmor_RuneknightChest_Name");
    runeknightChest.Description.Alias("$SouthsilArmor_RuneknightChest_Description");
    runeknightChest.Crafting.Clear();
    runeknightChest.Crafting.Add((int)CraftingTable.BlackForge, 1);
    runeknightChest.RequiredItems.Clear();
    runeknightChest.RequiredItems.Add("BlackMetal", 30);
    runeknightChest.RequiredItems.Add("Eitr", 20);
    runeknightChest.RequiredItems.Add("LinenThread", 20);
    runeknightChest.RequiredItems.Add("BlackCore", 2);
    runeknightChest.RequiredUpgradeItems.Clear();
    runeknightChest.RequiredUpgradeItems.Add("BlackMetal", 15);
    runeknightChest.RequiredUpgradeItems.Add("Eitr", 5);
    runeknightChest.RequiredUpgradeItems.Add("LinenThread", 10);
    runeknightChest.Armor.ArmorBase = 54;
    runeknightChest.Armor.ArmorPerLevel = 4;
    runeknightChest.Armor.MovementModifier = -0.08f;
    runeknightChest.Armor.Weight = 15;

    var runeknightLegs = plugin.ItemManager["runeknightlegs"];
    runeknightLegs.Name.Alias("$SouthsilArmor_RuneknightLegs_Name");
    runeknightLegs.Description.Alias("$SouthsilArmor_RuneknightLegs_Description");
    runeknightLegs.Crafting.Clear();
    runeknightLegs.Crafting.Add((int)CraftingTable.BlackForge, 1);
    runeknightLegs.RequiredItems.Clear();
    runeknightLegs.RequiredItems.Add("BlackMetal", 20);
    runeknightLegs.RequiredItems.Add("Eitr", 20);
    runeknightLegs.RequiredItems.Add("LinenThread", 10);
    runeknightLegs.RequiredItems.Add("MeadEitrMinor", 5);
    runeknightLegs.RequiredUpgradeItems.Clear();
    runeknightLegs.RequiredUpgradeItems.Add("BlackMetal", 10);
    runeknightLegs.RequiredUpgradeItems.Add("Eitr", 5);
    runeknightLegs.RequiredUpgradeItems.Add("LinenThread", 5);
    runeknightLegs.Armor.ArmorBase = 36;
    runeknightLegs.Armor.ArmorPerLevel = 4;
    runeknightLegs.Armor.MovementModifier = -0.04f;
    runeknightLegs.Armor.Weight = 10;

    var runeknightSetEffect = runeknightHelm.Set.Effect;
    runeknightSetEffect.m_name = "$SouthsilArmor_RuneknightSet_Effect_Name";
    runeknightSetEffect.m_tooltip = "$SouthsilArmor_RuneknightSet_Effect_Tooltip";
    runeknightSetEffect.m_skillLevel = Skills.SkillType.BloodMagic;
    runeknightSetEffect.m_skillLevelModifier = 15;

    runeknightHelm.Set.Name = "Runeknight";
    runeknightHelm.Set.Size = 3;
    runeknightChest.Set = runeknightHelm.Set;
    runeknightLegs.Set = runeknightHelm.Set;

    // Druid
    this.Keep("druidhelm");
    this.Keep("druidchest");
    this.Keep("druidlegs");

    var druidHelm = plugin.ItemManager["druidhelm"];
    druidHelm.Name.Alias("$SouthsilArmor_DruidHelm_Name");
    druidHelm.Description.Alias("$SouthsilArmor_DruidHelm_Description");
    druidHelm.Crafting.Clear();
    druidHelm.Crafting.Add((int)CraftingTable.MageTable, 1);
    druidHelm.RequiredItems.Clear();
    druidHelm.RequiredItems.Add("Silver", 30);
    druidHelm.RequiredItems.Add("Eitr", 15);
    druidHelm.RequiredItems.Add("Sap", 20);
    druidHelm.RequiredItems.Add("YggdrasilWood", 30);
    druidHelm.RequiredUpgradeItems.Clear();
    druidHelm.RequiredUpgradeItems.Add("Silver", 15);
    druidHelm.RequiredUpgradeItems.Add("Eitr", 5);
    druidHelm.RequiredUpgradeItems.Add("Sap", 10);
    druidHelm.RequiredUpgradeItems.Add("YggdrasilWood", 15);
    druidHelm.Armor.ArmorBase = 20;
    druidHelm.Armor.ArmorPerLevel = 4;
    druidHelm.Armor.MovementModifier = -0.02f;
    druidHelm.Armor.Weight = 6;
    druidHelm.Prefab.FixItemLayer();

    var druidChest = plugin.ItemManager["druidchest"];
    druidChest.Name.Alias("$SouthsilArmor_DruidChest_Name");
    druidChest.Description.Alias("$SouthsilArmor_DruidChest_Description");
    druidChest.Crafting.Clear();
    druidChest.Crafting.Add((int)CraftingTable.MageTable, 1);
    druidChest.RequiredItems.Clear();
    druidChest.RequiredItems.Add("BlackMetal", 40);
    druidChest.RequiredItems.Add("LinenThread", 30);
    druidChest.RequiredItems.Add("ScaleHide", 10);
    druidChest.RequiredItems.Add("LoxPelt", 4);
    druidChest.RequiredUpgradeItems.Clear();
    druidChest.RequiredUpgradeItems.Add("BlackMetal", 20);
    druidChest.RequiredUpgradeItems.Add("LinenThread", 15);
    druidChest.RequiredUpgradeItems.Add("ScaleHide", 5);
    druidChest.RequiredUpgradeItems.Add("LoxPelt", 1);
    druidChest.Armor.ArmorBase = 60;
    druidChest.Armor.ArmorPerLevel = 5;
    druidChest.Armor.MovementModifier = -0.10f;
    druidChest.Armor.Weight = 18;

    var druidLegs = plugin.ItemManager["druidlegs"];
    druidLegs.Name.Alias("$SouthsilArmor_DruidLegs_Name");
    druidLegs.Description.Alias("$SouthsilArmor_DruidLegs_Description");
    druidLegs.Crafting.Clear();
    druidLegs.Crafting.Add((int)CraftingTable.MageTable, 1);
    druidLegs.RequiredItems.Clear();
    druidLegs.RequiredItems.Add("BlackMetal", 30);
    druidLegs.RequiredItems.Add("LinenThread", 20);
    druidLegs.RequiredItems.Add("ScaleHide", 4);
    druidLegs.RequiredItems.Add("LoxPelt", 2);
    druidLegs.RequiredUpgradeItems.Clear();
    druidLegs.RequiredUpgradeItems.Add("BlackMetal", 15);
    druidLegs.RequiredUpgradeItems.Add("LinenThread", 10);
    druidLegs.RequiredUpgradeItems.Add("ScaleHide", 2);
    druidLegs.RequiredUpgradeItems.Add("LoxPelt", 1);
    druidLegs.Armor.ArmorBase = 40;
    druidLegs.Armor.ArmorPerLevel = 5;
    druidLegs.Armor.MovementModifier = -0.06f;
    druidLegs.Armor.Weight = 12;

    var druidSetEffect = druidHelm.Set.Effect;
    druidSetEffect.m_name = "$SouthsilArmor_DruidSet_Effect_Name";
    druidSetEffect.m_tooltip = "$SouthsilArmor_DruidSet_Effect_Tooltip";
    druidSetEffect.m_skillLevel = Skills.SkillType.ElementalMagic;
    druidSetEffect.m_skillLevelModifier = 15;
    druidSetEffect.m_mods.Clear();
    druidSetEffect.m_mods.Add(new()
    {
      m_type = HitData.DamageType.Lightning,
      m_modifier = HitData.DamageModifier.Resistant,
    });
    druidSetEffect.m_staminaRegenMultiplier = 1;
    druidSetEffect.m_addMaxCarryWeight = 0;

    druidHelm.Set.Name = "Druid";
    druidHelm.Set.Size = 3;
    druidChest.Set = druidHelm.Set;
    druidLegs.Set = druidHelm.Set;
  }
}
