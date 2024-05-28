extern alias Warfare;

using System.Collections.Generic;
using HarmonyLib;
using LotusEcarlateChanges.Changes.JotunnBased;
using LotusEcarlateChanges.Extensions;
using LotusEcarlateChanges.Model.Changes;
using LotusEcarlateChanges.Model.StandaloneManagerInterceptors;
using Warfare::ItemManager;
using Warfare::PieceManager;
using Warfare::Warfare;

namespace LotusEcarlateChanges.Changes.StandaloneManagerBased;

public class Warfare : StandaloneManagerBasedChangesBase
{
  private static ItemManagerInterceptor<Item> s_itemManager;

  protected override void ApplyInternal()
  {
    s_itemManager = this.RegisterItemManager(Item.registeredItems, PrefabManager.prefabs, PrefabManager.ZnetOnlyPrefabs);

    // Remove fletcher table pieces
    var pieceManager = this.RegisterPieceManager(BuildPiece.registeredPieces, PiecePrefabManager.piecePrefabs);

    // Battleaxes
    this.Keep("BattleaxeIron_TW");
    this.Keep("BattleaxeCrystal_TW");
    this.Keep("BattleaxeDvergr_TW");
    s_itemManager["BattleaxeIron_TW"].Item().Weapon.MovementModifier = -0.10f;
    s_itemManager["BattleaxeCrystal_TW"].Item().Weapon.MovementModifier = -0.10f;
    s_itemManager["SledgeStagbreaker_TW"].Item().Weapon.MovementModifier = -0.10f;

    // Clubs
    this.Keep("MaceChitin_TW");
    s_itemManager["MaceChitin_TW"].Item().Weapon.MovementModifier = -0.05f;

    // Sledgehammers
    this.Keep("SledgeStagbreaker_TW");
    this.Keep("SledgeIron_TW");
    this.Keep("SledgeBlackmetal_TW");
    this.Keep("SledgeDemolisher_TW");
    var sledgeStagBreaker = s_itemManager["SledgeStagbreaker_TW"];
    sledgeStagBreaker.DropsFrom.Drops.Clear();
    sledgeStagBreaker.Item().Weapon.MovementModifier = -0.10f;
    s_itemManager["SledgeIron_TW"].Item().Weapon.MovementModifier = -0.10f;
    s_itemManager["SledgeBlackmetal_TW"].Item().Weapon.MovementModifier = -0.10f;
    s_itemManager["SledgeDemolisher_TW"].Item().Weapon.MovementModifier = -0.10f;

    // Battlehammers
    this.Keep("BattlehammerTrollbone_TW");
    this.Keep("BattlehammerDvergr_TW");
    s_itemManager["BattlehammerTrollbone_TW"].Item().Weapon.MovementModifier = -0.10f;
    s_itemManager["BattlehammerDvergr_TW"].Item().Weapon.MovementModifier = -0.10f;

    // Fists
    this.Keep("FistBronze_TW");
    this.Keep("FistChitin_TW");
    this.Keep("FistIron_TW");
    this.Keep("FistSilver_TW");
    this.Keep("FistDvergr_TW");
    s_itemManager["FistBronze_TW"].Item().Weapon.MovementModifier = 0f;
    s_itemManager["FistChitin_TW"].Item().Weapon.MovementModifier = 0f;
    s_itemManager["FistIron_TW"].Item().Weapon.MovementModifier = 0f;
    s_itemManager["FistSilver_TW"].Item().Weapon.MovementModifier = 0f;
    s_itemManager["FistDvergr_TW"].Item().Weapon.MovementModifier = 0f;

    // Lances
    this.Keep("LanceBlackmetal_TW");
    this.Keep("LanceDvergr_TW");
    s_itemManager["LanceBlackmetal_TW"].Item().Weapon.MovementModifier = -0.10f;
    s_itemManager["LanceDvergr_TW"].Item().Weapon.MovementModifier = -0.10f;

    // Warpikes
    this.Keep("WarpikeBone_TW");
    this.Keep("WarpikeChitin_TW");
    this.Keep("WarpikeObsidian_TW");
    this.Keep("WarpikeBlackmetal_TW");
    this.Keep("WarpikeDvergr_TW");
    s_itemManager["WarpikeBone_TW"].Item().Weapon.MovementModifier = -0.05f;
    s_itemManager["WarpikeChitin_TW"].Item().Weapon.MovementModifier = -0.05f;
    s_itemManager["WarpikeObsidian_TW"].Item().Weapon.MovementModifier = -0.05f;
    s_itemManager["WarpikeBlackmetal_TW"].Item().Weapon.MovementModifier = -0.05f;
    s_itemManager["WarpikeDvergr_TW"].Item().Weapon.MovementModifier = -0.05f;

    // Claymores
    this.Keep("ClaymoreIron_TW");
    s_itemManager["ClaymoreIron_TW"].Item().Weapon.MovementModifier = -0.10f;

    // Bastard swords
    this.Keep("BastardBone_TW");
    this.Keep("BastardChitin_TW");
    this.Keep("BastardSilver_TW");
    this.Keep("BastardDvergr_TW");
    s_itemManager["BastardBone_TW"].Item().Weapon.MovementModifier = -0.10f;
    s_itemManager["BastardChitin_TW"].Item().Weapon.MovementModifier = -0.10f;
    s_itemManager["BastardSilver_TW"].Item().Weapon.MovementModifier = -0.10f;
    s_itemManager["BastardDvergr_TW"].Item().Weapon.MovementModifier = -0.10f;

    // Specials / Uniques
    this.Keep("KnifeWrench_TW"); // Knife/Mace
    this.Keep("TridentBlackmetal_TW"); // Atgeir/Spear
    this.Keep("DualSwordScimitar_TW"); // DualSwords
    this.Keep("GreatbowBlackmetal_TW"); // Greatbow
    s_itemManager["KnifeWrench_TW"].Item().Weapon.MovementModifier = 0f;
    s_itemManager["TridentBlackmetal_TW"].Item().Weapon.MovementModifier = -0.10f;
    s_itemManager["DualSwordScimitar_TW"].Item().Weapon.MovementModifier = -0.10f;
    var blackmetalGreatbow = s_itemManager["GreatbowBlackmetal_TW"];
    blackmetalGreatbow.Crafting.Stations.Clear();
    blackmetalGreatbow.Crafting.Add(Warfare::ItemManager.CraftingTable.Forge, 3);
    blackmetalGreatbow.Item().Weapon.MovementModifier = -0.05f;

    // Bucklers
    this.Keep("ShieldChitinBuckler_TW");
    s_itemManager["ShieldChitinBuckler_TW"].Item().Weapon.MovementModifier = -0.05f;

    // Shields
    this.Keep("ShieldChitin_TW");
    s_itemManager["ShieldChitin_TW"].Item().Weapon.MovementModifier = -0.10f;

    // Capes
    this.Keep("CapeRotten_TW");
    var rottenCape = s_itemManager["CapeRotten_TW"];
    rottenCape.RequiredItems.Requirements.Clear();
    rottenCape.RequiredItems.Add("RottenPelt_TW", 6);
    rottenCape.RequiredItems.Add("Guck", 6);
    rottenCape.RequiredItems.Add("Ooze", 6);
    rottenCape.RequiredItems.Add("TrophyCrawler_TW", 1);
    rottenCape.RequiredUpgradeItems.Requirements.Clear();
    rottenCape.RequiredUpgradeItems.Add("RottenPelt_TW", 3);
    rottenCape.RequiredUpgradeItems.Add("Guck", 3);
    rottenCape.RequiredUpgradeItems.Add("Ooze", 3);
    rottenCape.Item().Armor.EquipEffect = null;
    rottenCape.Item().Armor.DamageModifiers.Add(new()
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
    var twoHandedAxesSkillIcon = s_itemManager["BattleaxeIron_TW"].Item().ItemData.GetIcon();
    CustomSkills.SetIcon(CustomSkills.TwoHandedAxes, twoHandedAxesSkillIcon);
    foreach (var prefabName in twoHandedAxes) s_itemManager[prefabName].Item().Weapon.SkillType = CustomSkills.TwoHandedAxes;

    HashSet<string> twoHandedHammers = [
      "SledgeStagbreaker_TW",
      "BattlehammerTrollbone_TW",
      "SledgeIron_TW",
      "SledgeBlackmetal_TW",
      "SledgeDemolisher_TW",
      "BattlehammerDvergr_TW",
    ];
    var twoHandedHammersSkillIcon = s_itemManager["SledgeStagbreaker_TW"].Item().ItemData.GetIcon();
    CustomSkills.SetIcon(CustomSkills.TwoHandedHammers, twoHandedHammersSkillIcon);
    foreach (var prefabName in twoHandedHammers) s_itemManager[prefabName].Item().Weapon.SkillType = CustomSkills.TwoHandedHammers;

    HashSet<string> twoHandedSwords = [
      "BastardBone_TW",
      "BastardChitin_TW",
      "ClaymoreIron_TW",
      "BastardSilver_TW",
      "BastardDvergr_TW",
    ];
    var twoHandedSwordsSkillIcon = s_itemManager["BastardBone_TW"].Item().ItemData.GetIcon();
    CustomSkills.SetIcon(CustomSkills.TwoHandedSwords, twoHandedSwordsSkillIcon);
    foreach (var prefabName in twoHandedSwords) s_itemManager[prefabName].Item().Weapon.SkillType = CustomSkills.TwoHandedSwords;

    HashSet<string> warpikes = [
      "WarpikeBone_TW",
      "WarpikeChitin_TW",
      "WarpikeObsidian_TW",
      "WarpikeBlackmetal_TW",
      "WarpikeDvergr_TW",
    ];
    var warpikesSkillIcon = s_itemManager["WarpikeBone_TW"].Item().ItemData.GetIcon();
    CustomSkills.SetIcon(CustomSkills.Warpikes, warpikesSkillIcon);
    foreach (var prefabName in warpikes) s_itemManager[prefabName].Item().Weapon.SkillType = CustomSkills.Warpikes;

    // Clear projectile prefabs since we didn't keep any
    WarfarePlugin.projectilePrefabsX.Clear();
    WarfarePlugin.projectilePrefabsY.Clear();
    WarfarePlugin.projectilePrefabsZ.Clear();

    // Custom patches
    Plugin.Harmony.Patch(
      AccessTools.Method(typeof(BowsPatch), nameof(BowsPatch.Postfix)),
      prefix: new HarmonyMethod(this.GetType(), nameof(NoOpPrefix))
    );
    Plugin.Harmony.Patch(
      AccessTools.Method(typeof(VanillaDropTweaks.VanillaDropTweaks_MonstrumPatch), nameof(VanillaDropTweaks.VanillaDropTweaks_MonstrumPatch.Postfix)),
      prefix: new HarmonyMethod(this.GetType(), nameof(NoOpPrefix))
    );
  }

  private static void NoOpPrefix(ref bool __runOriginal) => __runOriginal = false;
}
