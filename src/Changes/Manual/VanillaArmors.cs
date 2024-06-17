using static LotusEcarlateChanges.Changes.Constants.Armor;
using LotusEcarlateChanges.Model.Changes;
using UnityEngine;

namespace LotusEcarlateChanges.Changes.Manual;

public class VanillaArmors : ManualChangesBase
{
  protected override void ApplyApplyOnObjectDBAwakeInternal()
  {
    // Leather
    var leatherHelm = this.ItemManager["HelmetLeather"];
    leatherHelm.Resources.Clear();
    leatherHelm.Resources.Add("LeatherScraps", 2, 1);
    leatherHelm.Resources.Add("DeerHide", 2, 1);
    leatherHelm.Armor.ArmorBase = 1;
    leatherHelm.Armor.ArmorPerLevel = 1;
    leatherHelm.Armor.MovementModifier = VeryLight.MovementModifier.Helm;
    leatherHelm.Armor.Weight = VeryLight.Weight.Helm;

    var leatherChest = this.ItemManager["ArmorLeatherChest"];
    leatherChest.Resources.Clear();
    leatherChest.Resources.Add("DeerHide", 6, 3);
    leatherChest.Resources.Add("LeatherScraps", 6, 3);
    leatherChest.Armor.ArmorBase = 3;
    leatherChest.Armor.ArmorPerLevel = 3;
    leatherChest.Armor.MovementModifier = VeryLight.MovementModifier.Chest;
    leatherChest.Armor.Weight = VeryLight.Weight.Chest;

    var leatherLegs = this.ItemManager["ArmorLeatherLegs"];
    leatherLegs.Resources.Clear();
    leatherLegs.Resources.Add("DeerHide", 4, 2);
    leatherLegs.Resources.Add("LeatherScraps", 4, 2);
    leatherLegs.Armor.ArmorBase = 2;
    leatherLegs.Armor.ArmorPerLevel = 2;
    leatherLegs.Armor.MovementModifier = VeryLight.MovementModifier.Legs;
    leatherLegs.Armor.Weight = VeryLight.Weight.Legs;

    var leatherCape = this.ItemManager["CapeDeerHide"];
    leatherCape.Resources.Clear();
    leatherCape.Resources.Add("DeerHide", 3, 2);
    leatherCape.Resources.Add("LeatherScraps", 3, 2);
    leatherCape.Resources.Add("FoxPelt_TW", 1, 0);
    leatherCape.Armor.DamageModifiers.Clear();
    leatherCape.Armor.DamageModifiers.Add(new()
    {
      m_type = CapeAndTorchResistanceChanges.Water,
      m_modifier = HitData.DamageModifier.Resistant,
    });

    // Troll
    var trollHelm = this.ItemManager["HelmetTrollLeather"];
    trollHelm.Resources.Clear();
    trollHelm.Resources.Add("TrollHide", 4, 2);
    trollHelm.Resources.Add("BoneFragments", 4, 2);
    trollHelm.Resources.Add("TrollBone_TW", 1, 0);
    trollHelm.Armor.ArmorBase = 2;
    trollHelm.Armor.ArmorPerLevel = 1;
    trollHelm.Armor.MovementModifier = VeryLight.MovementModifier.Helm;
    trollHelm.Armor.Weight = VeryLight.Weight.Helm;

    var trollChest = this.ItemManager["ArmorTrollLeatherChest"];
    trollChest.Resources.Clear();
    trollChest.Resources.Add("TrollHide", 8, 4);
    trollChest.Resources.Add("BoneFragments", 8, 4);
    trollChest.Resources.Add("TrollBone_TW", 1, 0);
    trollChest.Armor.ArmorBase = 6;
    trollChest.Armor.ArmorPerLevel = 3;
    trollChest.Armor.MovementModifier = VeryLight.MovementModifier.Chest;
    trollChest.Armor.Weight = VeryLight.Weight.Chest;

    var trollLegs = this.ItemManager["ArmorTrollLeatherLegs"];
    trollLegs.Resources.Clear();
    trollLegs.Resources.Add("TrollHide", 6, 3);
    trollLegs.Resources.Add("BoneFragments", 6, 3);
    trollLegs.Resources.Add("TrollBone_TW", 1, 0);
    trollLegs.Armor.ArmorBase = 4;
    trollLegs.Armor.ArmorPerLevel = 2;
    trollLegs.Armor.MovementModifier = VeryLight.MovementModifier.Legs;
    trollLegs.Armor.Weight = VeryLight.Weight.Legs;

    trollHelm.Set.Size = 3;
    trollChest.Set = trollHelm.Set;
    trollLegs.Set = trollHelm.Set;

    var trollCape = this.ItemManager["CapeTrollHide"];
    trollCape.Resources.Clear();
    trollCape.Resources.Add("TrollHide", 8, 3);
    trollCape.Resources.Add("BoneFragments", 8, 3);
    trollCape.Resources.Add("TrollBone_TW", 2, 1);
    trollCape.Set.Effect = null;
    trollCape.Set.Name = string.Empty;
    trollCape.Set.Size = 0;
    trollCape.Armor.DamageModifiers.Clear();
    trollCape.Armor.DamageModifiers.Add(new()
    {
      m_type = CapeAndTorchResistanceChanges.Water,
      m_modifier = HitData.DamageModifier.Resistant,
    });
    trollCape.Armor.DamageModifiers.Add(new()
    {
      m_type = CapeAndTorchResistanceChanges.Cold,
      m_modifier = HitData.DamageModifier.Resistant,
    });

    // Bronze
    var bronzeHelm = this.ItemManager["HelmetBronze"];
    bronzeHelm.Resources.Clear();
    bronzeHelm.Resources.Add("Bronze", 2, 1);
    bronzeHelm.Resources.Add("DeerHide", 2, 1);
    bronzeHelm.Armor.ArmorBase = 4;
    bronzeHelm.Armor.ArmorPerLevel = 2;
    bronzeHelm.Armor.MovementModifier = Normal.MovementModifier.Helm;
    bronzeHelm.Armor.Weight = Normal.Weight.Helm;

    var bronzeChest = this.ItemManager["ArmorBronzeChest"];
    bronzeChest.Resources.Clear();
    bronzeChest.Resources.Add("Bronze", 6, 4);
    bronzeChest.Resources.Add("DeerHide", 6, 4);
    bronzeChest.Armor.ArmorBase = 12;
    bronzeChest.Armor.ArmorPerLevel = 3;
    bronzeChest.Armor.MovementModifier = Normal.MovementModifier.Chest;
    bronzeChest.Armor.Weight = Normal.Weight.Chest;

    var bronzeLegs = this.ItemManager["ArmorBronzeLegs"];
    bronzeLegs.Resources.Clear();
    bronzeLegs.Resources.Add("Bronze", 4, 2);
    bronzeLegs.Resources.Add("DeerHide", 4, 2);
    bronzeLegs.Armor.ArmorBase = 8;
    bronzeLegs.Armor.ArmorPerLevel = 3;
    bronzeLegs.Armor.MovementModifier = Normal.MovementModifier.Legs;
    bronzeLegs.Armor.Weight = Normal.Weight.Legs;

    // Root
    var rootHelm = this.ItemManager["HelmetRoot"];
    rootHelm.Resources.Clear();
    rootHelm.Resources.Add("Root", 4, 2);
    rootHelm.Resources.Add("ElderBark", 6, 3);
    rootHelm.Resources.Add("RottenPelt_TW", 2, 1);
    rootHelm.Armor.ArmorBase = 3;
    rootHelm.Armor.ArmorPerLevel = 2;
    rootHelm.Armor.MovementModifier = SemiLight.MovementModifier.Helm;
    rootHelm.Armor.Weight = SemiLight.Weight.Helm;
    rootHelm.Armor.DamageModifiers.Clear();
    rootHelm.Armor.DamageModifiers.Add(new()
    {
      m_type = HitData.DamageType.Fire,
      m_modifier = HitData.DamageModifier.Weak,
    });

    var rootChest = this.ItemManager["ArmorRootChest"];
    rootChest.Resources.Clear();
    rootChest.Resources.Add("Root", 8, 4);
    rootChest.Resources.Add("ElderBark", 16, 8);
    rootChest.Resources.Add("RottenPelt_TW", 4, 2);
    rootChest.Armor.ArmorBase = 11;
    rootChest.Armor.ArmorPerLevel = 3;
    rootChest.Armor.MovementModifier = SemiLight.MovementModifier.Chest;
    rootChest.Armor.Weight = SemiLight.Weight.Chest;
    rootChest.Armor.DamageModifiers.Clear();
    rootChest.Armor.DamageModifiers.Add(new()
    {
      m_type = HitData.DamageType.Fire,
      m_modifier = HitData.DamageModifier.Weak,
    });

    var rootLegs = this.ItemManager["ArmorRootLegs"];
    rootLegs.Resources.Clear();
    rootLegs.Resources.Add("Root", 6, 3);
    rootLegs.Resources.Add("ElderBark", 12, 6);
    rootLegs.Resources.Add("RottenPelt_TW", 2, 1);
    rootLegs.Armor.ArmorBase = 7;
    rootLegs.Armor.ArmorPerLevel = 3;
    rootLegs.Armor.MovementModifier = SemiLight.MovementModifier.Legs;
    rootLegs.Armor.Weight = SemiLight.Weight.Legs;
    rootLegs.Armor.DamageModifiers.Clear();
    rootLegs.Armor.DamageModifiers.Add(new()
    {
      m_type = HitData.DamageType.Fire,
      m_modifier = HitData.DamageModifier.Weak,
    });

    var rootSetEffect = rootHelm.Set.Effect;
    rootSetEffect.m_mods.Clear();
    rootSetEffect.m_mods.Add(new()
    {
      m_type = HitData.DamageType.Poison,
      m_modifier = HitData.DamageModifier.Resistant,
    });

    rootChest.Set = rootHelm.Set;
    rootLegs.Set = rootHelm.Set;

    // Iron
    var ironHelm = this.ItemManager["HelmetIron"];
    ironHelm.Resources.Clear();
    ironHelm.Resources.Add("Iron", 10, 2);
    ironHelm.Resources.Add("LeatherScraps", 2, 1);
    ironHelm.Armor.ArmorBase = 7;
    ironHelm.Armor.ArmorPerLevel = 2;
    ironHelm.Armor.MovementModifier = Normal.MovementModifier.Helm;
    ironHelm.Armor.Weight = Normal.Weight.Helm;

    var ironChest = this.ItemManager["ArmorIronChest"];
    ironChest.Resources.Clear();
    ironChest.Resources.Add("Iron", 30, 8);
    ironChest.Resources.Add("LeatherScraps", 4, 2);
    ironChest.Resources.Add("Chain", 2, 0);
    ironChest.Armor.ArmorBase = 21;
    ironChest.Armor.ArmorPerLevel = 3;
    ironChest.Armor.MovementModifier = Normal.MovementModifier.Chest;
    ironChest.Armor.Weight = Normal.Weight.Chest;

    var ironLegs = this.ItemManager["ArmorIronLegs"];
    ironLegs.Resources.Clear();
    ironLegs.Resources.Add("Iron", 20, 5);
    ironLegs.Resources.Add("LeatherScraps", 2, 1);
    ironLegs.Armor.ArmorBase = 14;
    ironLegs.Armor.ArmorPerLevel = 3;
    ironLegs.Armor.MovementModifier = Normal.MovementModifier.Legs;
    ironLegs.Armor.Weight = Normal.Weight.Legs;

    // Fenris
    var fenrisHelm = this.ItemManager["HelmetFenring"];
    fenrisHelm.Resources.Clear();
    fenrisHelm.Resources.Add("WolfHairBundle", 10, 2);
    fenrisHelm.Resources.Add("WolfPelt", 2, 1);
    fenrisHelm.Resources.Add("LeatherScraps", 2, 1);
    fenrisHelm.Resources.Add("TrophyCultist", 1, 0);
    fenrisHelm.Armor.ArmorBase = 5;
    fenrisHelm.Armor.ArmorPerLevel = 2;
    fenrisHelm.Armor.MovementModifier = VeryLight.MovementModifier.Helm;
    fenrisHelm.Armor.Weight = VeryLight.Weight.Helm;

    var fenrisChest = this.ItemManager["ArmorFenringChest"];
    fenrisChest.Resources.Clear();
    fenrisChest.Resources.Add("WolfHairBundle", 30, 8);
    fenrisChest.Resources.Add("WolfPelt", 6, 3);
    fenrisChest.Resources.Add("LeatherScraps", 4, 2);
    fenrisChest.Armor.ArmorBase = 15;
    fenrisChest.Armor.ArmorPerLevel = 3;
    fenrisChest.Armor.MovementModifier = VeryLight.MovementModifier.Chest;
    fenrisChest.Armor.Weight = VeryLight.Weight.Chest;
    fenrisChest.Armor.DamageModifiers.Clear();

    var fenrisLegs = this.ItemManager["ArmorFenringLegs"];
    fenrisLegs.Resources.Clear();
    fenrisLegs.Resources.Add("WolfHairBundle", 20, 5);
    fenrisLegs.Resources.Add("WolfPelt", 4, 2);
    fenrisLegs.Resources.Add("LeatherScraps", 2, 1);
    fenrisLegs.Armor.ArmorBase = 10;
    fenrisLegs.Armor.ArmorPerLevel = 3;
    fenrisLegs.Armor.MovementModifier = VeryLight.MovementModifier.Legs;
    fenrisLegs.Armor.Weight = VeryLight.Weight.Legs;

    var fenrisSetEffect = fenrisHelm.Set.Effect;
    fenrisSetEffect.m_speedModifier = 0.1f - (VeryLight.MovementModifier.Helm + VeryLight.MovementModifier.Chest + VeryLight.MovementModifier.Legs);
    fenrisSetEffect.m_mods.Clear();
    fenrisSetEffect.m_mods.Add(new()
    {
      m_type = HitData.DamageType.Fire,
      m_modifier = HitData.DamageModifier.Resistant,
    });

    fenrisChest.Set = fenrisHelm.Set;
    fenrisLegs.Set = fenrisHelm.Set;

    // Wolf
    var wolfHelm = this.ItemManager["HelmetDrake"];
    wolfHelm.Resources.Clear();
    wolfHelm.Resources.Add("Silver", 10, 2);
    wolfHelm.Resources.Add("WolfPelt", 2, 1);
    wolfHelm.Resources.Add("WolfFang", 1, 1);
    wolfHelm.Resources.Add("TrophyHatchling", 2, 0);
    wolfHelm.Armor.ArmorBase = 10;
    wolfHelm.Armor.ArmorPerLevel = 2;
    wolfHelm.Armor.MovementModifier = Normal.MovementModifier.Helm;
    wolfHelm.Armor.Weight = Normal.Weight.Helm;

    var wolfChest = this.ItemManager["ArmorWolfChest"];
    wolfChest.Resources.Clear();
    wolfChest.Resources.Add("Silver", 30, 8);
    wolfChest.Resources.Add("WolfPelt", 6, 3);
    wolfChest.Resources.Add("WolfFang", 2, 2);
    wolfChest.Resources.Add("Chain", 5, 0);
    wolfChest.Armor.ArmorBase = 30;
    wolfChest.Armor.ArmorPerLevel = 3;
    wolfChest.Armor.MovementModifier = Normal.MovementModifier.Chest;
    wolfChest.Armor.Weight = Normal.Weight.Chest;
    wolfChest.Armor.DamageModifiers.Clear();

    var wolfLegs = this.ItemManager["ArmorWolfLegs"];
    wolfLegs.Resources.Clear();
    wolfLegs.Resources.Add("Silver", 20, 5);
    wolfLegs.Resources.Add("WolfPelt", 4, 2);
    wolfLegs.Resources.Add("WolfFang", 1, 1);
    wolfLegs.Armor.ArmorBase = 20;
    wolfLegs.Armor.ArmorPerLevel = 3;
    wolfLegs.Armor.MovementModifier = Normal.MovementModifier.Legs;
    wolfLegs.Armor.Weight = Normal.Weight.Legs;

    var wolfSetEffect = ScriptableObject.CreateInstance<SE_Stats>();
    wolfSetEffect.m_name = "$Vanilla_WolfSet_Effect_Name";
    wolfSetEffect.m_tooltip = "$Vanilla_WolfSet_Effect_Tooltip";
    wolfSetEffect.m_icon = wolfChest.Icon;
    wolfSetEffect.m_mods.Add(new()
    {
      m_type = CapeAndTorchResistanceChanges.Cold,
      m_modifier = HitData.DamageModifier.VeryResistant,
    });

    wolfHelm.Set.Effect = wolfSetEffect;
    wolfHelm.Set.Name = "Wolf";
    wolfHelm.Set.Size = 3;
    wolfChest.Set = wolfHelm.Set;
    wolfLegs.Set = wolfHelm.Set;

    var wolfCape = this.ItemManager["CapeWolf"];
    wolfCape.Resources.Clear();
    wolfCape.Resources.Add("WolfPelt", 8, 4);
    wolfCape.Resources.Add("Silver", 4, 4);
    wolfCape.Resources.Add("TrophyWolf", 1, 1);
    wolfCape.Armor.DamageModifiers.Clear();
    wolfCape.Armor.DamageModifiers.Add(new()
    {
      m_type = CapeAndTorchResistanceChanges.Cold,
      m_modifier = HitData.DamageModifier.VeryResistant,
    });

    // Padded
    var paddedHelm = this.ItemManager["HelmetPadded"];
    paddedHelm.Resources.Clear();
    paddedHelm.Resources.Add("Iron", 10, 3);
    paddedHelm.Resources.Add("LinenThread", 10, 5);
    paddedHelm.Armor.ArmorBase = 13;
    paddedHelm.Armor.ArmorPerLevel = 3;
    paddedHelm.Armor.MovementModifier = Normal.MovementModifier.Helm;
    paddedHelm.Armor.Weight = Normal.Weight.Helm;

    var paddedChest = this.ItemManager["ArmorPaddedCuirass"];
    paddedChest.Resources.Clear();
    paddedChest.Resources.Add("Iron", 15, 8);
    paddedChest.Resources.Add("LinenThread", 30, 15);
    paddedChest.Armor.ArmorBase = 39;
    paddedChest.Armor.ArmorPerLevel = 4;
    paddedChest.Armor.MovementModifier = Normal.MovementModifier.Chest;
    paddedChest.Armor.Weight = Normal.Weight.Chest;

    var paddedLegs = this.ItemManager["ArmorPaddedGreaves"];
    paddedLegs.Resources.Clear();
    paddedLegs.Resources.Add("Iron", 10, 5);
    paddedLegs.Resources.Add("LinenThread", 20, 10);
    paddedLegs.Armor.ArmorBase = 26;
    paddedLegs.Armor.ArmorPerLevel = 3;
    paddedLegs.Armor.MovementModifier = Normal.MovementModifier.Legs;
    paddedLegs.Armor.Weight = Normal.Weight.Legs;

    // Plains capes
    var loxCape = this.ItemManager["CapeLox"];
    loxCape.Resources.Clear();
    loxCape.Resources.Add("LoxPelt", 6, 3);
    loxCape.Resources.Add("Silver", 6, 6);
    loxCape.Resources.Add("LoxBone_TW", 2, 1);
    loxCape.Armor.DamageModifiers.Clear();
    loxCape.Armor.DamageModifiers.Add(new()
    {
      m_type = CapeAndTorchResistanceChanges.Cold,
      m_modifier = HitData.DamageModifier.Immune,
    });

    var linenCape = this.ItemManager["CapeLinen"];
    linenCape.Armor.DamageModifiers.Clear();
    linenCape.Armor.DamageModifiers.Add(new()
    {
      m_type = CapeAndTorchResistanceChanges.Water,
      m_modifier = HitData.DamageModifier.VeryResistant,
    });
    linenCape.Armor.DamageModifiers.Add(new()
    {
      m_type = CapeAndTorchResistanceChanges.Cold,
      m_modifier = HitData.DamageModifier.Resistant,
    });

    // Eitr-weave
    var mageHelm = this.ItemManager["HelmetMage"];
    mageHelm.Resources.Clear();
    mageHelm.Resources.Add("LinenThread", 10, 5);
    mageHelm.Resources.Add("Eitr", 15, 5);
    mageHelm.Resources.Add("JuteRed", 4, 0);
    mageHelm.Armor.ArmorBase = 7;
    mageHelm.Armor.ArmorPerLevel = 2;
    mageHelm.Armor.MovementModifier = SemiLight.MovementModifier.Helm; // mage robes are annoying for running lmao
    mageHelm.Armor.Weight = VeryLight.Weight.Helm;
    mageHelm.Armor.EitrRegenModifier = 0.2f;

    var mageChest = this.ItemManager["ArmorMageChest"];
    mageChest.Resources.Clear();
    mageChest.Resources.Add("LinenThread", 30, 15);
    mageChest.Resources.Add("Eitr", 20, 5);
    mageChest.Resources.Add("ScaleHide", 4, 2);
    mageChest.Resources.Add("Feathers", 10, 0);
    mageChest.Armor.ArmorBase = 21;
    mageChest.Armor.ArmorPerLevel = 3;
    mageChest.Armor.MovementModifier = SemiLight.MovementModifier.Chest; // mage robes are annoying for running lmao
    mageChest.Armor.Weight = VeryLight.Weight.Chest;
    mageChest.Armor.EitrRegenModifier = 0.5f;

    var mageLegs = this.ItemManager["ArmorMageLegs"];
    mageLegs.Resources.Clear();
    mageLegs.Resources.Add("LinenThread", 20, 10);
    mageLegs.Resources.Add("Eitr", 20, 5);
    mageLegs.Resources.Add("ScaleHide", 10, 5);
    mageLegs.Resources.Add("JuteRed", 6, 0);
    mageLegs.Armor.ArmorBase = 14;
    mageLegs.Armor.ArmorPerLevel = 3;
    mageLegs.Armor.MovementModifier = SemiLight.MovementModifier.Legs; // mage robes are annoying for running lmao
    mageLegs.Armor.Weight = VeryLight.Weight.Legs;
    mageLegs.Armor.EitrRegenModifier = 0.3f;

    var featherCape = this.ItemManager["CapeFeather"];
    featherCape.Armor.DamageModifiers.Clear();
    featherCape.Armor.DamageModifiers.Add(new()
    {
      m_type = HitData.DamageType.Fire,
      m_modifier = HitData.DamageModifier.Weak,
    });

    // Carapace
    var carapaceHelm = this.ItemManager["HelmetCarapace"];
    carapaceHelm.Resources.Clear();
    carapaceHelm.Resources.Add("Carapace", 10, 5);
    carapaceHelm.Resources.Add("ScaleHide", 2, 1);
    carapaceHelm.Resources.Add("Eitr", 4, 2);
    carapaceHelm.Resources.Add("Mandible", 2, 1);
    carapaceHelm.Armor.ArmorBase = 16;
    carapaceHelm.Armor.ArmorPerLevel = 3;
    carapaceHelm.Armor.MovementModifier = Normal.MovementModifier.Helm;
    carapaceHelm.Armor.Weight = Normal.Weight.Helm;

    var carapaceChest = this.ItemManager["ArmorCarapaceChest"];
    carapaceChest.Resources.Clear();
    carapaceChest.Resources.Add("Carapace", 30, 15);
    carapaceChest.Resources.Add("ScaleHide", 4, 2);
    carapaceChest.Resources.Add("Eitr", 4, 2);
    carapaceChest.Resources.Add("Iron", 12, 3);
    carapaceChest.Armor.ArmorBase = 48;
    carapaceChest.Armor.ArmorPerLevel = 4;
    carapaceChest.Armor.MovementModifier = Normal.MovementModifier.Chest;
    carapaceChest.Armor.Weight = Normal.Weight.Chest;

    var carapaceLegs = this.ItemManager["ArmorCarapaceLegs"];
    carapaceLegs.Resources.Clear();
    carapaceLegs.Resources.Add("Carapace", 20, 10);
    carapaceLegs.Resources.Add("ScaleHide", 3, 1);
    carapaceLegs.Resources.Add("Eitr", 4, 2);
    carapaceLegs.Resources.Add("Iron", 12, 3);
    carapaceLegs.Armor.ArmorBase = 32;
    carapaceLegs.Armor.ArmorPerLevel = 3;
    carapaceLegs.Armor.MovementModifier = Normal.MovementModifier.Legs;
    carapaceLegs.Armor.Weight = Normal.Weight.Legs;
  }
}
