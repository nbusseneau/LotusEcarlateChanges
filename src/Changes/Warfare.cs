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

    // Clubs
    this.Keep("MaceChitin_TW");

    // Sledgehammers
    this.Keep("SledgeStagbreaker_TW");
    this.Keep("SledgeIron_TW");
    this.Keep("SledgeBlackmetal_TW");
    this.Keep("SledgeDemolisher_TW");

    var sledgeStagBreaker = plugin.ItemManager["SledgeStagbreaker_TW"];
    sledgeStagBreaker.DropsFrom.Clear();

    // Battlehammers
    this.Keep("BattlehammerTrollbone_TW");
    this.Keep("BattlehammerDvergr_TW");

    // Fists
    this.Keep("FistBronze_TW");
    this.Keep("FistChitin_TW");
    this.Keep("FistIron_TW");
    this.Keep("FistSilver_TW");
    this.Keep("FistDvergr_TW");

    // Lances
    this.Keep("LanceBlackmetal_TW");
    this.Keep("LanceDvergr_TW");

    // Warpikes
    this.Keep("WarpikeBone_TW");
    this.Keep("WarpikeChitin_TW");
    this.Keep("WarpikeObsidian_TW");
    this.Keep("WarpikeBlackmetal_TW");
    this.Keep("WarpikeDvergr_TW");

    // Claymores
    this.Keep("ClaymoreIron_TW");

    // Bastard swords
    this.Keep("BastardBone_TW");
    this.Keep("BastardChitin_TW");
    this.Keep("BastardSilver_TW");
    this.Keep("BastardDvergr_TW");


    // Specials / Uniques
    this.Keep("KnifeWrench_TW"); // Knife/Mace
    this.Keep("TridentBlackmetal_TW"); // Atgeir/Spear
    this.Keep("DualSwordScimitar_TW"); // DualSwords
    this.Keep("GreatbowBlackmetal_TW"); // Greatbow
    plugin.ItemManager["GreatbowBlackmetal_TW"].Crafting.Clear();
    plugin.ItemManager["GreatbowBlackmetal_TW"].Crafting.Add((int)CraftingTable.Forge, 3);

    // Bucklers
    this.Keep("ShieldChitinBuckler_TW");

    // Shields
    this.Keep("ShieldChitin_TW");

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
    this.RegisterAttackSkill(CustomSkills.TwoHandedAxes, "$Warfare_TwoHandedAxesSkill_Description", twoHandedAxesSkillIcon, twoHandedAxes);

    HashSet<string> twoHandedClubs = [
      "SledgeStagbreaker_TW",
      "BattlehammerTrollbone_TW",
      "SledgeIron_TW",
      "SledgeBlackmetal_TW",
      "SledgeDemolisher_TW",
      "BattlehammerDvergr_TW",
    ];
    var twoHandedClubsSkillIcon = plugin.ItemManager["SledgeStagbreaker_TW"].ItemData.GetIcon();
    this.RegisterAttackSkill(CustomSkills.TwoHandedHammers, "$Warfare_TwoHandedClubsSkill_Description", twoHandedClubsSkillIcon, twoHandedClubs);

    HashSet<string> twoHandedSwords = [
      "BastardBone_TW",
      "BastardChitin_TW",
      "ClaymoreIron_TW",
      "BastardSilver_TW",
      "BastardDvergr_TW",
    ];
    var twoHandedSwordsSkillIcon = plugin.ItemManager["BastardBone_TW"].ItemData.GetIcon();
    var twoHanderSwordsSkill = this.RegisterAttackSkill(CustomSkills.TwoHandedSwords, "$Warfare_TwoHandedSwordsSkill_Description", twoHandedSwordsSkillIcon, twoHandedSwords);

    HashSet<string> warpikes = [
      "WarpikeBone_TW",
      "WarpikeChitin_TW",
      "WarpikeObsidian_TW",
      "WarpikeBlackmetal_TW",
      "WarpikeDvergr_TW",
    ];
    var warpikesSkillIcon = plugin.ItemManager["WarpikeBone_TW"].ItemData.GetIcon();
    this.RegisterAttackSkill(CustomSkills.Warpikes, "$Warfare_WarpikesSkill_Description", warpikesSkillIcon, warpikes);

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
