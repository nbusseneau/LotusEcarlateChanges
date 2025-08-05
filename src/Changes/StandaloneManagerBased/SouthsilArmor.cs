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

    var draugrSetEffect = ScriptableObject.CreateInstance<SE_Stats>();
    draugrSetEffect.m_name = "$SouthsilArmor_DraugrSet_Effect_Name";
    draugrSetEffect.m_tooltip = "$SouthsilArmor_DraugrSet_Effect_Tooltip";
    draugrSetEffect.m_icon = draugrHelmWrapper.Icon;
    draugrSetEffect.m_mods.Add(new()
    {
      m_type = CapeAndTorchResistanceChanges.Water,
      m_modifier = HitData.DamageModifier.Immune,
    });

    draugrHelmWrapper.Set.Effect = draugrSetEffect;
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
    grizzlyHelm.RequiredItems.Add("TrophyHatchling", 1);
    grizzlyHelm.RequiredItems.Add("TrophyGrizzlyBear_TW", 1);
    grizzlyHelm.RequiredUpgradeItems.Requirements.Clear();
    grizzlyHelm.RequiredUpgradeItems.Add("Silver", 4);
    grizzlyHelm.RequiredUpgradeItems.Add("WolfPelt", 2);
    grizzlyHelmWrapper.Armor.ArmorBase = 12;
    grizzlyHelmWrapper.Armor.ArmorPerLevel = 3;
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
    grizzlyChestWrapper.Armor.ArmorBase = 36;
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
    grizzlyLegsWrapper.Armor.ArmorBase = 24;
    grizzlyLegsWrapper.Armor.ArmorPerLevel = 3;
    grizzlyLegsWrapper.Armor.MovementModifier = VeryHeavy.MovementModifier.Legs;
    grizzlyLegsWrapper.Armor.Weight = VeryHeavy.Weight.Legs;
    grizzlyLegsWrapper.SharedData.m_heatResistanceModifier = 0f;

    var grizzlySetEffect = ScriptableObject.CreateInstance<SE_Stats>();
    grizzlySetEffect.m_name = "$SouthsilArmor_GrizzlySet_Effect_Name";
    grizzlySetEffect.m_tooltip = "$SouthsilArmor_GrizzlySet_Effect_Tooltip";
    grizzlySetEffect.m_icon = grizzlyHelmWrapper.Icon;
    grizzlySetEffect.m_skillLevel = Skills.SkillType.Swords;
    grizzlySetEffect.m_skillLevelModifier = 15;
    grizzlySetEffect.m_skillLevel2 = CustomSkills.TwoHandedSwords;
    grizzlySetEffect.m_skillLevelModifier2 = 15;
    grizzlySetEffect.m_mods.Add(new()
    {
      m_type = CapeAndTorchResistanceChanges.Cold,
      m_modifier = HitData.DamageModifier.VeryResistant,
    });

    grizzlyHelmWrapper.Set.Effect = grizzlySetEffect;
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

    var feralSetEffect = ScriptableObject.CreateInstance<SE_Stats>();
    feralSetEffect.m_name = "$SouthsilArmor_FeralSet_Effect_Name";
    feralSetEffect.m_tooltip = "$SouthsilArmor_FeralSet_Effect_Tooltip";
    feralSetEffect.m_icon = feralHelmWrapper.Icon;
    feralSetEffect.m_skillLevel = Skills.SkillType.Sneak;
    feralSetEffect.m_skillLevelModifier = 15;
    feralSetEffect.m_skillLevel2 = Skills.SkillType.Knives;
    feralSetEffect.m_skillLevelModifier2 = 15;

    feralHelmWrapper.Set.Effect = feralSetEffect;
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

    var shieldMaidenSetEffect = ScriptableObject.CreateInstance<SE_Stats>();
    shieldMaidenSetEffect.m_name = "$SouthsilArmor_ShieldmaidenSet_Effect_Name";
    shieldMaidenSetEffect.m_tooltip = "$SouthsilArmor_ShieldmaidenSet_Effect_Tooltip";
    shieldMaidenSetEffect.m_icon = shieldmaidenChestWrapper.Icon;
    shieldMaidenSetEffect.m_skillLevel = Skills.SkillType.Clubs;
    shieldMaidenSetEffect.m_skillLevelModifier = 15;
    shieldMaidenSetEffect.m_skillLevel2 = Skills.SkillType.Blocking;
    shieldMaidenSetEffect.m_skillLevelModifier2 = 15;

    shieldmaidenHelmWrapper.Set.Effect = shieldMaidenSetEffect;
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
    berserkirHelm.RequiredItems.Add("BlackMetal", 15);
    berserkirHelm.RequiredItems.Add("LinenThread", 10);
    berserkirHelm.RequiredUpgradeItems.Requirements.Clear();
    berserkirHelm.RequiredUpgradeItems.Add("BlackMetal", 7);
    berserkirHelm.RequiredUpgradeItems.Add("LinenThread", 5);
    berserkirHelmWrapper.Armor.ArmorBase = 15;
    berserkirHelmWrapper.Armor.ArmorPerLevel = 3;
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
    berserkirChest.RequiredItems.Add("BlackMetal", 45);
    berserkirChest.RequiredItems.Add("LinenThread", 23);
    berserkirChest.RequiredItems.Add("Chain", 10);
    berserkirChest.RequiredUpgradeItems.Requirements.Clear();
    berserkirChest.RequiredUpgradeItems.Add("BlackMetal", 20);
    berserkirChest.RequiredUpgradeItems.Add("LinenThread", 15);
    berserkirChestWrapper.Armor.ArmorBase = 45;
    berserkirChestWrapper.Armor.ArmorPerLevel = 4;
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
    berserkirLegs.RequiredItems.Add("BlackMetal", 30);
    berserkirLegs.RequiredItems.Add("LinenThread", 20);
    berserkirLegs.RequiredUpgradeItems.Requirements.Clear();
    berserkirLegs.RequiredUpgradeItems.Add("BlackMetal", 15);
    berserkirLegs.RequiredUpgradeItems.Add("LinenThread", 10);
    berserkirLegsWrapper.Armor.ArmorBase = 30;
    berserkirLegsWrapper.Armor.ArmorPerLevel = 4;
    berserkirLegsWrapper.Armor.MovementModifier = VeryHeavy.MovementModifier.Legs;
    berserkirLegsWrapper.Armor.Weight = VeryHeavy.Weight.Legs;
    berserkirLegsWrapper.Armor.DamageModifiers.Clear();

    var berserkirSetEffect = ScriptableObject.CreateInstance<SE_Stats>();
    berserkirSetEffect.m_name = "$SouthsilArmor_BerserkirSet_Effect_Name";
    berserkirSetEffect.m_tooltip = "$SouthsilArmor_BerserkirSet_Effect_Tooltip";
    berserkirSetEffect.m_icon = berserkirHelmWrapper.Icon;
    berserkirSetEffect.m_skillLevel = Skills.SkillType.Polearms;
    berserkirSetEffect.m_skillLevelModifier = 15;
    berserkirSetEffect.m_skillLevel2 = CustomSkills.TwoHandedAxes;
    berserkirSetEffect.m_skillLevelModifier2 = 15;

    berserkirHelmWrapper.Set.Effect = berserkirSetEffect;
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

    var gjallhunterSetEffect = ScriptableObject.CreateInstance<SE_Stats>();
    gjallhunterSetEffect.m_name = "$SouthsilArmor_GjallhunterSet_Effect_Name";
    gjallhunterSetEffect.m_tooltip = "$SouthsilArmor_GjallhunterSet_Effect_Tooltip";
    gjallhunterSetEffect.m_icon = gjallhunterHelmWrapper.Icon;
    gjallhunterSetEffect.m_skillLevel = Skills.SkillType.Bows;
    gjallhunterSetEffect.m_skillLevelModifier = 15;
    gjallhunterSetEffect.m_skillLevel2 = Skills.SkillType.Crossbows;
    gjallhunterSetEffect.m_skillLevelModifier2 = 15;

    gjallhunterHelmWrapper.Set.Effect = gjallhunterSetEffect;
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
    runeknightHelmWrapper.Armor.ArmorBase = 17;
    runeknightHelmWrapper.Armor.ArmorPerLevel = 3;
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
    runeknightChestWrapper.Armor.ArmorBase = 51;
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
    runeknightLegsWrapper.Armor.ArmorBase = 34;
    runeknightLegsWrapper.Armor.ArmorPerLevel = 4;
    runeknightLegsWrapper.Armor.MovementModifier = Heavy.MovementModifier.Legs;
    runeknightLegsWrapper.Armor.Weight = Heavy.Weight.Legs;

    var runeknightSetEffect = ScriptableObject.CreateInstance<SE_Stats>();
    runeknightSetEffect.m_name = "$SouthsilArmor_RuneknightSet_Effect_Name";
    runeknightSetEffect.m_tooltip = "$SouthsilArmor_RuneknightSet_Effect_Tooltip";
    runeknightSetEffect.m_icon = runeknightHelmWrapper.Icon;
    runeknightSetEffect.m_skillLevel = Skills.SkillType.BloodMagic;
    runeknightSetEffect.m_skillLevelModifier = 15;
    runeknightSetEffect.m_skillLevel2 = CustomSkills.TwoHandedSwords;
    runeknightSetEffect.m_skillLevelModifier2 = 15;
    runeknightSetEffect.m_eitrRegenMultiplier = 1.5f;

    runeknightHelmWrapper.Set.Effect = runeknightSetEffect;
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
    druidHelmWrapper.Armor.ArmorBase = 18;
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
    druidChestWrapper.Armor.ArmorBase = 54;
    druidChestWrapper.Armor.ArmorPerLevel = 4;
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
    druidLegsWrapper.Armor.ArmorBase = 36;
    druidLegsWrapper.Armor.ArmorPerLevel = 4;
    druidLegsWrapper.Armor.MovementModifier = VeryHeavy.MovementModifier.Legs;
    druidLegsWrapper.Armor.Weight = VeryHeavy.Weight.Legs;

    var druidSetEffect = ScriptableObject.CreateInstance<SE_Stats>();
    druidSetEffect.m_name = "$SouthsilArmor_DruidSet_Effect_Name";
    druidSetEffect.m_tooltip = "$SouthsilArmor_DruidSet_Effect_Tooltip";
    druidSetEffect.m_icon = druidHelmWrapper.Icon;
    druidSetEffect.m_skillLevel = Skills.SkillType.ElementalMagic;
    druidSetEffect.m_skillLevelModifier = 15;
    druidSetEffect.m_skillLevel2 = CustomSkills.TwoHandedHammers;
    druidSetEffect.m_skillLevelModifier2 = 15;
    druidSetEffect.m_eitrRegenMultiplier = 1.5f;

    druidHelmWrapper.Set.Effect = druidSetEffect;
    druidHelmWrapper.Set.Name = "Druid";
    druidHelmWrapper.Set.Size = 3;
    druidChestWrapper.Set = druidHelmWrapper.Set;
    druidLegsWrapper.Set = druidHelmWrapper.Set;

    // Jörmungandr
    itemManager.Keep([
      "ss_frodehelm",
      "ss_frodechest",
      "ss_frodelegs",
    ]);

    var (jormungandrHelm, jormungandrHelmWrapper) = itemManager["ss_frodehelm"];
    s_onLocalizationAddedCallbacks.Add(() =>
    {
      jormungandrHelm.Name.Alias("$SouthsilArmor_JormungandrHelm_Name");
      jormungandrHelm.Description.Alias("$SouthsilArmor_JormungandrHelm_Description");
    });
    jormungandrHelm.Crafting.Stations.Clear();
    jormungandrHelm.Crafting.Add(CraftingTable.BlackForge, 1);
    jormungandrHelm.RequiredItems.Requirements.Clear();
    jormungandrHelm.RequiredItems.Add("Flametal", 15);
    jormungandrHelm.RequiredItems.Add("BlackMetal", 5);
    jormungandrHelm.RequiredItems.Add("AskHide", 2);
    jormungandrHelm.RequiredItems.Add("SerpentScale", 5);
    jormungandrHelm.RequiredItems.Add("SerpentTrophy", 1);
    jormungandrHelm.RequiredUpgradeItems.Requirements.Clear();
    jormungandrHelm.RequiredUpgradeItems.Add("Flametal", 7);
    jormungandrHelm.RequiredUpgradeItems.Add("BlackMetal", 3);
    jormungandrHelm.RequiredUpgradeItems.Add("AskHide", 1);
    jormungandrHelm.RequiredUpgradeItems.Add("SerpentScale", 2);
    jormungandrHelmWrapper.Armor.ArmorBase = 21;
    jormungandrHelmWrapper.Armor.ArmorPerLevel = 4;
    jormungandrHelmWrapper.Armor.MovementModifier = Heavy.MovementModifier.Helm;
    jormungandrHelmWrapper.Armor.Weight = Heavy.Weight.Helm;
    jormungandrHelmWrapper.SharedData.m_heatResistanceModifier = 0.07f;
    jormungandrHelm.Prefab.FixItemLayer();

    var (jormungandrChest, jormungandrChestWrapper) = itemManager["ss_frodechest"];
    s_onLocalizationAddedCallbacks.Add(() =>
    {
      jormungandrChest.Name.Alias("$SouthsilArmor_JormungandrChest_Name");
      jormungandrChest.Description.Alias("$SouthsilArmor_JormungandrChest_Description");
    });
    jormungandrChest.Crafting.Stations.Clear();
    jormungandrChest.Crafting.Add(CraftingTable.BlackForge, 1);
    jormungandrChest.RequiredItems.Requirements.Clear();
    jormungandrChest.RequiredItems.Add("Flametal", 45);
    jormungandrChest.RequiredItems.Add("BlackMetal", 15);
    jormungandrChest.RequiredItems.Add("AskHide", 6);
    jormungandrChest.RequiredItems.Add("SerpentScale", 10);
    jormungandrChest.RequiredUpgradeItems.Requirements.Clear();
    jormungandrChest.RequiredUpgradeItems.Add("Flametal", 22);
    jormungandrChest.RequiredUpgradeItems.Add("BlackMetal", 7);
    jormungandrChest.RequiredUpgradeItems.Add("AskHide", 3);
    jormungandrChest.RequiredUpgradeItems.Add("SerpentScale", 5);
    jormungandrChestWrapper.Armor.ArmorBase = 63;
    jormungandrChestWrapper.Armor.ArmorPerLevel = 4;
    jormungandrChestWrapper.Armor.MovementModifier = Heavy.MovementModifier.Chest;
    jormungandrChestWrapper.Armor.Weight = Heavy.Weight.Chest;
    jormungandrChestWrapper.Armor.DamageModifiers.Clear();
    jormungandrChestWrapper.SharedData.m_heatResistanceModifier = 0.33f;

    var (jormungandrLegs, jormungandrLegsWrapper) = itemManager["ss_frodelegs"];
    s_onLocalizationAddedCallbacks.Add(() =>
    {
      jormungandrLegs.Name.Alias("$SouthsilArmor_JormungandrLegs_Name");
      jormungandrLegs.Description.Alias("$SouthsilArmor_JormungandrLegs_Description");
    });
    jormungandrLegs.Crafting.Stations.Clear();
    jormungandrLegs.Crafting.Add(CraftingTable.BlackForge, 1);
    jormungandrLegs.RequiredItems.Requirements.Clear();
    jormungandrLegs.RequiredItems.Add("Flametal", 30);
    jormungandrLegs.RequiredItems.Add("BlackMetal", 10);
    jormungandrLegs.RequiredItems.Add("AskHide", 4);
    jormungandrLegs.RequiredItems.Add("SerpentScale", 5);
    jormungandrLegs.RequiredUpgradeItems.Requirements.Clear();
    jormungandrLegs.RequiredUpgradeItems.Add("Flametal", 15);
    jormungandrLegs.RequiredUpgradeItems.Add("BlackMetal", 5);
    jormungandrLegs.RequiredUpgradeItems.Add("AskHide", 2);
    jormungandrLegs.RequiredUpgradeItems.Add("SerpentScale", 2);
    jormungandrLegsWrapper.Armor.ArmorBase = 42;
    jormungandrLegsWrapper.Armor.ArmorPerLevel = 4;
    jormungandrLegsWrapper.Armor.MovementModifier = Heavy.MovementModifier.Legs;
    jormungandrLegsWrapper.Armor.Weight = Heavy.Weight.Legs;
    jormungandrLegsWrapper.SharedData.m_heatResistanceModifier = 0.15f;

    var jormungandrSetEffect = ScriptableObject.CreateInstance<SE_Stats>();
    jormungandrSetEffect.m_name = "$SouthsilArmor_JormungandrSet_Effect_Name";
    jormungandrSetEffect.m_tooltip = "$SouthsilArmor_JormungandrSet_Effect_Tooltip";
    jormungandrSetEffect.m_icon = jormungandrHelmWrapper.Icon;
    jormungandrSetEffect.m_skillLevel = Skills.SkillType.Spears;
    jormungandrSetEffect.m_skillLevelModifier = 15;
    jormungandrSetEffect.m_skillLevel2 = Skills.SkillType.Polearms;
    jormungandrSetEffect.m_skillLevelModifier2 = 15;

    jormungandrHelmWrapper.Set.Effect = jormungandrSetEffect;
    jormungandrHelmWrapper.Set.Name = "Jormungandr";
    jormungandrHelmWrapper.Set.Size = 3;
    jormungandrChestWrapper.Set = jormungandrHelmWrapper.Set;
    jormungandrLegsWrapper.Set = jormungandrHelmWrapper.Set;

    // Morgen-slayer
    itemManager.Keep([
      "ss_storrhelm",
      "ss_storrchest",
      "ss_storrlegs",
    ]);

    var (morgenslayerHelm, morgenslayerHelmWrapper) = itemManager["ss_storrhelm"];
    s_onLocalizationAddedCallbacks.Add(() =>
    {
      morgenslayerHelm.Name.Alias("$SouthsilArmor_MorgenslayerHelm_Name");
      morgenslayerHelm.Description.Alias("$SouthsilArmor_MorgenslayerHelm_Description");
    });
    morgenslayerHelm.Crafting.Stations.Clear();
    morgenslayerHelm.Crafting.Add(CraftingTable.BlackForge, 1);
    morgenslayerHelm.RequiredItems.Requirements.Clear();
    morgenslayerHelm.RequiredItems.Add("Flametal", 15);
    morgenslayerHelm.RequiredItems.Add("AskHide", 5);
    morgenslayerHelm.RequiredItems.Add("CharredBone", 10);
    morgenslayerHelm.RequiredItems.Add("MorgenSinew", 1);
    morgenslayerHelm.RequiredItems.Add("MorgenTrophy", 1);
    morgenslayerHelm.RequiredUpgradeItems.Requirements.Clear();
    morgenslayerHelm.RequiredUpgradeItems.Add("Flametal", 7);
    morgenslayerHelm.RequiredUpgradeItems.Add("AskHide", 2);
    morgenslayerHelm.RequiredUpgradeItems.Add("CharredBone", 5);
    morgenslayerHelmWrapper.Armor.ArmorBase = 22;
    morgenslayerHelmWrapper.Armor.ArmorPerLevel = 4;
    morgenslayerHelmWrapper.Armor.MovementModifier = VeryHeavy.MovementModifier.Helm;
    morgenslayerHelmWrapper.Armor.Weight = VeryHeavy.Weight.Helm;
    morgenslayerHelmWrapper.SharedData.m_heatResistanceModifier = 0.10f;
    morgenslayerHelm.Prefab.FixItemLayer();

    var (morgenslayerChest, morgenslayerChestWrapper) = itemManager["ss_storrchest"];
    s_onLocalizationAddedCallbacks.Add(() =>
    {
      morgenslayerChest.Name.Alias("$SouthsilArmor_MorgenslayerChest_Name");
      morgenslayerChest.Description.Alias("$SouthsilArmor_MorgenslayerChest_Description");
    });
    morgenslayerChest.Crafting.Stations.Clear();
    morgenslayerChest.Crafting.Add(CraftingTable.BlackForge, 1);
    morgenslayerChest.RequiredItems.Requirements.Clear();
    morgenslayerChest.RequiredItems.Add("Flametal", 45);
    morgenslayerChest.RequiredItems.Add("AskHide", 15);
    morgenslayerChest.RequiredItems.Add("CharredBone", 30);
    morgenslayerChest.RequiredItems.Add("MorgenSinew", 3);
    morgenslayerChest.RequiredUpgradeItems.Requirements.Clear();
    morgenslayerChest.RequiredUpgradeItems.Add("Flametal", 22);
    morgenslayerChest.RequiredUpgradeItems.Add("AskHide", 7);
    morgenslayerChest.RequiredUpgradeItems.Add("CharredBone", 15);
    morgenslayerChest.RequiredUpgradeItems.Add("MorgenSinew", 2);
    morgenslayerChestWrapper.Armor.ArmorBase = 66;
    morgenslayerChestWrapper.Armor.ArmorPerLevel = 5;
    morgenslayerChestWrapper.Armor.MovementModifier = VeryHeavy.MovementModifier.Chest;
    morgenslayerChestWrapper.Armor.Weight = VeryHeavy.Weight.Chest;
    morgenslayerChestWrapper.SharedData.m_heatResistanceModifier = 0.40f;

    var (morgenslayerLegs, morgenslayerLegsWrapper) = itemManager["ss_storrlegs"];
    s_onLocalizationAddedCallbacks.Add(() =>
    {
      morgenslayerLegs.Name.Alias("$SouthsilArmor_MorgenslayerLegs_Name");
      morgenslayerLegs.Description.Alias("$SouthsilArmor_MorgenslayerLegs_Description");
    });
    morgenslayerLegs.Crafting.Stations.Clear();
    morgenslayerLegs.Crafting.Add(CraftingTable.BlackForge, 1);
    morgenslayerLegs.RequiredItems.Requirements.Clear();
    morgenslayerLegs.RequiredItems.Add("Flametal", 30);
    morgenslayerLegs.RequiredItems.Add("AskHide", 10);
    morgenslayerLegs.RequiredItems.Add("CharredBone", 20);
    morgenslayerLegs.RequiredItems.Add("MorgenSinew", 2);
    morgenslayerLegs.RequiredUpgradeItems.Requirements.Clear();
    morgenslayerLegs.RequiredUpgradeItems.Add("Flametal", 15);
    morgenslayerLegs.RequiredUpgradeItems.Add("AskHide", 5);
    morgenslayerLegs.RequiredUpgradeItems.Add("CharredBone", 10);
    morgenslayerLegs.RequiredUpgradeItems.Add("MorgenSinew", 1);
    morgenslayerLegsWrapper.Armor.ArmorBase = 44;
    morgenslayerLegsWrapper.Armor.ArmorPerLevel = 5;
    morgenslayerLegsWrapper.Armor.MovementModifier = VeryHeavy.MovementModifier.Legs;
    morgenslayerLegsWrapper.Armor.Weight = VeryHeavy.Weight.Legs;
    morgenslayerLegsWrapper.SharedData.m_heatResistanceModifier = 0.20f;

    var morgenslayerSetEffect = ScriptableObject.CreateInstance<SE_Stats>();
    morgenslayerSetEffect.m_name = "$SouthsilArmor_MorgenslayerSet_Effect_Name";
    morgenslayerSetEffect.m_tooltip = "$SouthsilArmor_MorgenslayerSet_Effect_Tooltip";
    morgenslayerSetEffect.m_icon = morgenslayerHelmWrapper.Icon;
    morgenslayerSetEffect.m_skillLevel = Skills.SkillType.Swords;
    morgenslayerSetEffect.m_skillLevelModifier = 15;
    morgenslayerSetEffect.m_skillLevel2 = Skills.SkillType.Blocking;
    morgenslayerSetEffect.m_skillLevelModifier2 = 15;
    morgenslayerSetEffect.m_mods.Add(new()
    {
      m_type = HitData.DamageType.Pierce,
      m_modifier = HitData.DamageModifier.Resistant,
    });

    morgenslayerHelmWrapper.Set.Effect = morgenslayerSetEffect;
    morgenslayerHelmWrapper.Set.Name = "Morgenslayer";
    morgenslayerHelmWrapper.Set.Size = 3;
    morgenslayerChestWrapper.Set = morgenslayerHelmWrapper.Set;
    morgenslayerLegsWrapper.Set = morgenslayerHelmWrapper.Set;
  }
}
