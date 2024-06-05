extern alias Warfare;

using HarmonyLib;
using LotusEcarlateChanges.Changes.JotunnBased;
using LotusEcarlateChanges.Model.Changes;
using Warfare::ItemManager;
using Warfare::PieceManager;
using Warfare::Warfare;

namespace LotusEcarlateChanges.Changes.StandaloneManagerBased;

public class Warfare : StandaloneManagerBasedChangesBase
{
  protected override void ApplyInternal()
  {
    var itemManager = this.RegisterItemManager(Item.registeredItems, PrefabManager.prefabs, PrefabManager.ZnetOnlyPrefabs);
    var pieceManager = this.RegisterPieceManager(BuildPiece.registeredPieces, PiecePrefabManager.piecePrefabs);

    // Remove fletcher table and upgrades + black forge upgrades
    foreach (var (_, wrapper) in pieceManager) pieceManager.Remove(wrapper.PrefabName);

    // Battleaxes
    itemManager.Keep([
      "BattleaxeIron_TW",
      "BattleaxeCrystal_TW",
      "BattleaxeDvergr_TW",
    ]);
    itemManager["BattleaxeIron_TW"].Wrapper.Weapon.MovementModifier = -0.10f;
    itemManager["BattleaxeCrystal_TW"].Wrapper.Weapon.MovementModifier = -0.10f;
    itemManager["SledgeStagbreaker_TW"].Wrapper.Weapon.MovementModifier = -0.10f;

    // Clubs
    itemManager.Keep("MaceChitin_TW");
    itemManager["MaceChitin_TW"].Wrapper.Weapon.MovementModifier = -0.05f;

    // Sledgehammers
    itemManager.Keep([
      "SledgeStagbreaker_TW",
      "SledgeIron_TW",
      "SledgeBlackmetal_TW",
      "SledgeDemolisher_TW",
    ]);

    var (sledgeStagBreaker, sledgeStagBreakerWrapper) = itemManager["SledgeStagbreaker_TW"];
    sledgeStagBreaker.DropsFrom.Drops.Clear();
    sledgeStagBreakerWrapper.Weapon.MovementModifier = -0.10f;
    itemManager["SledgeIron_TW"].Wrapper.Weapon.MovementModifier = -0.10f;
    itemManager["SledgeBlackmetal_TW"].Wrapper.Weapon.MovementModifier = -0.10f;
    itemManager["SledgeDemolisher_TW"].Wrapper.Weapon.MovementModifier = -0.10f;

    // Battlehammers
    itemManager.Keep([
      "BattlehammerTrollbone_TW",
      "BattlehammerDvergr_TW",
    ]);

    itemManager["BattlehammerTrollbone_TW"].Wrapper.Weapon.MovementModifier = -0.10f;
    itemManager["BattlehammerDvergr_TW"].Wrapper.Weapon.MovementModifier = -0.10f;

    // Fists
    itemManager.Keep([
      "FistBronze_TW",
      "FistChitin_TW",
      "FistIron_TW",
      "FistSilver_TW",
      "FistDvergr_TW",
    ]);

    itemManager["FistBronze_TW"].Wrapper.Weapon.MovementModifier = 0f;
    itemManager["FistChitin_TW"].Wrapper.Weapon.MovementModifier = 0f;
    itemManager["FistIron_TW"].Wrapper.Weapon.MovementModifier = 0f;
    itemManager["FistSilver_TW"].Wrapper.Weapon.MovementModifier = 0f;
    itemManager["FistDvergr_TW"].Wrapper.Weapon.MovementModifier = 0f;

    // Lances
    itemManager.Keep([
      "LanceBlackmetal_TW",
      "LanceDvergr_TW",
    ]);

    itemManager["LanceBlackmetal_TW"].Wrapper.Weapon.MovementModifier = -0.10f;
    itemManager["LanceDvergr_TW"].Wrapper.Weapon.MovementModifier = -0.10f;

    // Warpikes
    itemManager.Keep([
      "WarpikeBone_TW",
      "WarpikeChitin_TW",
      "WarpikeObsidian_TW",
      "WarpikeBlackmetal_TW",
      "WarpikeDvergr_TW",
    ]);

    itemManager["WarpikeBone_TW"].Wrapper.Weapon.MovementModifier = -0.05f;
    itemManager["WarpikeChitin_TW"].Wrapper.Weapon.MovementModifier = -0.05f;
    itemManager["WarpikeObsidian_TW"].Wrapper.Weapon.MovementModifier = -0.05f;
    itemManager["WarpikeBlackmetal_TW"].Wrapper.Weapon.MovementModifier = -0.05f;
    itemManager["WarpikeDvergr_TW"].Wrapper.Weapon.MovementModifier = -0.05f;

    // Claymores
    itemManager.Keep("ClaymoreIron_TW");
    itemManager["ClaymoreIron_TW"].Wrapper.Weapon.MovementModifier = -0.10f;

    // Bastard swords
    itemManager.Keep([
      "BastardBone_TW",
      "BastardChitin_TW",
      "BastardSilver_TW",
      "BastardDvergr_TW",
    ]);

    itemManager["BastardBone_TW"].Wrapper.Weapon.MovementModifier = -0.10f;
    itemManager["BastardChitin_TW"].Wrapper.Weapon.MovementModifier = -0.10f;
    itemManager["BastardSilver_TW"].Wrapper.Weapon.MovementModifier = -0.10f;
    itemManager["BastardDvergr_TW"].Wrapper.Weapon.MovementModifier = -0.10f;

    // Specials / Uniques
    itemManager.Keep([
      "KnifeWrench_TW", // Knife/Mace
      "TridentBlackmetal_TW", // Atgeir/Spear
      "DualSwordScimitar_TW", // DualSwords
      "GreatbowBlackmetal_TW", // Greatbow
    ]);

    itemManager["KnifeWrench_TW"].Wrapper.Weapon.MovementModifier = 0f;
    itemManager["TridentBlackmetal_TW"].Wrapper.Weapon.MovementModifier = -0.10f;
    itemManager["DualSwordScimitar_TW"].Wrapper.Weapon.MovementModifier = -0.10f;
    var (blackmetalGreatbow, blackmetalGreatbowWrapper) = itemManager["GreatbowBlackmetal_TW"];
    blackmetalGreatbow.Crafting.Stations.Clear();
    blackmetalGreatbow.Crafting.Add(Warfare::ItemManager.CraftingTable.Forge, 3);
    blackmetalGreatbowWrapper.Weapon.MovementModifier = -0.05f;

    // Bucklers
    itemManager.Keep("ShieldChitinBuckler_TW");
    itemManager["ShieldChitinBuckler_TW"].Wrapper.Weapon.MovementModifier = -0.05f;

    // Shields
    itemManager.Keep("ShieldChitin_TW");
    itemManager["ShieldChitin_TW"].Wrapper.Weapon.MovementModifier = -0.10f;

    // Capes
    itemManager.Keep("CapeRotten_TW");
    var (rottenCape, rottenCapeWrapper) = itemManager["CapeRotten_TW"];
    rottenCape.RequiredItems.Requirements.Clear();
    rottenCape.RequiredItems.Add("RottenPelt_TW", 6);
    rottenCape.RequiredItems.Add("Guck", 6);
    rottenCape.RequiredItems.Add("Ooze", 6);
    rottenCape.RequiredItems.Add("TrophyCrawler_TW", 1);
    rottenCape.RequiredUpgradeItems.Requirements.Clear();
    rottenCape.RequiredUpgradeItems.Add("RottenPelt_TW", 2);
    rottenCape.RequiredUpgradeItems.Add("Guck", 2);
    rottenCape.RequiredUpgradeItems.Add("Ooze", 2);
    rottenCapeWrapper.Armor.EquipEffect = null;
    rottenCapeWrapper.Armor.DamageModifiers.Add(new()
    {
      m_type = HitData.DamageType.Poison,
      m_modifier = HitData.DamageModifier.Resistant,
    });

    // Meads
    itemManager.Keep([
      "MeadBaseLingeringStaminaMinor_TW",
      "MeadStaminaLingeringMinor_TW",
      "MeadBaseLingeringStaminaMedium_TW",
      "MeadStaminaLingeringMedium_TW",
      "MeadBaseLightningResist_TW",
      "MeadLightningResist_TW",
    ]);

    // Drops
    itemManager.Keep([
      "RazorbackLeather_TW",
      "RazorbackTusk_TW",
      "BlackBearPelt_TW",
      "TrollBone_TW",
      "RottenPelt_TW",
      "GrizzlyBearPelt_TW",
      "LoxBone_TW",
      "ProwlerFang_TW",
      "DarkCrystal_TW",
      "VenomousFang_TW",
    ]);

    // Skills
    string[] twoHandedAxes = [
      "BattleaxeIron_TW",
      "BattleaxeCrystal_TW",
      "BattleaxeDvergr_TW",
    ];
    var twoHandedAxesSkillIcon = itemManager["BattleaxeIron_TW"].Wrapper.Icon;
    CustomSkills.SetIcon(CustomSkills.TwoHandedAxes, twoHandedAxesSkillIcon);
    foreach (var (_, wrapper) in itemManager[twoHandedAxes]) wrapper.Weapon.SkillType = CustomSkills.TwoHandedAxes;

    string[] twoHandedHammers = [
      "SledgeStagbreaker_TW",
      "BattlehammerTrollbone_TW",
      "SledgeIron_TW",
      "SledgeBlackmetal_TW",
      "SledgeDemolisher_TW",
      "BattlehammerDvergr_TW",
    ];
    var twoHandedHammersSkillIcon = itemManager["SledgeStagbreaker_TW"].Wrapper.Icon;
    CustomSkills.SetIcon(CustomSkills.TwoHandedHammers, twoHandedHammersSkillIcon);
    foreach (var (_, wrapper) in itemManager[twoHandedHammers]) wrapper.Weapon.SkillType = CustomSkills.TwoHandedHammers;

    string[] twoHandedSwords = [
      "BastardBone_TW",
      "BastardChitin_TW",
      "ClaymoreIron_TW",
      "BastardSilver_TW",
      "BastardDvergr_TW",
    ];
    var twoHandedSwordsSkillIcon = itemManager["BastardBone_TW"].Wrapper.Icon;
    CustomSkills.SetIcon(CustomSkills.TwoHandedSwords, twoHandedSwordsSkillIcon);
    foreach (var (_, wrapper) in itemManager[twoHandedSwords]) wrapper.Weapon.SkillType = CustomSkills.TwoHandedSwords;

    string[] warpikes = [
      "WarpikeBone_TW",
      "WarpikeChitin_TW",
      "WarpikeObsidian_TW",
      "WarpikeBlackmetal_TW",
      "WarpikeDvergr_TW",
    ];
    var warpikesSkillIcon = itemManager["WarpikeBone_TW"].Wrapper.Icon;
    CustomSkills.SetIcon(CustomSkills.Warpikes, warpikesSkillIcon);
    foreach (var (_, wrapper) in itemManager[warpikes]) wrapper.Weapon.SkillType = CustomSkills.Warpikes;

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
