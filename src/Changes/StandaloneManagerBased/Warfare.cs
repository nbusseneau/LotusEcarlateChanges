extern alias Warfare;

using HarmonyLib;
using static LotusEcarlateChanges.Changes.Constants.Weapon;
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
    string[] battleaxes = [
      "BattleaxeIron_TW",
      "BattleaxeCrystal_TW",
      "BattleaxeDvergr_TW",
    ];
    itemManager.Keep(battleaxes);
    foreach (var battleaxe in itemManager[battleaxes]) battleaxe.Wrapper.Weapon.MovementModifier = MovementModifier.TwoHanded;

    // Clubs
    itemManager.Keep("MaceChitin_TW");
    itemManager["MaceChitin_TW"].Wrapper.Weapon.MovementModifier = MovementModifier.OneHanded;

    // Sledgehammers
    string[] sledgehammers = [
      "SledgeStagbreaker_TW",
      "SledgeIron_TW",
      "SledgeBlackmetal_TW",
      "SledgeDemolisher_TW",
    ];
    itemManager.Keep(sledgehammers);
    foreach (var sledgehammer in itemManager[sledgehammers]) sledgehammer.Wrapper.Weapon.MovementModifier = MovementModifier.TwoHanded;
    itemManager["SledgeStagbreaker_TW"].Item.DropsFrom.Drops.Clear();

    // Battlehammers
    string[] battlehammers = [
      "BattlehammerTrollbone_TW",
      "BattlehammerDvergr_TW",
    ];
    itemManager.Keep(battlehammers);
    foreach (var battlehammer in itemManager[battlehammers]) battlehammer.Wrapper.Weapon.MovementModifier = MovementModifier.TwoHanded;

    // Fists
    string[] fists = [
      "FistBronze_TW",
      "FistChitin_TW",
      "FistIron_TW",
      "FistSilver_TW",
      "FistDvergr_TW",
    ];
    itemManager.Keep(fists);
    foreach (var fist in itemManager[fists]) fist.Wrapper.Weapon.MovementModifier = MovementModifier.Fist;

    var (fistBronze, _) = itemManager["FistBronze_TW"];
    fistBronze.RequiredItems.Requirements.Clear();
    fistBronze.RequiredItems.Add("DeerHide", 4);
    fistBronze.RequiredItems.Add("Bronze", 4);
    fistBronze.RequiredItems.Add("TrophyGreydwarf", 1);
    fistBronze.RequiredUpgradeItems.Requirements.Clear();
    fistBronze.RequiredUpgradeItems.Add("Bronze", 4);

    // Lances
    string[] lances = [
      "LanceBlackmetal_TW",
      "LanceDvergr_TW",
    ];
    itemManager.Keep(lances);
    foreach (var lance in itemManager[lances]) lance.Wrapper.Weapon.MovementModifier = MovementModifier.TwoHanded;

    // Warpikes
    string[] warpikes = [
      "WarpikeBone_TW",
      "WarpikeChitin_TW",
      "WarpikeObsidian_TW",
      "WarpikeBlackmetal_TW",
      "WarpikeDvergr_TW",
    ];
    itemManager.Keep(warpikes);
    foreach (var warpike in itemManager[warpikes]) warpike.Wrapper.Weapon.MovementModifier = MovementModifier.OneHanded;

    var (warpikeBone, warpikeBoneWrapper) = itemManager["WarpikeBone_TW"];
    warpikeBone.RequiredItems.Requirements.Clear();
    warpikeBone.RequiredItems.Add("BoneFragments", 16);
    warpikeBone.RequiredItems.Add("Bronze", 4);
    warpikeBone.RequiredItems.Add("TrophySkeleton", 1);
    warpikeBone.RequiredUpgradeItems.Requirements.Clear();
    warpikeBone.RequiredUpgradeItems.Add("BoneFragments", 8);
    warpikeBone.RequiredUpgradeItems.Add("Bronze", 4);

    // Claymores
    string[] claymores = [
      "ClaymoreIron_TW",
    ];
    itemManager.Keep(claymores);
    foreach (var claymore in itemManager[claymores]) claymore.Wrapper.Weapon.MovementModifier = MovementModifier.TwoHanded;

    // Bastard swords
    string[] bastardSwords = [
      "BastardBone_TW",
      "BastardChitin_TW",
      "BastardSilver_TW",
      "BastardDvergr_TW",
    ];
    itemManager.Keep(bastardSwords);
    foreach (var bastardSword in itemManager[bastardSwords]) bastardSword.Wrapper.Weapon.MovementModifier = MovementModifier.TwoHanded;

    var (bastardBone, bastardBoneWrapper) = itemManager["BastardBone_TW"];
    bastardBone.RequiredItems.Requirements.Clear();
    bastardBone.RequiredItems.Add("BoneFragments", 16);
    bastardBone.RequiredItems.Add("Bronze", 4);
    bastardBone.RequiredItems.Add("TrophySkeleton", 1);
    bastardBone.RequiredUpgradeItems.Requirements.Clear();
    bastardBone.RequiredUpgradeItems.Add("BoneFragments", 8);
    bastardBone.RequiredUpgradeItems.Add("Bronze", 4);

    // Specials / Uniques
    itemManager.Keep([
      "KnifeWrench_TW", // Knife/Mace
      "TridentBlackmetal_TW", // Atgeir/Spear
      "DualSwordScimitar_TW", // DualSwords
      "GreatbowBlackmetal_TW", // Greatbow
    ]);

    itemManager["KnifeWrench_TW"].Wrapper.Weapon.MovementModifier = MovementModifier.Knife;
    itemManager["TridentBlackmetal_TW"].Wrapper.Weapon.MovementModifier = MovementModifier.TwoHanded;
    itemManager["DualSwordScimitar_TW"].Wrapper.Weapon.MovementModifier = MovementModifier.TwoHanded;
    var (blackmetalGreatbow, blackmetalGreatbowWrapper) = itemManager["GreatbowBlackmetal_TW"];
    blackmetalGreatbow.Crafting.Stations.Clear();
    blackmetalGreatbow.Crafting.Add(Warfare::ItemManager.CraftingTable.Forge, 3);
    blackmetalGreatbowWrapper.Weapon.MovementModifier = MovementModifier.TwoHanded;

    // Bucklers
    itemManager.Keep("ShieldChitinBuckler_TW");
    itemManager["ShieldChitinBuckler_TW"].Wrapper.Weapon.MovementModifier = MovementModifier.Buckler;

    // Shields
    itemManager.Keep("ShieldChitin_TW");
    itemManager["ShieldChitin_TW"].Wrapper.Weapon.MovementModifier = MovementModifier.Shield;

    // Capes
    itemManager.Keep("CapeRotten_TW");
    var (rottenCape, rottenCapeWrapper) = itemManager["CapeRotten_TW"];
    rottenCape.RequiredItems.Requirements.Clear();
    rottenCape.RequiredItems.Add("RottenPelt_TW", 6);
    rottenCape.RequiredItems.Add("Guck", 6);
    rottenCape.RequiredItems.Add("Ooze", 6);
    rottenCape.RequiredItems.Add("TrophyCrawler_TW", 1);
    rottenCape.RequiredUpgradeItems.Requirements.Clear();
    rottenCape.RequiredUpgradeItems.Add("RottenPelt_TW", 3);
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
    string[] twoHandedAxes = battleaxes;
    var twoHandedAxesSkillIcon = itemManager["BattleaxeIron_TW"].Wrapper.Icon;
    CustomSkills.SetIcon(CustomSkills.TwoHandedAxes, twoHandedAxesSkillIcon);
    foreach (var (_, wrapper) in itemManager[twoHandedAxes]) wrapper.Weapon.SkillType = CustomSkills.TwoHandedAxes;

    string[] twoHandedHammers = [
      .. sledgehammers,
      .. battlehammers,
    ];
    var twoHandedHammersSkillIcon = itemManager["SledgeStagbreaker_TW"].Wrapper.Icon;
    CustomSkills.SetIcon(CustomSkills.TwoHandedHammers, twoHandedHammersSkillIcon);
    foreach (var (_, wrapper) in itemManager[twoHandedHammers]) wrapper.Weapon.SkillType = CustomSkills.TwoHandedHammers;

    string[] twoHandedSwords = [
      .. claymores,
      .. bastardSwords,
    ];
    var twoHandedSwordsSkillIcon = itemManager["BastardBone_TW"].Wrapper.Icon;
    CustomSkills.SetIcon(CustomSkills.TwoHandedSwords, twoHandedSwordsSkillIcon);
    foreach (var (_, wrapper) in itemManager[twoHandedSwords]) wrapper.Weapon.SkillType = CustomSkills.TwoHandedSwords;

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
