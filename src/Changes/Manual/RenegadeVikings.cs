extern alias RenegadeVikings;

using System;
using System.Collections.Generic;
using HarmonyLib;
using LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes;
using LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes.Overlords;
using LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Tiers;
using LotusEcarlateChanges.Model.Changes;
using LotusEcarlateChanges.Model.Managers.Manual;
using LotusEcarlateChanges.Extensions;
using RenegadeVikings::RenegadeVikings.Functions;
using RenegadeVikings::RenegadeVikings.VikingsData;
using UnityEngine;

namespace LotusEcarlateChanges.Changes.Manual;

public class RenegadeVikings : ManualChangesBase
{
  public static System.Random Random { get; } = new();
  private static ItemManager s_itemManager;
  private const string HasBeenOverridenZDOKey = $"{Plugin.ModGUID}.RenegadeVikingsOverride";

  protected override void ApplyInternal()
  {
    s_itemManager = this.ItemManager;

    // Custom patches
    var patches = new Dictionary<(Type Type, string OriginalName), (string PrefixName, string PostfixName)>()
    {
      [(typeof(RenegadeSetup), nameof(RenegadeSetup.Awake))] = (nameof(RenegadeSetupPrefilters), nameof(SetRenegadesNames)),
      [(typeof(RenegadeSetup), nameof(RenegadeSetup.SetupVisuals))] = (null, nameof(FixNeutralsMaleNames)),
      [(typeof(RenegadeSetup), nameof(RenegadeSetup.SetupEquipment))] = (nameof(InterceptNeutralsSetupEquipment), null),
      [(typeof(SetupEquipments), nameof(SetupEquipments.FireStaffAdjustments))] = (null, nameof(RebalanceFireStaffDamage)),
      [(typeof(SetupEquipments), nameof(SetupEquipments.IceStaffAdjustments))] = (null, nameof(RebalanceIceStaffDamage)),

      [(typeof(RenegadeSetup), nameof(RenegadeSetup.SetupNeutralWeapons))] = (nameof(NoOpPrefix), null),
      [(typeof(RenegadeSetup), nameof(RenegadeSetup.Tier1Equipment))] = (nameof(NoOpPrefix), null),
      [(typeof(RenegadeSetup), nameof(RenegadeSetup.Tier2Equipment))] = (nameof(NoOpPrefix), null),
      [(typeof(RenegadeSetup), nameof(RenegadeSetup.Tier3Equipment))] = (nameof(NoOpPrefix), null),
      [(typeof(RenegadeSetup), nameof(RenegadeSetup.Tier4Equipment))] = (nameof(NoOpPrefix), null),
      [(typeof(RenegadeSetup), nameof(RenegadeSetup.Tier5Equipment))] = (nameof(NoOpPrefix), null),
      [(typeof(RenegadeSetup), nameof(RenegadeSetup.Tier6EquipmentMelee))] = (nameof(NoOpPrefix), null),
      [(typeof(RenegadeSetup), nameof(RenegadeSetup.Tier6EquipmentMagic))] = (nameof(NoOpPrefix), null),
      [(typeof(RenegadeSetup), nameof(RenegadeSetup.Tier6EquipmentSummoner))] = (nameof(NoOpPrefix), null),
      [(typeof(RenegadeVikingT1), nameof(RenegadeVikingT1.SetDropList))] = (nameof(NoOpPrefix), null),
      [(typeof(RenegadeVikingT2), nameof(RenegadeVikingT2.SetDropList))] = (nameof(NoOpPrefix), null),
      [(typeof(RenegadeVikingT3), nameof(RenegadeVikingT3.SetDropList))] = (nameof(NoOpPrefix), null),
      [(typeof(RenegadeVikingT4), nameof(RenegadeVikingT4.SetDropList))] = (nameof(NoOpPrefix), null),
      [(typeof(RenegadeVikingT5), nameof(RenegadeVikingT5.SetDropList))] = (nameof(NoOpPrefix), null),
      [(typeof(RenegadeVikingT6Melee), nameof(RenegadeVikingT6Melee.SetDropList))] = (nameof(NoOpPrefix), null),
      [(typeof(RenegadeVikingT6Magic), nameof(RenegadeVikingT6Magic.SetDropList))] = (nameof(NoOpPrefix), null),
      [(typeof(OverlordVikingT1), nameof(OverlordVikingT1.SetDropList))] = (nameof(NoOpPrefix), null),
      [(typeof(OverlordVikingT2), nameof(OverlordVikingT2.SetDropList))] = (nameof(NoOpPrefix), null),
      [(typeof(OverlordVikingT3), nameof(OverlordVikingT3.SetDropList))] = (nameof(NoOpPrefix), null),
      [(typeof(OverlordVikingT4), nameof(OverlordVikingT4.SetDropList))] = (nameof(NoOpPrefix), null),
      [(typeof(OverlordVikingT5), nameof(OverlordVikingT5.SetDropList))] = (nameof(NoOpPrefix), null),
      [(typeof(OverlordVikingT6), nameof(OverlordVikingT6.SetDropList))] = (nameof(NoOpPrefix), null),
      [(typeof(OverlordVikingT6Summoner), nameof(OverlordVikingT6Summoner.SetDropList))] = (nameof(NoOpPrefix), null),
    };
    foreach (var ((type, originalName), (prefixName, postfixName)) in patches)
    {
      var original = AccessTools.Method(type, originalName);
      var prefix = string.IsNullOrEmpty(prefixName) ? null : new HarmonyMethod(this.GetType(), prefixName);
      var postfix = string.IsNullOrEmpty(postfixName) ? null : new HarmonyMethod(this.GetType(), postfixName);
      Plugin.Harmony.Patch(original, prefix, postfix);
    }
  }

  private static void NoOpPrefix(ref bool __runOriginal) => __runOriginal = false;

  private static void RenegadeSetupPrefilters(RenegadeSetup __instance)
  {
    RemoveTameable(__instance);
    OverrideEquipmentAndDrops(__instance);
  }

  private static void RemoveTameable(RenegadeSetup __instance)
  {
    if (__instance.gameObject.GetComponent<Tameable>() is { } tameable) GameObject.Destroy(tameable);
    if (__instance.gameObject.GetComponent<TamedFix>() is { } tamedFix) GameObject.Destroy(tamedFix);
  }

  private static readonly Dictionary<string, ITier> renegadesTiers = new()
  {
    ["T1Vikings"] = Meadows.Instance,
    ["T2Vikings"] = BlackForest.Instance,
    ["T3Vikings"] = Swamp.Instance,
    ["T4Vikings"] = Mountain.Instance,
    ["T5Vikings"] = Plains.Instance,
    ["T6VikingsMelee"] = Mistlands.Instance,
    ["T6VikingsMagic"] = MistlandsMage.Instance,
  };

  private static readonly Dictionary<string, ITier> overlordsTiers = new()
  {
    ["OverlordVikingT1"] = BlackForest.Instance,
    ["OverlordVikingT2"] = Swamp.Instance,
    ["OverlordVikingT3"] = Mountain.Instance,
    ["OverlordVikingT4"] = Plains.Instance,
    ["OverlordVikingT5"] = MistlandsMage.Instance,
    ["OverlordVikingT6"] = Mistlands.Instance,
  };

  private static readonly Dictionary<string, IArchetype> overlordsArchetypes = new()
  {
    ["OverlordVikingT1"] = MeadowsOverlord.Instance,
    ["OverlordVikingT2"] = BlackForestOverlord.Instance,
    ["OverlordVikingT3"] = SwampOverlord.Instance,
    ["OverlordVikingT4"] = MountainOverlord.Instance,
    ["OverlordVikingT5"] = PlainsOverlord.Instance,
    ["OverlordVikingT6"] = MistlandsOverlord.Instance,
  };

  private static void OverrideEquipmentAndDrops(RenegadeSetup __instance)
  {
    var nView = __instance.GetComponent<ZNetView>();
    if (nView.GetZDO().GetBool(HasBeenOverridenZDOKey)) return;
    var humanoid = __instance.GetComponent<Humanoid>();

    // Renegade vikings
    if (renegadesTiers.TryGetValue(humanoid.m_group, out var renegadeTier))
    {
      humanoid.m_randomWeapon = renegadeTier.Weapons;
      humanoid.m_randomShield = renegadeTier.Shields;
      humanoid.m_randomSets = renegadeTier.Sets;
      __instance.GetComponent<CharacterDrop>().m_drops = renegadeTier.RandomArchetype.Drops;
      // AND THEN WE DOUBLED IT
      var maxHealth = humanoid.GetMaxHealth();
      humanoid.SetMaxHealth(maxHealth * 2);
      humanoid.SetHealth(maxHealth * 2);
    }

    // Overlords, except OverlordVikingT6Summoner
    else if (overlordsTiers.TryGetValue(humanoid.m_group, out var overlordTier))
    {
      humanoid.m_randomWeapon = overlordTier.Weapons;
      humanoid.m_randomShield = overlordTier.Shields;
      humanoid.m_randomSets = overlordTier.Sets;
      __instance.GetComponent<CharacterDrop>().m_drops = overlordsArchetypes[humanoid.m_group].Drops;
    }

    // OverlordVikingT6Summoner
    else if (humanoid.m_group == "OverlordVikingT6Summoner")
    {
      humanoid.m_defaultItems = MistlandsSummoner.Instance.Weapons;
      humanoid.m_randomSets = MistlandsSummoner.Instance.Sets;
      __instance.GetComponent<CharacterDrop>().m_drops = MistlandsOverlord.Instance.Drops;
    }

    // Neutral vikings
    else if (humanoid.m_group == "NeutralVikings")
    {
      humanoid.m_randomWeapon = BlackForest.Instance.Weapons;
      humanoid.m_randomShield = BlackForest.Instance.Shields;
      humanoid.m_randomSets = [.. Meadows.Instance.Sets, .. BlackForest.Instance.Sets];
    }

    nView.GetZDO().Set(HasBeenOverridenZDOKey, true);
  }

  private static void SetRenegadesNames(RenegadeSetup __instance)
  {
    if (__instance.m_humanoid.m_group == "NeutralVikings" || __instance.m_humanoid.m_group == "TraderVikings" || __instance.m_humanoid.m_group.StartsWith("Overlord")) return;
    var name = __instance.m_nview.GetZDO().GetString(__instance.m_vikingName);
    if (string.IsNullOrEmpty(name))
    {
      var isMale = __instance.m_visEquipment.GetModelIndex() == 0;
      name = isMale ? __instance.m_nameM[Random.Next(__instance.m_nameM.Length)] : __instance.m_nameF[Random.Next(__instance.m_nameF.Length)];
      __instance.m_nview.GetZDO().Set(__instance.m_vikingName, name);
    }
    __instance.m_humanoid.m_name = name;
  }

  private static void FixNeutralsMaleNames(RenegadeSetup __instance)
  {
    var isMale = __instance.m_visEquipment.GetModelIndex() == 0;
    if (isMale)
    {
      var name = __instance.m_nview.GetZDO().GetString(__instance.m_vikingName);
      if (string.IsNullOrEmpty(name))
      {
        name = __instance.m_nameM[Random.Next(__instance.m_nameM.Length)];
        __instance.m_nview.GetZDO().Set(__instance.m_vikingName, name);
      }
    }
  }

  private static void InterceptNeutralsSetupEquipment(RenegadeSetup __instance, ref bool __runOriginal)
  {
    __runOriginal = __instance.m_humanoid.m_group != "NeutralVikings";
  }

  private static void RebalanceFireStaffDamage(ItemDrop item) => item.m_itemData.m_shared.m_damages.m_fire /= 2f;
  private static void RebalanceIceStaffDamage(ItemDrop item) => item.m_itemData.m_shared.m_damages.m_frost *= 2f;
}
