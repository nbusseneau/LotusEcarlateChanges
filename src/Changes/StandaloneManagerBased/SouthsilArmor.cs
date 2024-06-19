extern alias SouthsilArmor;

using System;
using System.Collections.Generic;
using static LotusEcarlateChanges.Changes.Constants.Armor;
using LotusEcarlateChanges.Changes.Manual;
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
    itemManager.Keep([
      "chiefhelmboar",
      "chiefhelmdeer",
      "chiefchest",
      "chieflegs",
    ]);

    var (chieftainHelmBoar, chieftainHelmBoarWrapper) = itemManager["chiefhelmboar"];
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
    chieftainHelmBoarWrapper.Armor.ArmorBase = 2;
    chieftainHelmBoarWrapper.Armor.ArmorPerLevel = 2;
    chieftainHelmBoarWrapper.Armor.MovementModifier = Normal.MovementModifier.Helm;
    chieftainHelmBoarWrapper.Armor.Weight = Normal.Weight.Helm;
    var chieftainBoarEquipEffect = chieftainHelmBoarWrapper.Armor.EquipEffect;
    chieftainBoarEquipEffect.m_name = "$SouthsilArmor_ChieftainHelmBoar_Effect_Name";
    chieftainBoarEquipEffect.m_tooltip = "$SouthsilArmor_ChieftainHelmBoar_Effect_Tooltip";
    chieftainBoarEquipEffect.m_healthRegenMultiplier = 1.25f;
    chieftainBoarEquipEffect.m_staminaRegenMultiplier = 1f;
    chieftainBoarEquipEffect.m_skillLevel = Skills.SkillType.Blocking;
    chieftainBoarEquipEffect.m_skillLevelModifier = 10;
    chieftainHelmBoar.Prefab.FixItemLayer();

    var (chieftainHelmDeer, chieftainHelmDeerWrapper) = itemManager["chiefhelmdeer"];
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
    chieftainHelmDeerWrapper.Armor.ArmorBase = 2;
    chieftainHelmDeerWrapper.Armor.ArmorPerLevel = 2;
    chieftainHelmDeerWrapper.Armor.MovementModifier = Normal.MovementModifier.Helm;
    chieftainHelmDeerWrapper.Armor.Weight = Normal.Weight.Helm;
    var chieftainDeerEquipEffect = chieftainHelmDeerWrapper.Armor.EquipEffect;
    chieftainDeerEquipEffect.m_name = "$SouthsilArmor_ChieftainHelmDeer_Effect_Name";
    chieftainDeerEquipEffect.m_tooltip = "$SouthsilArmor_ChieftainHelmDeer_Effect_Tooltip";
    chieftainDeerEquipEffect.m_speedModifier = 0;
    chieftainDeerEquipEffect.m_runStaminaDrainModifier = 0;
    chieftainDeerEquipEffect.m_staminaRegenMultiplier = 1.5f;
    chieftainDeerEquipEffect.m_skillLevel = Skills.SkillType.Run;
    chieftainDeerEquipEffect.m_skillLevelModifier = 10;
    chieftainHelmDeer.Prefab.FixItemLayer();

    var (chieftainChest, chieftainChestWrapper) = itemManager["chiefchest"];
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
    chieftainChest.RequiredUpgradeItems.Add("FoxPelt_TW", 1);
    chieftainChestWrapper.Armor.ArmorBase = 6;
    chieftainChestWrapper.Armor.ArmorPerLevel = 3;
    chieftainChestWrapper.Armor.MovementModifier = Normal.MovementModifier.Chest;
    chieftainChestWrapper.Armor.Weight = Normal.Weight.Chest;

    var (chieftainLegs, chieftainLegsWrapper) = itemManager["chieflegs"];
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
    chieftainLegsWrapper.Armor.ArmorBase = 4;
    chieftainLegsWrapper.Armor.ArmorPerLevel = 3;
    chieftainLegsWrapper.Armor.MovementModifier = Normal.MovementModifier.Legs;
    chieftainLegsWrapper.Armor.Weight = Normal.Weight.Legs;

    // Battleswine
    itemManager.Keep([
      "heavybronzehelm",
      "heavybronzechest",
      "heavybronzelegs",
    ]);

    var (battleswineHelm, battleswineHelmWrapper) = itemManager["heavybronzehelm"];
    s_onLocalizationAddedCallbacks.Add(() =>
    {
      battleswineHelm.Name.Alias("$SouthsilArmor_BattleswineHelm_Name");
      battleswineHelm.Description.Alias("$SouthsilArmor_BattleswineHelm_Description");
    });
    battleswineHelm.Crafting.Stations.Clear();
    battleswineHelm.Crafting.Add(CraftingTable.Forge, 2);
    battleswineHelm.RequiredItems.Requirements.Clear();
    battleswineHelm.RequiredItems.Add("Bronze", 3);
    battleswineHelm.RequiredItems.Add("RazorbackLeather_TW", 2);
    battleswineHelm.RequiredItems.Add("BlackBearPelt_TW", 1);
    battleswineHelm.RequiredItems.Add("RazorbackTusk_TW", 2);
    battleswineHelm.RequiredUpgradeItems.Requirements.Clear();
    battleswineHelm.RequiredUpgradeItems.Add("Bronze", 2);
    battleswineHelm.RequiredUpgradeItems.Add("RazorbackLeather_TW", 1);
    battleswineHelm.RequiredUpgradeItems.Add("DeerHide", 2);
    battleswineHelm.RequiredUpgradeItems.Add("RazorbackTusk_TW", 1);
    battleswineHelmWrapper.Armor.ArmorBase = 6;
    battleswineHelmWrapper.Armor.ArmorPerLevel = 3;
    battleswineHelmWrapper.Armor.MovementModifier = VeryHeavy.MovementModifier.Helm;
    battleswineHelmWrapper.Armor.Weight = VeryHeavy.Weight.Helm;
    battleswineHelm.Prefab.FixItemLayer();

    var (battleswineChest, battleswineChestWrapper) = itemManager["heavybronzechest"];
    s_onLocalizationAddedCallbacks.Add(() =>
    {
      battleswineChest.Name.Alias("$SouthsilArmor_BattleswineChest_Name");
      battleswineChest.Description.Alias("$SouthsilArmor_BattleswineChest_Description");
    });
    battleswineChest.Crafting.Stations.Clear();
    battleswineChest.Crafting.Add(CraftingTable.Forge, 2);
    battleswineChest.RequiredItems.Requirements.Clear();
    battleswineChest.RequiredItems.Add("Bronze", 9);
    battleswineChest.RequiredItems.Add("RazorbackLeather_TW", 4);
    battleswineChest.RequiredItems.Add("BlackBearPelt_TW", 3);
    battleswineChest.RequiredItems.Add("TrophyRazorback_TW", 1);
    battleswineChest.RequiredUpgradeItems.Requirements.Clear();
    battleswineChest.RequiredUpgradeItems.Add("Bronze", 5);
    battleswineChest.RequiredUpgradeItems.Add("RazorbackLeather_TW", 1);
    battleswineChest.RequiredUpgradeItems.Add("BlackBearPelt_TW", 1);
    battleswineChestWrapper.Armor.ArmorBase = 18;
    battleswineChestWrapper.Armor.ArmorPerLevel = 4;
    battleswineChestWrapper.Armor.MovementModifier = VeryHeavy.MovementModifier.Chest;
    battleswineChestWrapper.Armor.Weight = VeryHeavy.Weight.Chest;

    var (battleswineLegs, battleswineLegsWrapper) = itemManager["heavybronzelegs"];
    s_onLocalizationAddedCallbacks.Add(() =>
    {
      battleswineLegs.Name.Alias("$SouthsilArmor_BattleswineLegs_Name");
      battleswineLegs.Description.Alias("$SouthsilArmor_BattleswineLegs_Description");
    });
    battleswineLegs.Crafting.Stations.Clear();
    battleswineLegs.Crafting.Add(CraftingTable.Forge, 2);
    battleswineLegs.RequiredItems.Requirements.Clear();
    battleswineLegs.RequiredItems.Add("Bronze", 6);
    battleswineLegs.RequiredItems.Add("RazorbackLeather_TW", 2);
    battleswineLegs.RequiredItems.Add("BlackBearPelt_TW", 2);
    battleswineLegs.RequiredUpgradeItems.Requirements.Clear();
    battleswineLegs.RequiredUpgradeItems.Add("Bronze", 4);
    battleswineLegs.RequiredUpgradeItems.Add("RazorbackLeather_TW", 1);
    battleswineLegs.RequiredUpgradeItems.Add("DeerHide", 4);
    battleswineLegsWrapper.Armor.ArmorBase = 12;
    battleswineLegsWrapper.Armor.ArmorPerLevel = 3;
    battleswineLegsWrapper.Armor.MovementModifier = VeryHeavy.MovementModifier.Legs;
    battleswineLegsWrapper.Armor.Weight = VeryHeavy.Weight.Legs;

    var battleswineSetEffect = ScriptableObject.CreateInstance<SE_Stats>();
    battleswineSetEffect.m_name = "$SouthsilArmor_BattleswineSet_Effect_Name";
    battleswineSetEffect.m_tooltip = "$SouthsilArmor_BattleswineSet_Effect_Tooltip";
    battleswineSetEffect.m_icon = battleswineHelmWrapper.Icon;
    battleswineSetEffect.m_skillLevel = Skills.SkillType.Spears;
    battleswineSetEffect.m_skillLevelModifier = 15;
    battleswineSetEffect.m_skillLevel2 = CustomSkills.Warpikes;
    battleswineSetEffect.m_skillLevelModifier2 = 15;

    battleswineHelmWrapper.Set.Effect = battleswineSetEffect;
    battleswineHelmWrapper.Set.Name = "Battleswine";
    battleswineHelmWrapper.Set.Size = 3;
    battleswineChestWrapper.Set = battleswineHelmWrapper.Set;
    battleswineLegsWrapper.Set = battleswineHelmWrapper.Set;

    // Draugr
    itemManager.Keep([
      "swamphelm",
      "swampchest",
      "swamplegs",
    ]);

    var (draugrHelm, draugrHelmWrapper) = itemManager["swamphelm"];
    s_onLocalizationAddedCallbacks.Add(() =>
    {
      draugrHelm.Name.Alias("$SouthsilArmor_DraugrHelm_Name");
      draugrHelm.Description.Alias("$SouthsilArmor_DraugrHelm_Description");
    });
    draugrHelm.Crafting.Stations.Clear();
    draugrHelm.Crafting.Add(CraftingTable.Forge, 3);
    draugrHelm.RequiredItems.Requirements.Clear();
    draugrHelm.RequiredItems.Add("Iron", 15);
    draugrHelm.RequiredItems.Add("RottenPelt_TW", 2);
    draugrHelm.RequiredItems.Add("WitheredBone", 2);
    draugrHelm.RequiredItems.Add("TrophyCrawler_TW", 1);
    draugrHelm.RequiredUpgradeItems.Requirements.Clear();
    draugrHelm.RequiredUpgradeItems.Add("Iron", 4);
    draugrHelm.RequiredUpgradeItems.Add("RottenPelt_TW", 1);
    draugrHelm.RequiredUpgradeItems.Add("WitheredBone", 1);
    draugrHelmWrapper.Armor.ArmorBase = 9;
    draugrHelmWrapper.Armor.ArmorPerLevel = 3;
    draugrHelmWrapper.Armor.MovementModifier = VeryHeavy.MovementModifier.Helm;
    draugrHelmWrapper.Armor.Weight = VeryHeavy.Weight.Helm;
    draugrHelm.Prefab.FixItemLayer();

    var (draugrChest, draugrChestWrapper) = itemManager["swampchest"];
    s_onLocalizationAddedCallbacks.Add(() =>
    {
      draugrChest.Name.Alias("$SouthsilArmor_DraugrChest_Name");
      draugrChest.Description.Alias("$SouthsilArmor_DraugrChest_Description");
    });
    draugrChest.Crafting.Stations.Clear();
    draugrChest.Crafting.Add(CraftingTable.Forge, 3);
    draugrChest.RequiredItems.Requirements.Clear();
    draugrChest.RequiredItems.Add("Iron", 45);
    draugrChest.RequiredItems.Add("RottenPelt_TW", 4);
    draugrChest.RequiredItems.Add("WitheredBone", 8);
    draugrChest.RequiredUpgradeItems.Requirements.Clear();
    draugrChest.RequiredUpgradeItems.Add("Iron", 11);
    draugrChest.RequiredUpgradeItems.Add("RottenPelt_TW", 2);
    draugrChest.RequiredUpgradeItems.Add("WitheredBone", 4);
    draugrChestWrapper.Armor.ArmorBase = 27;
    draugrChestWrapper.Armor.ArmorPerLevel = 4;
    draugrChestWrapper.Armor.MovementModifier = VeryHeavy.MovementModifier.Chest;
    draugrChestWrapper.Armor.Weight = VeryHeavy.Weight.Chest;

    var (draugrLegs, draugrLegsWrapper) = itemManager["swamplegs"];
    s_onLocalizationAddedCallbacks.Add(() =>
    {
      draugrLegs.Name.Alias("$SouthsilArmor_DraugrLegs_Name");
      draugrLegs.Description.Alias("$SouthsilArmor_DraugrLegs_Description");
    });
    draugrLegs.Crafting.Stations.Clear();
    draugrLegs.Crafting.Add(CraftingTable.Forge, 3);
    draugrLegs.RequiredItems.Requirements.Clear();
    draugrLegs.RequiredItems.Add("Iron", 30);
    draugrLegs.RequiredItems.Add("RottenPelt_TW", 2);
    draugrLegs.RequiredItems.Add("WitheredBone", 4);
    draugrLegs.RequiredItems.Add("TrophySkeleton", 4);
    draugrLegs.RequiredUpgradeItems.Requirements.Clear();
    draugrLegs.RequiredUpgradeItems.Add("Iron", 7);
    draugrLegs.RequiredUpgradeItems.Add("RottenPelt_TW", 1);
    draugrLegs.RequiredUpgradeItems.Add("WitheredBone", 2);
    draugrLegsWrapper.Armor.ArmorBase = 18;
    draugrLegsWrapper.Armor.ArmorPerLevel = 3;
    draugrLegsWrapper.Armor.MovementModifier = VeryHeavy.MovementModifier.Legs;
    draugrLegsWrapper.Armor.Weight = VeryHeavy.Weight.Legs;

    var draugrSetEffect = draugrHelmWrapper.Set.Effect;
    draugrSetEffect.m_name = "$SouthsilArmor_DraugrSet_Effect_Name";
    draugrSetEffect.m_tooltip = "$SouthsilArmor_DraugrSet_Effect_Tooltip";
    draugrSetEffect.m_mods.Clear();
    draugrSetEffect.m_mods.Add(new()
    {
      m_type = CapeAndTorchResistanceChanges.Water,
      m_modifier = HitData.DamageModifier.Immune,
    });

    draugrHelmWrapper.Set.Name = "Draugr";
    draugrHelmWrapper.Set.Size = 3;
    draugrChestWrapper.Set = draugrHelmWrapper.Set;
    draugrLegsWrapper.Set = draugrHelmWrapper.Set;

    // Grizzly
    itemManager.Keep([
      "heavybearhelm",
      "heavybearchest",
      "heavybearlegs",
    ]);

    var (grizzlyHelm, grizzlyHelmWrapper) = itemManager["heavybearhelm"];
    s_onLocalizationAddedCallbacks.Add(() =>
    {
      grizzlyHelm.Name.Alias("$SouthsilArmor_GrizzlyHelm_Name");
      grizzlyHelm.Description.Alias("$SouthsilArmor_GrizzlyHelm_Description");
    });
    grizzlyHelm.Crafting.Stations.Clear();
    grizzlyHelm.Crafting.Add(CraftingTable.Forge, 3);
    grizzlyHelm.RequiredItems.Requirements.Clear();
    grizzlyHelm.RequiredItems.Add("Silver", 15);
    grizzlyHelm.RequiredItems.Add("GrizzlyBearPelt_TW", 1);
    grizzlyHelm.RequiredItems.Add("TrophyHatchling", 2);
    grizzlyHelm.RequiredUpgradeItems.Requirements.Clear();
    grizzlyHelm.RequiredUpgradeItems.Add("Silver", 4);
    grizzlyHelm.RequiredUpgradeItems.Add("WolfPelt", 2);
    grizzlyHelmWrapper.Armor.ArmorBase = 14;
    grizzlyHelmWrapper.Armor.ArmorPerLevel = 4;
    grizzlyHelmWrapper.Armor.MovementModifier = VeryHeavy.MovementModifier.Helm;
    grizzlyHelmWrapper.Armor.Weight = VeryHeavy.Weight.Helm;
    grizzlyHelm.Prefab.FixItemLayer();

    var (grizzlyChest, grizzlyChestWrapper) = itemManager["heavybearchest"];
    s_onLocalizationAddedCallbacks.Add(() =>
    {
      grizzlyChest.Name.Alias("$SouthsilArmor_GrizzlyChest_Name");
      grizzlyChest.Description.Alias("$SouthsilArmor_GrizzlyChest_Description");
    });
    grizzlyChest.Crafting.Stations.Clear();
    grizzlyChest.Crafting.Add(CraftingTable.Forge, 3);
    grizzlyChest.RequiredItems.Requirements.Clear();
    grizzlyChest.RequiredItems.Add("Silver", 45);
    grizzlyChest.RequiredItems.Add("GrizzlyBearPelt_TW", 3);
    grizzlyChest.RequiredItems.Add("WolfPelt", 4);
    grizzlyChest.RequiredItems.Add("ClaymoreIron_TW", 1);
    grizzlyChest.RequiredUpgradeItems.Requirements.Clear();
    grizzlyChest.RequiredUpgradeItems.Add("Silver", 11);
    grizzlyChest.RequiredUpgradeItems.Add("GrizzlyBearPelt_TW", 2);
    grizzlyChest.RequiredUpgradeItems.Add("WolfPelt", 2);
    grizzlyChestWrapper.Armor.ArmorBase = 27;
    grizzlyChestWrapper.Armor.ArmorPerLevel = 4;
    grizzlyChestWrapper.Armor.MovementModifier = VeryHeavy.MovementModifier.Chest;
    grizzlyChestWrapper.Armor.Weight = VeryHeavy.Weight.Chest;
    grizzlyChestWrapper.SharedData.m_heatResistanceModifier = 0f;

    var (grizzlyLegs, grizzlyLegsWrapper) = itemManager["heavybearlegs"];
    s_onLocalizationAddedCallbacks.Add(() =>
    {
      grizzlyLegs.Name.Alias("$SouthsilArmor_GrizzlyLegs_Name");
      grizzlyLegs.Description.Alias("$SouthsilArmor_GrizzlyLegs_Description");
    });
    grizzlyLegs.Crafting.Stations.Clear();
    grizzlyLegs.Crafting.Add(CraftingTable.Forge, 3);
    grizzlyLegs.RequiredItems.Requirements.Clear();
    grizzlyLegs.RequiredItems.Add("Silver", 30);
    grizzlyLegs.RequiredItems.Add("GrizzlyBearPelt_TW", 2);
    grizzlyLegs.RequiredItems.Add("KnifeSilver", 2);
    grizzlyLegs.RequiredItems.Add("TankardAnniversary", 1);
    grizzlyLegs.RequiredUpgradeItems.Requirements.Clear();
    grizzlyLegs.RequiredUpgradeItems.Add("Silver", 7);
    grizzlyLegs.RequiredUpgradeItems.Add("GrizzlyBearPelt_TW", 1);
    grizzlyLegs.RequiredUpgradeItems.Add("WolfPelt", 2);
    grizzlyLegsWrapper.Armor.ArmorBase = 18;
    grizzlyLegsWrapper.Armor.ArmorPerLevel = 3;
    grizzlyLegsWrapper.Armor.MovementModifier = VeryHeavy.MovementModifier.Legs;
    grizzlyLegsWrapper.Armor.Weight = VeryHeavy.Weight.Legs;
    grizzlyLegsWrapper.SharedData.m_heatResistanceModifier = 0f;

    var grizzlySetEffect = grizzlyHelmWrapper.Set.Effect;
    grizzlySetEffect.m_name = "$SouthsilArmor_GrizzlySet_Effect_Name";
    grizzlySetEffect.m_tooltip = "$SouthsilArmor_GrizzlySet_Effect_Tooltip";
    grizzlySetEffect.m_skillLevel = Skills.SkillType.Swords;
    grizzlySetEffect.m_skillLevelModifier = 15;
    grizzlySetEffect.m_skillLevel2 = CustomSkills.TwoHandedSwords;
    grizzlySetEffect.m_skillLevelModifier2 = 15;
    grizzlySetEffect.m_mods.Clear();
    grizzlySetEffect.m_mods.Add(new()
    {
      m_type = CapeAndTorchResistanceChanges.Cold,
      m_modifier = HitData.DamageModifier.VeryResistant,
    });
    grizzlySetEffect.m_staminaRegenMultiplier = 1;

    grizzlyHelmWrapper.Set.Name = "Grizzly";
    grizzlyHelmWrapper.Set.Size = 3;
    grizzlyChestWrapper.Set = grizzlyHelmWrapper.Set;
    grizzlyLegsWrapper.Set = grizzlyHelmWrapper.Set;

    // Feral
    itemManager.Keep([
      "obswolfhelm",
      "obswolfchest",
      "obswolflegs",
    ]);

    var (feralHelm, feralHelmWrapper) = itemManager["obswolfhelm"];
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
    feralHelm.RequiredItems.Add("TrophyProwler_TW", 1);
    feralHelm.RequiredItems.Add("Ruby", 5);
    feralHelm.RequiredUpgradeItems.Requirements.Clear();
    feralHelm.RequiredUpgradeItems.Add("BlackMetal", 2);
    feralHelm.RequiredUpgradeItems.Add("WolfHairBundle", 5);
    feralHelmWrapper.Armor.ArmorBase = 7;
    feralHelmWrapper.Armor.ArmorPerLevel = 2;
    feralHelmWrapper.Armor.MovementModifier = VeryLight.MovementModifier.Helm;
    feralHelmWrapper.Armor.Weight = VeryLight.Weight.Helm;
    feralHelm.Prefab.FixItemLayer();

    var (feralChest, feralChestWrapper) = itemManager["obswolfchest"];
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
    feralChest.RequiredItems.Add("ProwlerFang_TW", 4);
    feralChest.RequiredItems.Add("TrophyUlv", 4);
    feralChest.RequiredUpgradeItems.Requirements.Clear();
    feralChest.RequiredUpgradeItems.Add("BlackMetal", 6);
    feralChest.RequiredUpgradeItems.Add("LoxPelt", 1);
    feralChest.RequiredUpgradeItems.Add("ProwlerFang_TW", 2);
    feralChestWrapper.Armor.ArmorBase = 21;
    feralChestWrapper.Armor.ArmorPerLevel = 3;
    feralChestWrapper.Armor.MovementModifier = VeryLight.MovementModifier.Chest;
    feralChestWrapper.Armor.Weight = VeryLight.Weight.Chest;
    feralChestWrapper.Armor.DamageModifiers.Clear();

    var (feralLegs, feralLegsWrapper) = itemManager["obswolflegs"];
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
    feralLegsWrapper.Armor.ArmorBase = 14;
    feralLegsWrapper.Armor.ArmorPerLevel = 3;
    feralLegsWrapper.Armor.MovementModifier = VeryLight.MovementModifier.Legs;
    feralLegsWrapper.Armor.Weight = VeryLight.Weight.Legs;

    var feralSetEffect = feralHelmWrapper.Set.Effect;
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
    feralSetEffect.m_mods.Clear();

    feralHelmWrapper.Set.Name = "Feral";
    feralHelmWrapper.Set.Size = 3;
    feralChestWrapper.Set = feralHelmWrapper.Set;
    feralLegsWrapper.Set = feralHelmWrapper.Set;

    // Shieldmaiden
    itemManager.Keep([
      "norahhelm",
      "norahhelmalt",
      "norahchest",
      "norahlegs",
    ]);

    var (shieldmaidenHelm, shieldmaidenHelmWrapper) = itemManager["norahhelm"];
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
    shieldmaidenHelmWrapper.Armor.ArmorBase = 10;
    shieldmaidenHelmWrapper.Armor.ArmorPerLevel = 2;
    shieldmaidenHelmWrapper.Armor.MovementModifier = SemiLight.MovementModifier.Helm;
    shieldmaidenHelmWrapper.Armor.Weight = SemiLight.Weight.Helm;

    var (shieldmaidenHelmAlt, shieldmaidenHelmAltWrapper) = itemManager["norahhelmalt"];
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
    shieldmaidenHelmAltWrapper.Armor.ArmorBase = 10;
    shieldmaidenHelmAltWrapper.Armor.ArmorPerLevel = 2;
    shieldmaidenHelmAltWrapper.Armor.MovementModifier = SemiLight.MovementModifier.Helm;
    shieldmaidenHelmAltWrapper.Armor.Weight = SemiLight.Weight.Helm;
    shieldmaidenHelmAlt.Prefab.FixItemLayer();

    var (shieldmaidenChest, shieldmaidenChestWrapper) = itemManager["norahchest"];
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
    shieldmaidenChest.RequiredUpgradeItems.Add("Iron", 8);
    shieldmaidenChest.RequiredUpgradeItems.Add("LinenThread", 15);
    shieldmaidenChest.RequiredUpgradeItems.Add("LoxPelt", 1);
    shieldmaidenChestWrapper.Armor.ArmorBase = 30;
    shieldmaidenChestWrapper.Armor.ArmorPerLevel = 3;
    shieldmaidenChestWrapper.Armor.MovementModifier = SemiLight.MovementModifier.Chest;
    shieldmaidenChestWrapper.Armor.Weight = SemiLight.Weight.Chest;

    var (shieldmaidenLegs, shieldmaidenLegsWrapper) = itemManager["norahlegs"];
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
    shieldmaidenLegs.RequiredUpgradeItems.Add("Iron", 4);
    shieldmaidenLegs.RequiredUpgradeItems.Add("LinenThread", 10);
    shieldmaidenLegs.RequiredUpgradeItems.Add("LoxPelt", 2);
    shieldmaidenLegsWrapper.Armor.ArmorBase = 20;
    shieldmaidenLegsWrapper.Armor.ArmorPerLevel = 2;
    shieldmaidenLegsWrapper.Armor.MovementModifier = SemiLight.MovementModifier.Legs;
    shieldmaidenLegsWrapper.Armor.Weight = SemiLight.Weight.Legs;

    var shieldMaidenSetEffect = shieldmaidenHelmWrapper.Set.Effect;
    shieldMaidenSetEffect.m_name = "$SouthsilArmor_ShieldmaidenSet_Effect_Name";
    shieldMaidenSetEffect.m_tooltip = "$SouthsilArmor_ShieldmaidenSet_Effect_Tooltip";
    shieldMaidenSetEffect.m_skillLevel = Skills.SkillType.Clubs;
    shieldMaidenSetEffect.m_skillLevelModifier = 15;
    shieldMaidenSetEffect.m_skillLevel2 = Skills.SkillType.Blocking;
    shieldMaidenSetEffect.m_skillLevelModifier2 = 15;
    shieldMaidenSetEffect.m_mods.Clear();

    shieldmaidenHelmWrapper.Set.Name = "Shieldmaiden";
    shieldmaidenHelmWrapper.Set.Size = 3;
    shieldmaidenHelmAltWrapper.Set = shieldmaidenHelmWrapper.Set;
    shieldmaidenChestWrapper.Set = shieldmaidenHelmWrapper.Set;
    shieldmaidenLegsWrapper.Set = shieldmaidenHelmWrapper.Set;

    // Berserkir
    itemManager.Keep([
      "bearhelm2",
      "bearchest2",
      "bearlegs2",
    ]);

    var (berserkirHelm, berserkirHelmWrapper) = itemManager["bearhelm2"];
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
    berserkirHelmWrapper.Armor.ArmorBase = 16;
    berserkirHelmWrapper.Armor.ArmorPerLevel = 4;
    berserkirHelmWrapper.Armor.MovementModifier = VeryHeavy.MovementModifier.Helm;
    berserkirHelmWrapper.Armor.Weight = VeryHeavy.Weight.Helm;

    var (berserkirChest, berserkirChestWrapper) = itemManager["bearchest2"];
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
    berserkirChestWrapper.Armor.ArmorBase = 48;
    berserkirChestWrapper.Armor.ArmorPerLevel = 5;
    berserkirChestWrapper.Armor.MovementModifier = VeryHeavy.MovementModifier.Chest;
    berserkirChestWrapper.Armor.Weight = VeryHeavy.Weight.Chest;

    var (berserkirLegs, berserkirLegsWrapper) = itemManager["bearlegs2"];
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
    berserkirLegsWrapper.Armor.ArmorBase = 32;
    berserkirLegsWrapper.Armor.ArmorPerLevel = 5;
    berserkirLegsWrapper.Armor.MovementModifier = VeryHeavy.MovementModifier.Legs;
    berserkirLegsWrapper.Armor.Weight = VeryHeavy.Weight.Legs;
    berserkirLegsWrapper.Armor.DamageModifiers.Clear();

    var berserkirSetEffect = berserkirHelmWrapper.Set.Effect;
    berserkirSetEffect.m_name = "$SouthsilArmor_BerserkirSet_Effect_Name";
    berserkirSetEffect.m_tooltip = "$SouthsilArmor_BerserkirSet_Effect_Tooltip";
    berserkirSetEffect.m_skillLevel = Skills.SkillType.Polearms;
    berserkirSetEffect.m_skillLevelModifier = 15;
    berserkirSetEffect.m_skillLevel2 = CustomSkills.TwoHandedAxes;
    berserkirSetEffect.m_skillLevelModifier2 = 15;
    berserkirSetEffect.m_healthRegenMultiplier = 1;
    berserkirSetEffect.m_staminaRegenMultiplier = 1;
    berserkirSetEffect.m_mods.Clear();

    berserkirHelmWrapper.Set.Name = "Berserkir";
    berserkirHelmWrapper.Set.Size = 3;
    berserkirChestWrapper.Set = berserkirHelmWrapper.Set;
    berserkirLegsWrapper.Set = berserkirHelmWrapper.Set;

    // Gjall-hunter
    itemManager.Keep([
      "heavycarhelm",
      "heavycarchest",
      "heavycarlegs",
    ]);

    var (gjallhunterHelm, gjallhunterHelmWrapper) = itemManager["heavycarhelm"];
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
    gjallhunterHelmWrapper.Armor.ArmorBase = 12;
    gjallhunterHelmWrapper.Armor.ArmorPerLevel = 3;
    gjallhunterHelmWrapper.Armor.MovementModifier = SemiLight.MovementModifier.Helm;
    gjallhunterHelmWrapper.Armor.Weight = SemiLight.Weight.Helm;
    gjallhunterHelmWrapper.Armor.EquipEffect = null;
    gjallhunterHelm.Prefab.FixItemLayer();

    var (gjallhunterChest, gjallhunterChestWrapper) = itemManager["heavycarchest"];
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
    gjallhunterChestWrapper.Armor.ArmorBase = 36;
    gjallhunterChestWrapper.Armor.ArmorPerLevel = 4;
    gjallhunterChestWrapper.Armor.MovementModifier = SemiLight.MovementModifier.Chest;
    gjallhunterChestWrapper.Armor.Weight = SemiLight.Weight.Chest;

    var (gjallhunterLegs, gjallhunterLegsWrapper) = itemManager["heavycarlegs"];
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
    gjallhunterLegsWrapper.Armor.ArmorBase = 24;
    gjallhunterLegsWrapper.Armor.ArmorPerLevel = 3;
    gjallhunterLegsWrapper.Armor.MovementModifier = SemiLight.MovementModifier.Legs;
    gjallhunterLegsWrapper.Armor.Weight = SemiLight.Weight.Legs;

    var gjallhunterSetEffect = gjallhunterHelmWrapper.Set.Effect;
    gjallhunterSetEffect.m_name = "$SouthsilArmor_GjallhunterSet_Effect_Name";
    gjallhunterSetEffect.m_tooltip = "$SouthsilArmor_GjallhunterSet_Effect_Tooltip";
    gjallhunterSetEffect.m_skillLevel = Skills.SkillType.Bows;
    gjallhunterSetEffect.m_skillLevelModifier = 15;
    gjallhunterSetEffect.m_skillLevel2 = Skills.SkillType.Crossbows;
    gjallhunterSetEffect.m_skillLevelModifier2 = 15;
    gjallhunterSetEffect.m_staminaRegenMultiplier = 1;
    gjallhunterSetEffect.m_mods.Clear();

    gjallhunterHelmWrapper.Set.Name = "Gjallhunter";
    gjallhunterHelmWrapper.Set.Size = 3;
    gjallhunterChestWrapper.Set = gjallhunterHelmWrapper.Set;
    gjallhunterLegsWrapper.Set = gjallhunterHelmWrapper.Set;

    // Rune-knight
    itemManager.Keep([
      "runeknighthelm",
      "runeknightchest",
      "runeknightlegs",
    ]);

    var (runeknightHelm, runeknightHelmWrapper) = itemManager["runeknighthelm"];
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
    runeknightHelmWrapper.Armor.ArmorBase = 18;
    runeknightHelmWrapper.Armor.ArmorPerLevel = 4;
    runeknightHelmWrapper.Armor.MovementModifier = Heavy.MovementModifier.Helm;
    runeknightHelmWrapper.Armor.Weight = Heavy.Weight.Helm;
    runeknightHelm.Prefab.FixItemLayer();

    var (runeknightChest, runeknightChestWrapper) = itemManager["runeknightchest"];
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
    runeknightChestWrapper.Armor.ArmorBase = 54;
    runeknightChestWrapper.Armor.ArmorPerLevel = 4;
    runeknightChestWrapper.Armor.MovementModifier = Heavy.MovementModifier.Chest;
    runeknightChestWrapper.Armor.Weight = Heavy.Weight.Chest;

    var (runeknightLegs, runeknightLegsWrapper) = itemManager["runeknightlegs"];
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
    runeknightLegsWrapper.Armor.ArmorBase = 36;
    runeknightLegsWrapper.Armor.ArmorPerLevel = 4;
    runeknightLegsWrapper.Armor.MovementModifier = Heavy.MovementModifier.Legs;
    runeknightLegsWrapper.Armor.Weight = Heavy.Weight.Legs;

    var runeknightSetEffect = runeknightHelmWrapper.Set.Effect;
    runeknightSetEffect.m_name = "$SouthsilArmor_RuneknightSet_Effect_Name";
    runeknightSetEffect.m_tooltip = "$SouthsilArmor_RuneknightSet_Effect_Tooltip";
    runeknightSetEffect.m_skillLevel = Skills.SkillType.BloodMagic;
    runeknightSetEffect.m_skillLevelModifier = 15;
    runeknightSetEffect.m_skillLevel2 = Skills.SkillType.None;
    runeknightSetEffect.m_skillLevelModifier2 = 0;
    runeknightSetEffect.m_eitrRegenMultiplier = 1.5f;
    runeknightSetEffect.m_mods.Clear();

    runeknightHelmWrapper.Set.Name = "Runeknight";
    runeknightHelmWrapper.Set.Size = 3;
    runeknightChestWrapper.Set = runeknightHelmWrapper.Set;
    runeknightLegsWrapper.Set = runeknightHelmWrapper.Set;

    // Druid
    itemManager.Keep([
      "druidhelm",
      "druidchest",
      "druidlegs",
    ]);

    var (druidHelm, druidHelmWrapper) = itemManager["druidhelm"];
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
    druidHelmWrapper.Armor.ArmorBase = 20;
    druidHelmWrapper.Armor.ArmorPerLevel = 4;
    druidHelmWrapper.Armor.MovementModifier = VeryHeavy.MovementModifier.Helm;
    druidHelmWrapper.Armor.Weight = VeryHeavy.Weight.Helm;
    druidHelm.Prefab.FixItemLayer();

    var (druidChest, druidChestWrapper) = itemManager["druidchest"];
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
    druidChestWrapper.Armor.ArmorBase = 60;
    druidChestWrapper.Armor.ArmorPerLevel = 5;
    druidChestWrapper.Armor.MovementModifier = VeryHeavy.MovementModifier.Chest;
    druidChestWrapper.Armor.Weight = VeryHeavy.Weight.Chest;

    var (druidLegs, druidLegsWrapper) = itemManager["druidlegs"];
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
    druidLegsWrapper.Armor.ArmorBase = 40;
    druidLegsWrapper.Armor.ArmorPerLevel = 5;
    druidLegsWrapper.Armor.MovementModifier = VeryHeavy.MovementModifier.Legs;
    druidLegsWrapper.Armor.Weight = VeryHeavy.Weight.Legs;

    var druidSetEffect = druidHelmWrapper.Set.Effect;
    druidSetEffect.m_name = "$SouthsilArmor_DruidSet_Effect_Name";
    druidSetEffect.m_tooltip = "$SouthsilArmor_DruidSet_Effect_Tooltip";
    druidSetEffect.m_skillLevel = Skills.SkillType.ElementalMagic;
    druidSetEffect.m_skillLevelModifier = 15;
    druidSetEffect.m_skillLevel2 = CustomSkills.TwoHandedHammers;
    druidSetEffect.m_skillLevelModifier2 = 15;
    druidSetEffect.m_eitrRegenMultiplier = 1.5f;
    druidSetEffect.m_staminaRegenMultiplier = 1;
    druidSetEffect.m_addMaxCarryWeight = 0;
    druidSetEffect.m_mods.Clear();

    druidHelmWrapper.Set.Name = "Druid";
    druidHelmWrapper.Set.Size = 3;
    druidChestWrapper.Set = druidHelmWrapper.Set;
    druidLegsWrapper.Set = druidHelmWrapper.Set;
  }
}
