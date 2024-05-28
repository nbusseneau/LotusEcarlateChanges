extern alias SouthsilArmor;

using System;
using System.Collections.Generic;
using LotusEcarlateChanges.Changes.JotunnBased;
using LotusEcarlateChanges.Extensions;
using LotusEcarlateChanges.Model.Changes;
using SouthsilArmor::ItemManager;
using UnityEngine;

namespace LotusEcarlateChanges.Changes.StandaloneManagerBased;

public class SouthsilArmor : StandaloneManagerBasedChangesBase
{
  private static readonly List<Action> s_onLocalizationAddedCallbacks = [];

  protected override void ApplyInternal()
  {
    var itemManager = this.RegisterItemManager(Item.registeredItems, PrefabManager.prefabs, PrefabManager.ZnetOnlyPrefabs);

    // Kludge to wait for Jotunn to have loaded localization before changing names/descriptions
    static void onLocalizationAddedCallback()
    {
      s_onLocalizationAddedCallbacks.ForEach(callback => callback.Invoke());
      Jotunn.Managers.LocalizationManager.OnLocalizationAdded -= onLocalizationAddedCallback;
    }
    Jotunn.Managers.LocalizationManager.OnLocalizationAdded += onLocalizationAddedCallback;

    // Chieftain
    this.Keep("chiefhelmboar");
    this.Keep("chiefhelmdeer");
    this.Keep("chiefchest");
    this.Keep("chieflegs");

    var chieftainHelmBoar = itemManager["chiefhelmboar"];
    s_onLocalizationAddedCallbacks.Add(() =>
    {
      chieftainHelmBoar.Name.Alias("$SouthsilArmor_ChieftainHelmBoar_Name");
      chieftainHelmBoar.Description.Alias("$SouthsilArmor_ChieftainHelmBoar_Description");
    });
    chieftainHelmBoar.Crafting.Stations.Clear();
    chieftainHelmBoar.Crafting.Add(CraftingTable.Workbench, 2);
    chieftainHelmBoar.RequiredItems.Requirements.Clear();
    chieftainHelmBoar.RequiredItems.Add("DeerHide", 2);
    chieftainHelmBoar.RequiredItems.Add("LeatherScraps", 2);
    chieftainHelmBoar.RequiredItems.Add("FoxPelt_TW", 1);
    chieftainHelmBoar.RequiredItems.Add("TrophyBoar", 2);
    chieftainHelmBoar.RequiredUpgradeItems.Requirements.Clear();
    chieftainHelmBoar.RequiredUpgradeItems.Add("DeerHide", 1);
    chieftainHelmBoar.RequiredUpgradeItems.Add("LeatherScraps", 1);
    chieftainHelmBoar.Item().Armor.ArmorBase = 2;
    chieftainHelmBoar.Item().Armor.ArmorPerLevel = 2;
    chieftainHelmBoar.Item().Armor.MovementModifier = -0.01f;
    chieftainHelmBoar.Item().Armor.Weight = 4;
    var chieftainBoarEquipEffect = chieftainHelmBoar.Item().Armor.EquipEffect;
    chieftainBoarEquipEffect.m_name = "$SouthsilArmor_ChieftainHelmBoar_Effect_Name";
    chieftainBoarEquipEffect.m_tooltip = "$SouthsilArmor_ChieftainHelmBoar_Effect_Tooltip";
    chieftainHelmBoar.Prefab.FixItemLayer();

    var chieftainHelmDeer = itemManager["chiefhelmdeer"];
    s_onLocalizationAddedCallbacks.Add(() =>
    {
      chieftainHelmDeer.Name.Alias("$SouthsilArmor_ChieftainHelmDeer_Name");
      chieftainHelmDeer.Description.Alias("$SouthsilArmor_ChieftainHelmDeer_Description");
    });
    chieftainHelmDeer.Crafting.Stations.Clear();
    chieftainHelmDeer.Crafting.Add(CraftingTable.Workbench, 2);
    chieftainHelmDeer.RequiredItems.Requirements.Clear();
    chieftainHelmDeer.RequiredItems.Add("DeerHide", 2);
    chieftainHelmDeer.RequiredItems.Add("LeatherScraps", 2);
    chieftainHelmDeer.RequiredItems.Add("FoxPelt_TW", 1);
    chieftainHelmDeer.RequiredItems.Add("TrophyDeer", 2);
    chieftainHelmDeer.RequiredUpgradeItems.Requirements.Clear();
    chieftainHelmDeer.RequiredUpgradeItems.Add("DeerHide", 1);
    chieftainHelmDeer.RequiredUpgradeItems.Add("LeatherScraps", 1);
    chieftainHelmDeer.Item().Armor.ArmorBase = 2;
    chieftainHelmDeer.Item().Armor.ArmorPerLevel = 2;
    chieftainHelmDeer.Item().Armor.MovementModifier = -0.01f;
    chieftainHelmDeer.Item().Armor.Weight = 4;
    var chieftainDeerEquipEffect = chieftainHelmDeer.Item().Armor.EquipEffect;
    chieftainDeerEquipEffect.m_name = "$SouthsilArmor_ChieftainHelmDeer_Effect_Name";
    chieftainDeerEquipEffect.m_tooltip = "$SouthsilArmor_ChieftainHelmDeer_Effect_Tooltip";
    chieftainDeerEquipEffect.m_speedModifier = 0;
    chieftainDeerEquipEffect.m_runStaminaDrainModifier = 0;
    chieftainDeerEquipEffect.m_staminaRegenMultiplier = 1.4f;
    chieftainHelmDeer.Prefab.FixItemLayer();

    var chieftainChest = itemManager["chiefchest"];
    s_onLocalizationAddedCallbacks.Add(() =>
    {
      chieftainChest.Name.Alias("$SouthsilArmor_ChieftainChest_Name");
      chieftainChest.Description.Alias("$SouthsilArmor_ChieftainChest_Description");
    });
    chieftainChest.Crafting.Stations.Clear();
    chieftainChest.Crafting.Add(CraftingTable.Workbench, 2);
    chieftainChest.RequiredItems.Requirements.Clear();
    chieftainChest.RequiredItems.Add("DeerHide", 6);
    chieftainChest.RequiredItems.Add("FoxPelt_TW", 3);
    chieftainChest.RequiredItems.Add("ShieldWood", 1);
    chieftainChest.RequiredItems.Add("Feathers", 5);
    chieftainChest.RequiredUpgradeItems.Requirements.Clear();
    chieftainChest.RequiredUpgradeItems.Add("DeerHide", 3);
    chieftainChest.RequiredUpgradeItems.Add("LeatherScraps", 3);
    chieftainChest.Item().Armor.ArmorBase = 6;
    chieftainChest.Item().Armor.ArmorPerLevel = 3;
    chieftainChest.Item().Armor.MovementModifier = -0.06f;
    chieftainChest.Item().Armor.Weight = 12;

    var chieftainLegs = itemManager["chieflegs"];
    s_onLocalizationAddedCallbacks.Add(() =>
    {
      chieftainLegs.Name.Alias("$SouthsilArmor_ChieftainLegs_Name");
      chieftainLegs.Description.Alias("$SouthsilArmor_ChieftainLegs_Description");
    });
    chieftainLegs.Crafting.Stations.Clear();
    chieftainLegs.Crafting.Add(CraftingTable.Workbench, 2);
    chieftainLegs.RequiredItems.Requirements.Clear();
    chieftainLegs.RequiredItems.Add("DeerHide", 4);
    chieftainLegs.RequiredItems.Add("FoxPelt_TW", 2);
    chieftainLegs.RequiredItems.Add("KnifeFlint", 2);
    chieftainLegs.RequiredItems.Add("AxeFlint", 1);
    chieftainLegs.RequiredUpgradeItems.Requirements.Clear();
    chieftainLegs.RequiredUpgradeItems.Add("DeerHide", 2);
    chieftainLegs.RequiredUpgradeItems.Add("LeatherScraps", 2);
    chieftainLegs.Item().Armor.ArmorBase = 4;
    chieftainLegs.Item().Armor.ArmorPerLevel = 3;
    chieftainLegs.Item().Armor.MovementModifier = -0.03f;
    chieftainLegs.Item().Armor.Weight = 8;

    // Battleswine
    this.Keep("heavybronzehelm");
    this.Keep("heavybronzechest");
    this.Keep("heavybronzelegs");

    var battleswineHelm = itemManager["heavybronzehelm"];
    s_onLocalizationAddedCallbacks.Add(() =>
    {
      battleswineHelm.Name.Alias("$SouthsilArmor_BattleswineHelm_Name");
      battleswineHelm.Description.Alias("$SouthsilArmor_BattleswineHelm_Description");
    });
    battleswineHelm.Crafting.Stations.Clear();
    battleswineHelm.Crafting.Add(CraftingTable.Forge, 2);
    battleswineHelm.RequiredItems.Requirements.Clear();
    battleswineHelm.RequiredItems.Add("Bronze", 2);
    battleswineHelm.RequiredItems.Add("RazorbackLeather_TW", 2);
    battleswineHelm.RequiredItems.Add("BlackBearPelt_TW", 1);
    battleswineHelm.RequiredItems.Add("RazorbackTusk_TW", 4);
    battleswineHelm.RequiredUpgradeItems.Requirements.Clear();
    battleswineHelm.RequiredUpgradeItems.Add("Bronze", 1);
    battleswineHelm.RequiredUpgradeItems.Add("DeerHide", 1);
    battleswineHelm.Item().Armor.ArmorBase = 6;
    battleswineHelm.Item().Armor.ArmorPerLevel = 3;
    battleswineHelm.Item().Armor.MovementModifier = -0.02f;
    battleswineHelm.Item().Armor.Weight = 6;
    battleswineHelm.Prefab.FixItemLayer();

    var battleswineChest = itemManager["heavybronzechest"];
    s_onLocalizationAddedCallbacks.Add(() =>
    {
      battleswineChest.Name.Alias("$SouthsilArmor_BattleswineChest_Name");
      battleswineChest.Description.Alias("$SouthsilArmor_BattleswineChest_Description");
    });
    battleswineChest.Crafting.Stations.Clear();
    battleswineChest.Crafting.Add(CraftingTable.Forge, 2);
    battleswineChest.RequiredItems.Requirements.Clear();
    battleswineChest.RequiredItems.Add("Bronze", 8);
    battleswineChest.RequiredItems.Add("RazorbackLeather_TW", 6);
    battleswineChest.RequiredItems.Add("BlackBearPelt_TW", 3);
    battleswineChest.RequiredItems.Add("TrophyRazorback_TW", 1);
    battleswineChest.RequiredUpgradeItems.Requirements.Clear();
    battleswineChest.RequiredUpgradeItems.Add("Bronze", 4);
    battleswineChest.RequiredUpgradeItems.Add("DeerHide", 2);
    battleswineChest.Item().Armor.ArmorBase = 18;
    battleswineChest.Item().Armor.ArmorPerLevel = 4;
    battleswineChest.Item().Armor.MovementModifier = -0.10f;
    battleswineChest.Item().Armor.Weight = 18;

    var battleswineLegs = itemManager["heavybronzelegs"];
    s_onLocalizationAddedCallbacks.Add(() =>
    {
      battleswineLegs.Name.Alias("$SouthsilArmor_BattleswineLegs_Name");
      battleswineLegs.Description.Alias("$SouthsilArmor_BattleswineLegs_Description");
    });
    battleswineLegs.Crafting.Stations.Clear();
    battleswineLegs.Crafting.Add(CraftingTable.Forge, 2);
    battleswineLegs.RequiredItems.Requirements.Clear();
    battleswineLegs.RequiredItems.Add("Bronze", 5);
    battleswineLegs.RequiredItems.Add("RazorbackLeather_TW", 3);
    battleswineLegs.RequiredItems.Add("BlackBearPelt_TW", 2);
    battleswineLegs.RequiredUpgradeItems.Requirements.Clear();
    battleswineLegs.RequiredUpgradeItems.Add("Bronze", 3);
    battleswineLegs.RequiredUpgradeItems.Add("DeerHide", 1);
    battleswineLegs.Item().Armor.ArmorBase = 12;
    battleswineLegs.Item().Armor.ArmorPerLevel = 3;
    battleswineLegs.Item().Armor.MovementModifier = -0.06f;
    battleswineLegs.Item().Armor.Weight = 12;

    var battleswineSetEffect = ScriptableObject.CreateInstance<SE_Stats>();
    battleswineSetEffect.m_name = "$SouthsilArmor_BattleswineSet_Effect_Name";
    battleswineSetEffect.m_tooltip = "$SouthsilArmor_BattleswineSet_Effect_Tooltip";
    battleswineSetEffect.m_icon = battleswineHelm.Item().ItemData.GetIcon();
    battleswineSetEffect.m_skillLevel = Skills.SkillType.Spears;
    battleswineSetEffect.m_skillLevelModifier = 15;
    battleswineSetEffect.m_skillLevel2 = CustomSkills.Warpikes;
    battleswineSetEffect.m_skillLevelModifier2 = 15;

    battleswineHelm.Item().Set.Effect = battleswineSetEffect;
    battleswineHelm.Item().Set.Name = "Battleswine";
    battleswineHelm.Item().Set.Size = 3;
    battleswineChest.Item().Set = battleswineHelm.Item().Set;
    battleswineLegs.Item().Set = battleswineHelm.Item().Set;

    // Draugr
    this.Keep("swamphelm");
    this.Keep("swampchest");
    this.Keep("swamplegs");

    var draugrHelm = itemManager["swamphelm"];
    s_onLocalizationAddedCallbacks.Add(() =>
    {
      draugrHelm.Name.Alias("$SouthsilArmor_DraugrHelm_Name");
      draugrHelm.Description.Alias("$SouthsilArmor_DraugrHelm_Description");
    });
    draugrHelm.Crafting.Stations.Clear();
    draugrHelm.Crafting.Add(CraftingTable.Forge, 3);
    draugrHelm.RequiredItems.Requirements.Clear();
    draugrHelm.RequiredItems.Add("Iron", 12);
    draugrHelm.RequiredItems.Add("RottenPelt_TW", 2);
    draugrHelm.RequiredItems.Add("WitheredBone", 2);
    draugrHelm.RequiredItems.Add("TrophyCrawler_TW", 1);
    draugrHelm.RequiredUpgradeItems.Requirements.Clear();
    draugrHelm.RequiredUpgradeItems.Add("Iron", 3);
    draugrHelm.RequiredUpgradeItems.Add("RottenPelt_TW", 1);
    draugrHelm.RequiredUpgradeItems.Add("WitheredBone", 1);
    draugrHelm.Item().Armor.ArmorBase = 9;
    draugrHelm.Item().Armor.ArmorPerLevel = 3;
    draugrHelm.Item().Armor.MovementModifier = -0.02f;
    draugrHelm.Item().Armor.Weight = 6;
    draugrHelm.Prefab.FixItemLayer();

    var draugrChest = itemManager["swampchest"];
    s_onLocalizationAddedCallbacks.Add(() =>
    {
      draugrChest.Name.Alias("$SouthsilArmor_DraugrChest_Name");
      draugrChest.Description.Alias("$SouthsilArmor_DraugrChest_Description");
    });
    draugrChest.Crafting.Stations.Clear();
    draugrChest.Crafting.Add(CraftingTable.Forge, 3);
    draugrChest.RequiredItems.Requirements.Clear();
    draugrChest.RequiredItems.Add("Iron", 36);
    draugrChest.RequiredItems.Add("RottenPelt_TW", 4);
    draugrChest.RequiredItems.Add("WitheredBone", 6);
    draugrChest.RequiredUpgradeItems.Requirements.Clear();
    draugrChest.RequiredUpgradeItems.Add("Iron", 9);
    draugrChest.RequiredUpgradeItems.Add("RottenPelt_TW", 1);
    draugrChest.RequiredUpgradeItems.Add("WitheredBone", 3);
    draugrChest.Item().Armor.ArmorBase = 27;
    draugrChest.Item().Armor.ArmorPerLevel = 4;
    draugrChest.Item().Armor.MovementModifier = -0.10f;
    draugrChest.Item().Armor.Weight = 18;

    var draugrLegs = itemManager["swamplegs"];
    s_onLocalizationAddedCallbacks.Add(() =>
    {
      draugrLegs.Name.Alias("$SouthsilArmor_DraugrLegs_Name");
      draugrLegs.Description.Alias("$SouthsilArmor_DraugrLegs_Description");
    });
    draugrLegs.Crafting.Stations.Clear();
    draugrLegs.Crafting.Add(CraftingTable.Forge, 3);
    draugrLegs.RequiredItems.Requirements.Clear();
    draugrLegs.RequiredItems.Add("Iron", 24);
    draugrLegs.RequiredItems.Add("RottenPelt_TW", 2);
    draugrLegs.RequiredItems.Add("WitheredBone", 4);
    draugrLegs.RequiredItems.Add("TrophySkeleton", 4);
    draugrLegs.RequiredUpgradeItems.Requirements.Clear();
    draugrLegs.RequiredUpgradeItems.Add("Iron", 6);
    draugrLegs.RequiredUpgradeItems.Add("RottenPelt_TW", 1);
    draugrLegs.RequiredUpgradeItems.Add("WitheredBone", 2);
    draugrLegs.Item().Armor.ArmorBase = 18;
    draugrLegs.Item().Armor.ArmorPerLevel = 3;
    draugrLegs.Item().Armor.MovementModifier = -0.06f;
    draugrLegs.Item().Armor.Weight = 12;

    var draugrSetEffect = draugrHelm.Item().Set.Effect;
    draugrSetEffect.m_name = "$SouthsilArmor_DraugrSet_Effect_Name";
    draugrSetEffect.m_tooltip = "$SouthsilArmor_DraugrSet_Effect_Tooltip";
    draugrSetEffect.m_mods.Clear();
    draugrSetEffect.m_mods.Add(new()
    {
      m_type = HitData.DamageType.Poison,
      m_modifier = HitData.DamageModifier.Resistant,
    });

    draugrHelm.Item().Set.Name = "Draugr";
    draugrHelm.Item().Set.Size = 3;
    draugrChest.Item().Set = draugrHelm.Item().Set;
    draugrLegs.Item().Set = draugrHelm.Item().Set;

    // Grizzly
    this.Keep("heavybearhelm");
    this.Keep("heavybearchest");
    this.Keep("heavybearlegs");

    var grizzlyHelm = itemManager["heavybearhelm"];
    s_onLocalizationAddedCallbacks.Add(() =>
    {
      grizzlyHelm.Name.Alias("$SouthsilArmor_GrizzlyHelm_Name");
      grizzlyHelm.Description.Alias("$SouthsilArmor_GrizzlyHelm_Description");
    });
    grizzlyHelm.Crafting.Stations.Clear();
    grizzlyHelm.Crafting.Add(CraftingTable.Forge, 3);
    grizzlyHelm.RequiredItems.Requirements.Clear();
    grizzlyHelm.RequiredItems.Add("Silver", 5);
    grizzlyHelm.RequiredItems.Add("GrizzlyBearPelt_TW", 1);
    grizzlyHelm.RequiredItems.Add("TrophyHatchling", 2);
    grizzlyHelm.RequiredUpgradeItems.Requirements.Clear();
    grizzlyHelm.RequiredUpgradeItems.Add("Silver", 2);
    grizzlyHelm.RequiredUpgradeItems.Add("WolfPelt", 1);
    grizzlyHelm.Item().Armor.ArmorBase = 14;
    grizzlyHelm.Item().Armor.ArmorPerLevel = 4;
    grizzlyHelm.Item().Armor.MovementModifier = -0.02f;
    grizzlyHelm.Item().Armor.Weight = 6;
    grizzlyHelm.Prefab.FixItemLayer();

    var grizzlyChest = itemManager["heavybearchest"];
    s_onLocalizationAddedCallbacks.Add(() =>
    {
      grizzlyChest.Name.Alias("$SouthsilArmor_GrizzlyChest_Name");
      grizzlyChest.Description.Alias("$SouthsilArmor_GrizzlyChest_Description");
    });
    grizzlyChest.Crafting.Stations.Clear();
    grizzlyChest.Crafting.Add(CraftingTable.Forge, 3);
    grizzlyChest.RequiredItems.Requirements.Clear();
    grizzlyChest.RequiredItems.Add("Silver", 20);
    grizzlyChest.RequiredItems.Add("GrizzlyBearPelt_TW", 2);
    grizzlyChest.RequiredItems.Add("TrophyHatchling", 2);
    grizzlyChest.RequiredItems.Add("ClaymoreIron_TW", 1);
    grizzlyChest.RequiredUpgradeItems.Requirements.Clear();
    grizzlyChest.RequiredUpgradeItems.Add("Silver", 8);
    grizzlyChest.RequiredUpgradeItems.Add("WolfPelt", 3);
    grizzlyChest.Item().Armor.ArmorBase = 27;
    grizzlyChest.Item().Armor.ArmorPerLevel = 4;
    grizzlyChest.Item().Armor.MovementModifier = -0.10f;
    grizzlyChest.Item().Armor.Weight = 18;

    var grizzlyLegs = itemManager["heavybearlegs"];
    s_onLocalizationAddedCallbacks.Add(() =>
    {
      grizzlyLegs.Name.Alias("$SouthsilArmor_GrizzlyLegs_Name");
      grizzlyLegs.Description.Alias("$SouthsilArmor_GrizzlyLegs_Description");
    });
    grizzlyLegs.Crafting.Stations.Clear();
    grizzlyLegs.Crafting.Add(CraftingTable.Forge, 3);
    grizzlyLegs.RequiredItems.Requirements.Clear();
    grizzlyLegs.RequiredItems.Add("Silver", 10);
    grizzlyLegs.RequiredItems.Add("GrizzlyBearPelt_TW", 1);
    grizzlyLegs.RequiredItems.Add("KnifeSilver", 2);
    grizzlyLegs.RequiredItems.Add("TankardAnniversary", 1);
    grizzlyLegs.RequiredUpgradeItems.Requirements.Clear();
    grizzlyLegs.RequiredUpgradeItems.Add("Silver", 5);
    grizzlyLegs.RequiredUpgradeItems.Add("WolfPelt", 2);
    grizzlyLegs.Item().Armor.ArmorBase = 18;
    grizzlyLegs.Item().Armor.ArmorPerLevel = 3;
    grizzlyLegs.Item().Armor.MovementModifier = -0.06f;
    grizzlyLegs.Item().Armor.Weight = 12;

    var grizzlySetEffect = grizzlyHelm.Item().Set.Effect;
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

    grizzlyHelm.Item().Set.Name = "Grizzly";
    grizzlyHelm.Item().Set.Size = 3;
    grizzlyChest.Item().Set = grizzlyHelm.Item().Set;
    grizzlyLegs.Item().Set = grizzlyHelm.Item().Set;

    // Feral
    this.Keep("obswolfhelm");
    this.Keep("obswolfchest");
    this.Keep("obswolflegs");

    var feralHelm = itemManager["obswolfhelm"];
    s_onLocalizationAddedCallbacks.Add(() =>
    {
      feralHelm.Name.Alias("$SouthsilArmor_FeralHelm_Name");
      feralHelm.Description.Alias("$SouthsilArmor_FeralHelm_Description");
    });
    feralHelm.Crafting.Stations.Clear();
    feralHelm.Crafting.Add(CraftingTable.Forge, 2);
    feralHelm.RequiredItems.Requirements.Clear();
    feralHelm.RequiredItems.Add("BlackMetal", 4);
    feralHelm.RequiredItems.Add("WolfHairBundle", 10);
    feralHelm.RequiredItems.Add("TrophyProwler_TW", 2);
    feralHelm.RequiredItems.Add("Ruby", 5);
    feralHelm.RequiredUpgradeItems.Requirements.Clear();
    feralHelm.RequiredUpgradeItems.Add("BlackMetal", 2);
    feralHelm.RequiredUpgradeItems.Add("WolfHairBundle", 5);
    feralHelm.Item().Armor.ArmorBase = 7;
    feralHelm.Item().Armor.ArmorPerLevel = 2;
    feralHelm.Item().Armor.MovementModifier = 0;
    feralHelm.Item().Armor.Weight = 1;
    feralHelm.Prefab.FixItemLayer();

    var feralChest = itemManager["obswolfchest"];
    s_onLocalizationAddedCallbacks.Add(() =>
    {
      feralChest.Name.Alias("$SouthsilArmor_FeralChest_Name");
      feralChest.Description.Alias("$SouthsilArmor_FeralChest_Description");
    });
    feralChest.Crafting.Stations.Clear();
    feralChest.Crafting.Add(CraftingTable.Forge, 2);
    feralChest.RequiredItems.Requirements.Clear();
    feralChest.RequiredItems.Add("BlackMetal", 12);
    feralChest.RequiredItems.Add("LoxPelt", 4);
    feralChest.RequiredItems.Add("ProwlerFang_TW", 12);
    feralChest.RequiredItems.Add("TrophyUlv", 4);
    feralChest.RequiredUpgradeItems.Requirements.Clear();
    feralChest.RequiredUpgradeItems.Add("BlackMetal", 6);
    feralChest.RequiredUpgradeItems.Add("LoxPelt", 1);
    feralChest.RequiredUpgradeItems.Add("ProwlerFang_TW", 3);
    feralChest.Item().Armor.ArmorBase = 21;
    feralChest.Item().Armor.ArmorPerLevel = 3;
    feralChest.Item().Armor.MovementModifier = -0.01f;
    feralChest.Item().Armor.Weight = 6;
    feralChest.Item().Armor.DamageModifiers.Clear();

    var feralLegs = itemManager["obswolflegs"];
    s_onLocalizationAddedCallbacks.Add(() =>
    {
      feralLegs.Name.Alias("$SouthsilArmor_FeralLegs_Name");
      feralLegs.Description.Alias("$SouthsilArmor_FeralLegs_Description");
    });
    feralLegs.Crafting.Stations.Clear();
    feralLegs.Crafting.Add(CraftingTable.Forge, 2);
    feralLegs.RequiredItems.Requirements.Clear();
    feralLegs.RequiredItems.Add("BlackMetal", 8);
    feralLegs.RequiredItems.Add("LinenThread", 20);
    feralLegs.RequiredItems.Add("WolfClaw", 5);
    feralLegs.RequiredUpgradeItems.Requirements.Clear();
    feralLegs.RequiredUpgradeItems.Add("BlackMetal", 4);
    feralLegs.RequiredUpgradeItems.Add("LinenThread", 10);
    feralLegs.Item().Armor.ArmorBase = 14;
    feralLegs.Item().Armor.ArmorPerLevel = 3;
    feralLegs.Item().Armor.MovementModifier = -0.01f;
    feralLegs.Item().Armor.Weight = 3;

    var feralSetEffect = feralHelm.Item().Set.Effect;
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

    feralHelm.Item().Set.Name = "Feral";
    feralHelm.Item().Set.Size = 3;
    feralChest.Item().Set = feralHelm.Item().Set;
    feralLegs.Item().Set = feralHelm.Item().Set;

    // Shieldmaiden
    this.Keep("norahhelm");
    this.Keep("norahhelmalt");
    this.Keep("norahchest");
    this.Keep("norahlegs");

    var shieldmaidenHelm = itemManager["norahhelm"];
    s_onLocalizationAddedCallbacks.Add(() =>
    {
      shieldmaidenHelm.Name.Alias("$SouthsilArmor_ShieldmaidenHelm_Name");
      shieldmaidenHelm.Description.Alias("$SouthsilArmor_ShieldmaidenHelm_Description");
    });
    shieldmaidenHelm.Crafting.Stations.Clear();
    shieldmaidenHelm.Crafting.Add(CraftingTable.Forge, 2);
    shieldmaidenHelm.RequiredItems.Requirements.Clear();
    shieldmaidenHelm.RequiredItems.Add("LinenThread", 10);
    shieldmaidenHelm.RequiredItems.Add("Coins", 500);
    shieldmaidenHelm.RequiredUpgradeItems.Requirements.Clear();
    shieldmaidenHelm.RequiredUpgradeItems.Add("LinenThread", 10);
    shieldmaidenHelm.Item().Armor.ArmorBase = 10;
    shieldmaidenHelm.Item().Armor.ArmorPerLevel = 2;
    shieldmaidenHelm.Item().Armor.MovementModifier = 0;
    shieldmaidenHelm.Item().Armor.Weight = 3;

    var shieldmaidenHelmAlt = itemManager["norahhelmalt"];
    s_onLocalizationAddedCallbacks.Add(() =>
    {
      shieldmaidenHelmAlt.Name.Alias("$SouthsilArmor_ShieldmaidenHelmAlt_Name");
      shieldmaidenHelmAlt.Description.Alias("$SouthsilArmor_ShieldmaidenHelmAlt_Description");
    });
    shieldmaidenHelmAlt.Crafting.Stations.Clear();
    shieldmaidenHelmAlt.Crafting.Add(CraftingTable.Forge, 2);
    shieldmaidenHelmAlt.RequiredItems.Requirements.Clear();
    shieldmaidenHelmAlt.RequiredItems.Add("LinenThread", 10);
    shieldmaidenHelmAlt.RequiredItems.Add("LoxPelt", 1); ;
    shieldmaidenHelmAlt.RequiredUpgradeItems.Requirements.Clear();
    shieldmaidenHelmAlt.RequiredUpgradeItems.Add("LinenThread", 10);
    shieldmaidenHelmAlt.Item().Armor.ArmorBase = 10;
    shieldmaidenHelmAlt.Item().Armor.ArmorPerLevel = 2;
    shieldmaidenHelmAlt.Item().Armor.MovementModifier = 0;
    shieldmaidenHelmAlt.Item().Armor.Weight = 3;
    shieldmaidenHelmAlt.Prefab.FixItemLayer();

    var shieldmaidenChest = itemManager["norahchest"];
    s_onLocalizationAddedCallbacks.Add(() =>
    {
      shieldmaidenChest.Name.Alias("$SouthsilArmor_ShieldmaidenChest_Name");
      shieldmaidenChest.Description.Alias("$SouthsilArmor_ShieldmaidenChest_Description");
    });
    shieldmaidenChest.Crafting.Stations.Clear();
    shieldmaidenChest.Crafting.Add(CraftingTable.Forge, 2);
    shieldmaidenChest.RequiredItems.Requirements.Clear();
    shieldmaidenChest.RequiredItems.Add("Iron", 12);
    shieldmaidenChest.RequiredItems.Add("LinenThread", 30);
    shieldmaidenChest.RequiredItems.Add("LoxPelt", 4);
    shieldmaidenChest.RequiredItems.Add("KnifeSilver", 1);
    shieldmaidenChest.RequiredUpgradeItems.Requirements.Clear();
    shieldmaidenChest.RequiredUpgradeItems.Add("Iron", 3);
    shieldmaidenChest.RequiredUpgradeItems.Add("LinenThread", 15);
    shieldmaidenChest.RequiredUpgradeItems.Add("LoxPelt", 1);
    shieldmaidenChest.Item().Armor.ArmorBase = 30;
    shieldmaidenChest.Item().Armor.ArmorPerLevel = 3;
    shieldmaidenChest.Item().Armor.MovementModifier = -0.04f;
    shieldmaidenChest.Item().Armor.Weight = 10;

    var shieldmaidenLegs = itemManager["norahlegs"];
    s_onLocalizationAddedCallbacks.Add(() =>
    {
      shieldmaidenLegs.Name.Alias("$SouthsilArmor_ShieldmaidenLegs_Name");
      shieldmaidenLegs.Description.Alias("$SouthsilArmor_ShieldmaidenLegs_Description");
    });
    shieldmaidenLegs.Crafting.Stations.Clear();
    shieldmaidenLegs.Crafting.Add(CraftingTable.Forge, 2);
    shieldmaidenLegs.RequiredItems.Requirements.Clear();
    shieldmaidenLegs.RequiredItems.Add("Iron", 8);
    shieldmaidenLegs.RequiredItems.Add("LinenThread", 20);
    shieldmaidenLegs.RequiredItems.Add("LoxPelt", 2);
    shieldmaidenLegs.RequiredUpgradeItems.Requirements.Clear();
    shieldmaidenLegs.RequiredUpgradeItems.Add("Iron", 2);
    shieldmaidenLegs.RequiredUpgradeItems.Add("LinenThread", 10);
    shieldmaidenLegs.RequiredUpgradeItems.Add("LoxPelt", 2);
    shieldmaidenLegs.Item().Armor.ArmorBase = 20;
    shieldmaidenLegs.Item().Armor.ArmorPerLevel = 2;
    shieldmaidenLegs.Item().Armor.MovementModifier = -0.02f;
    shieldmaidenLegs.Item().Armor.Weight = 5;

    var shieldMaidenSetEffect = shieldmaidenHelm.Item().Set.Effect;
    shieldMaidenSetEffect.m_name = "$SouthsilArmor_ShieldmaidenSet_Effect_Name";
    shieldMaidenSetEffect.m_tooltip = "$SouthsilArmor_ShieldmaidenSet_Effect_Tooltip";
    shieldMaidenSetEffect.m_skillLevel = Skills.SkillType.Clubs;
    shieldMaidenSetEffect.m_skillLevelModifier = 15;
    shieldMaidenSetEffect.m_skillLevel2 = Skills.SkillType.Blocking;
    shieldMaidenSetEffect.m_skillLevelModifier2 = 15;

    shieldmaidenHelm.Item().Set.Name = "Shieldmaiden";
    shieldmaidenHelm.Item().Set.Size = 3;
    shieldmaidenHelmAlt.Item().Set = shieldmaidenHelm.Item().Set;
    shieldmaidenChest.Item().Set = shieldmaidenHelm.Item().Set;
    shieldmaidenLegs.Item().Set = shieldmaidenHelm.Item().Set;

    // Berserkir
    this.Keep("bearhelm2");
    this.Keep("bearchest2");
    this.Keep("bearlegs2");

    var berserkirHelm = itemManager["bearhelm2"];
    s_onLocalizationAddedCallbacks.Add(() =>
    {
      berserkirHelm.Name.Alias("$SouthsilArmor_BerserkirHelm_Name");
      berserkirHelm.Description.Alias("$SouthsilArmor_BerserkirHelm_Description");
    });
    berserkirHelm.Crafting.Stations.Clear();
    berserkirHelm.Crafting.Add(CraftingTable.Forge, 3);
    berserkirHelm.RequiredItems.Requirements.Clear();
    berserkirHelm.RequiredItems.Add("BlackMetal", 10);
    berserkirHelm.RequiredItems.Add("LinenThread", 10);
    berserkirHelm.RequiredUpgradeItems.Requirements.Clear();
    berserkirHelm.RequiredUpgradeItems.Add("BlackMetal", 5);
    berserkirHelm.RequiredUpgradeItems.Add("LinenThread", 5);
    berserkirHelm.Item().Armor.ArmorBase = 16;
    berserkirHelm.Item().Armor.ArmorPerLevel = 4;
    berserkirHelm.Item().Armor.MovementModifier = -0.02f;
    berserkirHelm.Item().Armor.Weight = 6;

    var berserkirChest = itemManager["bearchest2"];
    s_onLocalizationAddedCallbacks.Add(() =>
    {
      berserkirChest.Name.Alias("$SouthsilArmor_BerserkirChest_Name");
      berserkirChest.Description.Alias("$SouthsilArmor_BerserkirChest_Description");
    });
    berserkirChest.Crafting.Stations.Clear();
    berserkirChest.Crafting.Add(CraftingTable.Forge, 3);
    berserkirChest.RequiredItems.Requirements.Clear();
    berserkirChest.RequiredItems.Add("BlackMetal", 30);
    berserkirChest.RequiredItems.Add("LinenThread", 30);
    berserkirChest.RequiredItems.Add("Chain", 10);
    berserkirChest.RequiredUpgradeItems.Requirements.Clear();
    berserkirChest.RequiredUpgradeItems.Add("BlackMetal", 15);
    berserkirChest.RequiredUpgradeItems.Add("LinenThread", 15);
    berserkirChest.Item().Armor.ArmorBase = 48;
    berserkirChest.Item().Armor.ArmorPerLevel = 5;
    berserkirChest.Item().Armor.MovementModifier = -0.10f;
    berserkirChest.Item().Armor.Weight = 18;

    var berserkirLegs = itemManager["bearlegs2"];
    s_onLocalizationAddedCallbacks.Add(() =>
    {
      berserkirLegs.Name.Alias("$SouthsilArmor_BerserkirLegs_Name");
      berserkirLegs.Description.Alias("$SouthsilArmor_BerserkirLegs_Description");
    });
    berserkirLegs.Crafting.Stations.Clear();
    berserkirLegs.Crafting.Add(CraftingTable.Forge, 3);
    berserkirLegs.RequiredItems.Requirements.Clear();
    berserkirLegs.RequiredItems.Add("BlackMetal", 20);
    berserkirLegs.RequiredItems.Add("LinenThread", 20);
    berserkirLegs.RequiredUpgradeItems.Requirements.Clear();
    berserkirLegs.RequiredUpgradeItems.Add("BlackMetal", 10);
    berserkirLegs.RequiredUpgradeItems.Add("LinenThread", 10);
    berserkirLegs.Item().Armor.ArmorBase = 32;
    berserkirLegs.Item().Armor.ArmorPerLevel = 5;
    berserkirLegs.Item().Armor.MovementModifier = -0.06f;
    berserkirLegs.Item().Armor.Weight = 12;
    berserkirLegs.Item().Armor.DamageModifiers.Clear();

    var berserkirSetEffect = berserkirHelm.Item().Set.Effect;
    berserkirSetEffect.m_name = "$SouthsilArmor_BerserkirSet_Effect_Name";
    berserkirSetEffect.m_tooltip = "$SouthsilArmor_BerserkirSet_Effect_Tooltip";
    berserkirSetEffect.m_skillLevel = CustomSkills.TwoHandedAxes;
    berserkirSetEffect.m_skillLevelModifier = 15;
    berserkirSetEffect.m_skillLevel2 = CustomSkills.TwoHandedHammers;
    berserkirSetEffect.m_skillLevelModifier2 = 15;
    berserkirSetEffect.m_healthRegenMultiplier = 1;
    berserkirSetEffect.m_staminaRegenMultiplier = 1;

    berserkirHelm.Item().Set.Name = "Berserkir";
    berserkirHelm.Item().Set.Size = 3;
    berserkirChest.Item().Set = berserkirHelm.Item().Set;
    berserkirLegs.Item().Set = berserkirHelm.Item().Set;

    // Gjall-hunter
    this.Keep("heavycarhelm");
    this.Keep("heavycarchest");
    this.Keep("heavycarlegs");

    var gjallhunterHelm = itemManager["heavycarhelm"];
    s_onLocalizationAddedCallbacks.Add(() =>
    {
      gjallhunterHelm.Name.Alias("$SouthsilArmor_GjallhunterHelm_Name");
      gjallhunterHelm.Description.Alias("$SouthsilArmor_GjallhunterHelm_Description");
    });
    gjallhunterHelm.Crafting.Stations.Clear();
    gjallhunterHelm.Crafting.Add(CraftingTable.BlackForge, 1);
    gjallhunterHelm.RequiredItems.Requirements.Clear();
    gjallhunterHelm.RequiredItems.Add("Carapace", 8);
    gjallhunterHelm.RequiredItems.Add("Mandible", 2);
    gjallhunterHelm.RequiredItems.Add("TrophyGjall", 2);
    gjallhunterHelm.RequiredUpgradeItems.Requirements.Clear();
    gjallhunterHelm.RequiredUpgradeItems.Add("Carapace", 4);
    gjallhunterHelm.RequiredUpgradeItems.Add("Mandible", 1);
    gjallhunterHelm.Item().Armor.ArmorBase = 12;
    gjallhunterHelm.Item().Armor.ArmorPerLevel = 3;
    gjallhunterHelm.Item().Armor.MovementModifier = 0;
    gjallhunterHelm.Item().Armor.Weight = 3;
    gjallhunterHelm.Item().Armor.EquipEffect = null;
    gjallhunterHelm.Prefab.FixItemLayer();

    var gjallhunterChest = itemManager["heavycarchest"];
    s_onLocalizationAddedCallbacks.Add(() =>
    {
      gjallhunterChest.Name.Alias("$SouthsilArmor_GjallhunterChest_Name");
      gjallhunterChest.Description.Alias("$SouthsilArmor_GjallhunterChest_Description");
    });
    gjallhunterChest.Crafting.Stations.Clear();
    gjallhunterChest.Crafting.Add(CraftingTable.BlackForge, 1);
    gjallhunterChest.RequiredItems.Requirements.Clear();
    gjallhunterChest.RequiredItems.Add("Carapace", 20);
    gjallhunterChest.RequiredItems.Add("Mandible", 6);
    gjallhunterChest.RequiredItems.Add("ScaleHide", 10);
    gjallhunterChest.RequiredItems.Add("TrophySkeleton", 4);
    gjallhunterChest.RequiredUpgradeItems.Requirements.Clear();
    gjallhunterChest.RequiredUpgradeItems.Add("Carapace", 10);
    gjallhunterChest.RequiredUpgradeItems.Add("Mandible", 3);
    gjallhunterChest.RequiredUpgradeItems.Add("ScaleHide", 5);
    gjallhunterChest.Item().Armor.ArmorBase = 36;
    gjallhunterChest.Item().Armor.ArmorPerLevel = 4;
    gjallhunterChest.Item().Armor.MovementModifier = -0.04f;
    gjallhunterChest.Item().Armor.Weight = 10;

    var gjallhunterLegs = itemManager["heavycarlegs"];
    s_onLocalizationAddedCallbacks.Add(() =>
    {
      gjallhunterLegs.Name.Alias("$SouthsilArmor_GjallhunterLegs_Name");
      gjallhunterLegs.Description.Alias("$SouthsilArmor_GjallhunterLegs_Description");
    });
    gjallhunterLegs.Crafting.Stations.Clear();
    gjallhunterLegs.Crafting.Add(CraftingTable.BlackForge, 1);
    gjallhunterLegs.RequiredItems.Requirements.Clear();
    gjallhunterLegs.RequiredItems.Add("Carapace", 12);
    gjallhunterLegs.RequiredItems.Add("Mandible", 2);
    gjallhunterLegs.RequiredItems.Add("ScaleHide", 4);
    gjallhunterLegs.RequiredItems.Add("TrophySkeleton", 4);
    gjallhunterLegs.RequiredUpgradeItems.Requirements.Clear();
    gjallhunterLegs.RequiredUpgradeItems.Add("Carapace", 6);
    gjallhunterLegs.RequiredUpgradeItems.Add("Mandible", 1);
    gjallhunterLegs.RequiredUpgradeItems.Add("ScaleHide", 2);
    gjallhunterLegs.Item().Armor.ArmorBase = 24;
    gjallhunterLegs.Item().Armor.ArmorPerLevel = 3;
    gjallhunterLegs.Item().Armor.MovementModifier = -0.02f;
    gjallhunterLegs.Item().Armor.Weight = 5;

    var gjallhunterSetEffect = gjallhunterHelm.Item().Set.Effect;
    gjallhunterSetEffect.m_name = "$SouthsilArmor_GjallhunterSet_Effect_Name";
    gjallhunterSetEffect.m_tooltip = "$SouthsilArmor_GjallhunterSet_Effect_Tooltip";
    gjallhunterSetEffect.m_skillLevel = Skills.SkillType.Bows;
    gjallhunterSetEffect.m_skillLevelModifier = 15;
    gjallhunterSetEffect.m_skillLevel2 = Skills.SkillType.Crossbows;
    gjallhunterSetEffect.m_skillLevelModifier2 = 15;
    gjallhunterSetEffect.m_staminaRegenMultiplier = 1;

    gjallhunterHelm.Item().Set.Name = "Gjallhunter";
    gjallhunterHelm.Item().Set.Size = 3;
    gjallhunterChest.Item().Set = gjallhunterHelm.Item().Set;
    gjallhunterLegs.Item().Set = gjallhunterHelm.Item().Set;

    // Rune-knight
    this.Keep("runeknighthelm");
    this.Keep("runeknightchest");
    this.Keep("runeknightlegs");

    var runeknightHelm = itemManager["runeknighthelm"];
    s_onLocalizationAddedCallbacks.Add(() =>
    {
      runeknightHelm.Name.Alias("$SouthsilArmor_RuneknightHelm_Name");
      runeknightHelm.Description.Alias("$SouthsilArmor_RuneknightHelm_Description");
    });
    runeknightHelm.Crafting.Stations.Clear();
    runeknightHelm.Crafting.Add(CraftingTable.BlackForge, 1);
    runeknightHelm.RequiredItems.Requirements.Clear();
    runeknightHelm.RequiredItems.Add("BlackMetal", 10);
    runeknightHelm.RequiredItems.Add("Eitr", 15);
    runeknightHelm.RequiredItems.Add("DarkCrystal_TW", 5);
    runeknightHelm.RequiredUpgradeItems.Requirements.Clear();
    runeknightHelm.RequiredUpgradeItems.Add("BlackMetal", 5);
    runeknightHelm.RequiredUpgradeItems.Add("Eitr", 5);
    runeknightHelm.Item().Armor.ArmorBase = 18;
    runeknightHelm.Item().Armor.ArmorPerLevel = 4;
    runeknightHelm.Item().Armor.MovementModifier = -0.02f;
    runeknightHelm.Item().Armor.Weight = 5;
    runeknightHelm.Prefab.FixItemLayer();

    var runeknightChest = itemManager["runeknightchest"];
    s_onLocalizationAddedCallbacks.Add(() =>
    {
      runeknightChest.Name.Alias("$SouthsilArmor_RuneknightChest_Name");
      runeknightChest.Description.Alias("$SouthsilArmor_RuneknightChest_Description");
    });
    runeknightChest.Crafting.Stations.Clear();
    runeknightChest.Crafting.Add(CraftingTable.BlackForge, 1);
    runeknightChest.RequiredItems.Requirements.Clear();
    runeknightChest.RequiredItems.Add("BlackMetal", 30);
    runeknightChest.RequiredItems.Add("Eitr", 20);
    runeknightChest.RequiredItems.Add("LinenThread", 20);
    runeknightChest.RequiredItems.Add("BlackCore", 2);
    runeknightChest.RequiredUpgradeItems.Requirements.Clear();
    runeknightChest.RequiredUpgradeItems.Add("BlackMetal", 15);
    runeknightChest.RequiredUpgradeItems.Add("Eitr", 5);
    runeknightChest.RequiredUpgradeItems.Add("LinenThread", 10);
    runeknightChest.Item().Armor.ArmorBase = 54;
    runeknightChest.Item().Armor.ArmorPerLevel = 4;
    runeknightChest.Item().Armor.MovementModifier = -0.08f;
    runeknightChest.Item().Armor.Weight = 15;

    var runeknightLegs = itemManager["runeknightlegs"];
    s_onLocalizationAddedCallbacks.Add(() =>
    {
      runeknightLegs.Name.Alias("$SouthsilArmor_RuneknightLegs_Name");
      runeknightLegs.Description.Alias("$SouthsilArmor_RuneknightLegs_Description");
    });
    runeknightLegs.Crafting.Stations.Clear();
    runeknightLegs.Crafting.Add(CraftingTable.BlackForge, 1);
    runeknightLegs.RequiredItems.Requirements.Clear();
    runeknightLegs.RequiredItems.Add("BlackMetal", 20);
    runeknightLegs.RequiredItems.Add("Eitr", 20);
    runeknightLegs.RequiredItems.Add("LinenThread", 10);
    runeknightLegs.RequiredItems.Add("MeadEitrMinor", 5);
    runeknightLegs.RequiredUpgradeItems.Requirements.Clear();
    runeknightLegs.RequiredUpgradeItems.Add("BlackMetal", 10);
    runeknightLegs.RequiredUpgradeItems.Add("Eitr", 5);
    runeknightLegs.RequiredUpgradeItems.Add("LinenThread", 5);
    runeknightLegs.Item().Armor.ArmorBase = 36;
    runeknightLegs.Item().Armor.ArmorPerLevel = 4;
    runeknightLegs.Item().Armor.MovementModifier = -0.04f;
    runeknightLegs.Item().Armor.Weight = 10;

    var runeknightSetEffect = runeknightHelm.Item().Set.Effect;
    runeknightSetEffect.m_name = "$SouthsilArmor_RuneknightSet_Effect_Name";
    runeknightSetEffect.m_tooltip = "$SouthsilArmor_RuneknightSet_Effect_Tooltip";
    runeknightSetEffect.m_skillLevel = Skills.SkillType.BloodMagic;
    runeknightSetEffect.m_skillLevelModifier = 15;

    runeknightHelm.Item().Set.Name = "Runeknight";
    runeknightHelm.Item().Set.Size = 3;
    runeknightChest.Item().Set = runeknightHelm.Item().Set;
    runeknightLegs.Item().Set = runeknightHelm.Item().Set;

    // Druid
    this.Keep("druidhelm");
    this.Keep("druidchest");
    this.Keep("druidlegs");

    var druidHelm = itemManager["druidhelm"];
    s_onLocalizationAddedCallbacks.Add(() =>
    {
      druidHelm.Name.Alias("$SouthsilArmor_DruidHelm_Name");
      druidHelm.Description.Alias("$SouthsilArmor_DruidHelm_Description");
    });
    druidHelm.Crafting.Stations.Clear();
    druidHelm.Crafting.Add(CraftingTable.BlackForge, 1);
    druidHelm.RequiredItems.Requirements.Clear();
    druidHelm.RequiredItems.Add("Silver", 30);
    druidHelm.RequiredItems.Add("Eitr", 15);
    druidHelm.RequiredItems.Add("Sap", 20);
    druidHelm.RequiredItems.Add("YggdrasilWood", 30);
    druidHelm.RequiredUpgradeItems.Requirements.Clear();
    druidHelm.RequiredUpgradeItems.Add("Silver", 15);
    druidHelm.RequiredUpgradeItems.Add("Eitr", 5);
    druidHelm.RequiredUpgradeItems.Add("Sap", 10);
    druidHelm.RequiredUpgradeItems.Add("YggdrasilWood", 15);
    druidHelm.Item().Armor.ArmorBase = 20;
    druidHelm.Item().Armor.ArmorPerLevel = 4;
    druidHelm.Item().Armor.MovementModifier = -0.02f;
    druidHelm.Item().Armor.Weight = 6;
    druidHelm.Prefab.FixItemLayer();

    var druidChest = itemManager["druidchest"];
    s_onLocalizationAddedCallbacks.Add(() =>
    {
      druidChest.Name.Alias("$SouthsilArmor_DruidChest_Name");
      druidChest.Description.Alias("$SouthsilArmor_DruidChest_Description");
    });
    druidChest.Crafting.Stations.Clear();
    druidChest.Crafting.Add(CraftingTable.BlackForge, 1);
    druidChest.RequiredItems.Requirements.Clear();
    druidChest.RequiredItems.Add("BlackMetal", 40);
    druidChest.RequiredItems.Add("LinenThread", 30);
    druidChest.RequiredItems.Add("ScaleHide", 10);
    druidChest.RequiredItems.Add("LoxPelt", 4);
    druidChest.RequiredUpgradeItems.Requirements.Clear();
    druidChest.RequiredUpgradeItems.Add("BlackMetal", 20);
    druidChest.RequiredUpgradeItems.Add("LinenThread", 15);
    druidChest.RequiredUpgradeItems.Add("ScaleHide", 5);
    druidChest.RequiredUpgradeItems.Add("LoxPelt", 1);
    druidChest.Item().Armor.ArmorBase = 60;
    druidChest.Item().Armor.ArmorPerLevel = 5;
    druidChest.Item().Armor.MovementModifier = -0.10f;
    druidChest.Item().Armor.Weight = 18;

    var druidLegs = itemManager["druidlegs"];
    s_onLocalizationAddedCallbacks.Add(() =>
    {
      druidLegs.Name.Alias("$SouthsilArmor_DruidLegs_Name");
      druidLegs.Description.Alias("$SouthsilArmor_DruidLegs_Description");
    });
    druidLegs.Crafting.Stations.Clear();
    druidLegs.Crafting.Add(CraftingTable.BlackForge, 1);
    druidLegs.RequiredItems.Requirements.Clear();
    druidLegs.RequiredItems.Add("BlackMetal", 30);
    druidLegs.RequiredItems.Add("LinenThread", 20);
    druidLegs.RequiredItems.Add("ScaleHide", 4);
    druidLegs.RequiredItems.Add("LoxPelt", 2);
    druidLegs.RequiredUpgradeItems.Requirements.Clear();
    druidLegs.RequiredUpgradeItems.Add("BlackMetal", 15);
    druidLegs.RequiredUpgradeItems.Add("LinenThread", 10);
    druidLegs.RequiredUpgradeItems.Add("ScaleHide", 2);
    druidLegs.RequiredUpgradeItems.Add("LoxPelt", 1);
    druidLegs.Item().Armor.ArmorBase = 40;
    druidLegs.Item().Armor.ArmorPerLevel = 5;
    druidLegs.Item().Armor.MovementModifier = -0.06f;
    druidLegs.Item().Armor.Weight = 12;

    var druidSetEffect = druidHelm.Item().Set.Effect;
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

    druidHelm.Item().Set.Name = "Druid";
    druidHelm.Item().Set.Size = 3;
    druidChest.Item().Set = druidHelm.Item().Set;
    druidLegs.Item().Set = druidHelm.Item().Set;
  }
}
