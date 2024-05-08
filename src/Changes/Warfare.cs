using System.Collections.Generic;
using HarmonyLib;
using ItemManager;
using UnityEngine;
using LotusEcarlateChanges.Model.Reflection;
using LotusEcarlateChanges.Model.Reflection.Plugins;
using LotusEcarlateChanges.Model;

namespace LotusEcarlateChanges.Changes;

public class Warfare : ReflectionChangesBase<WarfarePlugin>
{
  protected override void ApplyChangesInternal()
  {
    // Battleaxes
    this.Keep("BattleaxeIron_TW");
    this.Keep("BattleaxeCrystal_TW");
    this.Keep("BattleaxeDvergr_TW");
    plugin.ItemManager["BattleaxeIron_TW"].Weapon.MovementModifier = -0.10f;
    plugin.ItemManager["BattleaxeCrystal_TW"].Weapon.MovementModifier = -0.10f;
    plugin.ItemManager["SledgeStagbreaker_TW"].Weapon.MovementModifier = -0.10f;

    // Clubs
    this.Keep("MaceChitin_TW");
    plugin.ItemManager["MaceChitin_TW"].Weapon.MovementModifier = -0.05f;

    // Sledgehammers
    this.Keep("SledgeStagbreaker_TW");
    this.Keep("SledgeIron_TW");
    this.Keep("SledgeBlackmetal_TW");
    this.Keep("SledgeDemolisher_TW");
    var sledgeStagBreaker = plugin.ItemManager["SledgeStagbreaker_TW"];
    sledgeStagBreaker.DropsFrom.Clear();
    sledgeStagBreaker.Weapon.MovementModifier = -0.10f;
    plugin.ItemManager["SledgeIron_TW"].Weapon.MovementModifier = -0.10f;
    plugin.ItemManager["SledgeBlackmetal_TW"].Weapon.MovementModifier = -0.10f;
    plugin.ItemManager["SledgeDemolisher_TW"].Weapon.MovementModifier = -0.10f;

    // Battlehammers
    this.Keep("BattlehammerTrollbone_TW");
    this.Keep("BattlehammerDvergr_TW");
    plugin.ItemManager["BattlehammerTrollbone_TW"].Weapon.MovementModifier = -0.10f;
    plugin.ItemManager["BattlehammerDvergr_TW"].Weapon.MovementModifier = -0.10f;

    // Fists
    this.Keep("FistBronze_TW");
    this.Keep("FistChitin_TW");
    this.Keep("FistIron_TW");
    this.Keep("FistSilver_TW");
    this.Keep("FistDvergr_TW");
    plugin.ItemManager["FistBronze_TW"].Weapon.MovementModifier = 0f;
    plugin.ItemManager["FistChitin_TW"].Weapon.MovementModifier = 0f;
    plugin.ItemManager["FistIron_TW"].Weapon.MovementModifier = 0f;
    plugin.ItemManager["FistSilver_TW"].Weapon.MovementModifier = 0f;
    plugin.ItemManager["FistDvergr_TW"].Weapon.MovementModifier = 0f;

    // Lances
    this.Keep("LanceBlackmetal_TW");
    this.Keep("LanceDvergr_TW");
    plugin.ItemManager["LanceBlackmetal_TW"].Weapon.MovementModifier = -0.10f;
    plugin.ItemManager["LanceDvergr_TW"].Weapon.MovementModifier = -0.10f;

    // Warpikes
    this.Keep("WarpikeBone_TW");
    this.Keep("WarpikeChitin_TW");
    this.Keep("WarpikeObsidian_TW");
    this.Keep("WarpikeBlackmetal_TW");
    this.Keep("WarpikeDvergr_TW");
    plugin.ItemManager["WarpikeBone_TW"].Weapon.MovementModifier = -0.05f;
    plugin.ItemManager["WarpikeChitin_TW"].Weapon.MovementModifier = -0.05f;
    plugin.ItemManager["WarpikeObsidian_TW"].Weapon.MovementModifier = -0.05f;
    plugin.ItemManager["WarpikeBlackmetal_TW"].Weapon.MovementModifier = -0.05f;
    plugin.ItemManager["WarpikeDvergr_TW"].Weapon.MovementModifier = -0.05f;

    // Claymores
    this.Keep("ClaymoreIron_TW");
    plugin.ItemManager["ClaymoreIron_TW"].Weapon.MovementModifier = -0.10f;

    // Bastard swords
    this.Keep("BastardBone_TW");
    this.Keep("BastardChitin_TW");
    this.Keep("BastardSilver_TW");
    this.Keep("BastardDvergr_TW");
    plugin.ItemManager["BastardBone_TW"].Weapon.MovementModifier = -0.10f;
    plugin.ItemManager["BastardChitin_TW"].Weapon.MovementModifier = -0.10f;
    plugin.ItemManager["BastardSilver_TW"].Weapon.MovementModifier = -0.10f;
    plugin.ItemManager["BastardDvergr_TW"].Weapon.MovementModifier = -0.10f;

    // Specials / Uniques
    this.Keep("KnifeWrench_TW"); // Knife/Mace
    this.Keep("TridentBlackmetal_TW"); // Atgeir/Spear
    this.Keep("DualSwordScimitar_TW"); // DualSwords
    this.Keep("GreatbowBlackmetal_TW"); // Greatbow
    plugin.ItemManager["KnifeWrench_TW"].Weapon.MovementModifier = 0f;
    plugin.ItemManager["TridentBlackmetal_TW"].Weapon.MovementModifier = -0.10f;
    plugin.ItemManager["DualSwordScimitar_TW"].Weapon.MovementModifier = -0.10f;
    var blackmetalGreatbow = plugin.ItemManager["GreatbowBlackmetal_TW"];
    blackmetalGreatbow.Crafting.Clear();
    blackmetalGreatbow.Crafting.Add((int)CraftingTable.Forge, 3);
    blackmetalGreatbow.Weapon.MovementModifier = -0.05f;

    // Bucklers
    this.Keep("ShieldChitinBuckler_TW");
    plugin.ItemManager["ShieldChitinBuckler_TW"].Weapon.MovementModifier = -0.05f;

    // Shields
    this.Keep("ShieldChitin_TW");
    plugin.ItemManager["ShieldChitin_TW"].Weapon.MovementModifier = -0.10f;

    // Capes
    this.Keep("CapeRotten_TW");
    var rottenCape = plugin.ItemManager["CapeRotten_TW"];
    rottenCape.RequiredItems.Clear();
    rottenCape.RequiredItems.Add("RottenPelt_TW", 6);
    rottenCape.RequiredItems.Add("Guck", 6);
    rottenCape.RequiredItems.Add("Ooze", 6);
    rottenCape.RequiredItems.Add("TrophyCrawler_TW", 1);
    rottenCape.RequiredUpgradeItems.Clear();
    rottenCape.RequiredUpgradeItems.Add("RottenPelt_TW", 3);
    rottenCape.RequiredUpgradeItems.Add("Guck", 3);
    rottenCape.RequiredUpgradeItems.Add("Ooze", 3);
    rottenCape.Armor.EquipEffect = null;
    rottenCape.Armor.DamageModifiers.Add(new()
    {
      m_type = HitData.DamageType.Poison,
      m_modifier = HitData.DamageModifier.Resistant,
    });

    // Meads
    this.Keep("MeadBaseLingeringStaminaMinor_TW");
    this.Keep("MeadStaminaLingeringMinor_TW");
    this.Keep("MeadBaseLingeringStaminaMedium_TW");
    this.Keep("MeadStaminaLingeringMedium_TW");
    this.Keep("MeadBaseLightningResist_TW");
    this.Keep("MeadLightningResist_TW");

    // Drops
    this.Keep("RazorbackLeather_TW");
    this.Keep("RazorbackTusk_TW");
    this.Keep("BlackBearPelt_TW");
    this.Keep("TrollBone_TW");
    this.Keep("RottenPelt_TW");
    this.Keep("GrizzlyBearPelt_TW");
    this.Keep("LoxBone_TW");
    this.Keep("ProwlerFang_TW");
    this.Keep("DarkCrystal_TW");
    this.Keep("VenomousFang_TW");

    // Skills
    HashSet<string> twoHandedAxes = [
      "BattleaxeIron_TW",
      "BattleaxeCrystal_TW",
      "BattleaxeDvergr_TW",
    ];
    var twoHandedAxesSkillIcon = plugin.ItemManager["BattleaxeIron_TW"].ItemData.GetIcon();
    this.RegisterAttackSkill(CustomSkills.Names.TwoHandedAxes, "$Warfare_TwoHandedAxesSkill_Description", twoHandedAxesSkillIcon, twoHandedAxes);

    HashSet<string> twoHandedClubs = [
      "SledgeStagbreaker_TW",
      "BattlehammerTrollbone_TW",
      "SledgeIron_TW",
      "SledgeBlackmetal_TW",
      "SledgeDemolisher_TW",
      "BattlehammerDvergr_TW",
    ];
    var twoHandedClubsSkillIcon = plugin.ItemManager["SledgeStagbreaker_TW"].ItemData.GetIcon();
    this.RegisterAttackSkill(CustomSkills.Names.TwoHandedHammers, "$Warfare_TwoHandedClubsSkill_Description", twoHandedClubsSkillIcon, twoHandedClubs);

    HashSet<string> twoHandedSwords = [
      "BastardBone_TW",
      "BastardChitin_TW",
      "ClaymoreIron_TW",
      "BastardSilver_TW",
      "BastardDvergr_TW",
    ];
    var twoHandedSwordsSkillIcon = plugin.ItemManager["BastardBone_TW"].ItemData.GetIcon();
    var twoHanderSwordsSkill = this.RegisterAttackSkill(CustomSkills.Names.TwoHandedSwords, "$Warfare_TwoHandedSwordsSkill_Description", twoHandedSwordsSkillIcon, twoHandedSwords);

    HashSet<string> warpikes = [
      "WarpikeBone_TW",
      "WarpikeChitin_TW",
      "WarpikeObsidian_TW",
      "WarpikeBlackmetal_TW",
      "WarpikeDvergr_TW",
    ];
    var warpikesSkillIcon = plugin.ItemManager["WarpikeBone_TW"].ItemData.GetIcon();
    this.RegisterAttackSkill(CustomSkills.Names.Warpikes, "$Warfare_WarpikesSkill_Description", warpikesSkillIcon, warpikes);

    // Custom patches
    Plugin.Harmony.Patch(
      AccessTools.Method(plugin.Assembly.GetType("Warfare.BowsPatch"), "Postfix"),
      prefix: new HarmonyMethod(this.GetType(), nameof(NoOpPrefix))
    );

    Plugin.Harmony.Patch(
      AccessTools.Method(plugin.Assembly.GetType("Warfare.VanillaDropTweaks+VanillaDropTweaks_MonstrumPatch"), "Postfix"),
      prefix: new HarmonyMethod(this.GetType(), nameof(NoOpPrefix))
    );

    var pluginType = plugin.Assembly.GetType("Warfare.WarfarePlugin");
    var _projectilePrefabsX = (List<GameObject>)AccessTools.Field(pluginType, "projectilePrefabsX").GetValue(null);
    var _projectilePrefabsY = (List<GameObject>)AccessTools.Field(pluginType, "projectilePrefabsY").GetValue(null);
    var _projectilePrefabsZ = (List<GameObject>)AccessTools.Field(pluginType, "projectilePrefabsZ").GetValue(null);
    _projectilePrefabsX.Clear();
    _projectilePrefabsY.Clear();
    _projectilePrefabsZ.Clear();
  }

  private static void NoOpPrefix(ref bool __runOriginal) => __runOriginal = false;

  private SkillManager.Skill RegisterAttackSkill(string englishName, string descriptionAlias, Sprite icon, HashSet<string> prefabNames)
  {
    var skill = new SkillManager.Skill(englishName, icon) { Configurable = false };
    skill.Description.Alias(descriptionAlias);
    foreach (var prefabName in prefabNames)
    {
      plugin.ItemManager[prefabName].SharedData.m_skillType = SkillManager.Skill.fromName(englishName);
    }
    return skill;
  }
}
