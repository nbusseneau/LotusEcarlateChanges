extern alias SpeedyPaths;

using System;
using System.Linq;
using HarmonyLib;
using LotusEcarlateChanges.Model.Changes;
using SpeedyPaths::AuthoritativeConfig;
using static SpeedyPaths::SpeedyPaths.SpeedyPathsClientMod;

namespace LotusEcarlateChanges.Changes.Manual;

public class SpeedyPaths : ManualChangesBase
{
  protected override void ApplyInternal()
  {
    // Override all entries to ignore server authority
    foreach (var configEntry in Config.Instance._configEntries.Values) configEntry.ServerAuthoritative = false;

    // Buff thresholds
    _hudPosIconThresholds[0].Value = 1.00f;
    _hudPosIconThresholds[1].Value = 1.19f;

    // Speed modifiers
    _speedModifiers[GroundType.PathDirt].Value = 1.1f;
    _speedModifiers[GroundType.PathStone].Value = 1.2f;
    _speedModifiers[GroundType.Cultivated].Value = 1f;
    _speedModifiers[GroundType.StructureWood].Value = 1.1f;
    _speedModifiers[GroundType.StructureHardWood].Value = 1.1f;
    _speedModifiers[GroundType.StructureStone].Value = 1.2f;
    _speedModifiers[GroundType.StructureIron].Value = 1.2f;
    _speedModifiers[GroundType.StructureMarble].Value = 1.2f;

    // Stamina modifiers
    _staminaModifiers[GroundType.PathDirt].Value = 0.9f;
    _staminaModifiers[GroundType.PathStone].Value = 0.8f;
    _staminaModifiers[GroundType.Cultivated].Value = 1f;
    _staminaModifiers[GroundType.StructureWood].Value = 0.9f;
    _staminaModifiers[GroundType.StructureHardWood].Value = 0.9f;
    _staminaModifiers[GroundType.StructureStone].Value = 0.8f;
    _staminaModifiers[GroundType.StructureIron].Value = 0.8f;
    _staminaModifiers[GroundType.StructureMarble].Value = 0.8f;

    // Strings
    _groundTypeStrings[GroundType.PathDirt].Value = "$SpeedyPaths_PathDirt";
    _groundTypeStrings[GroundType.PathStone].Value = "$SpeedyPaths_PathStone";
    _groundTypeStrings[GroundType.Cultivated].Value = "$SpeedyPaths_Cultivated";
    _groundTypeStrings[GroundType.StructureWood].Value = "$SpeedyPaths_StructureWood";
    _groundTypeStrings[GroundType.StructureHardWood].Value = "$SpeedyPaths_StructureHardWood";
    _groundTypeStrings[GroundType.StructureStone].Value = "$SpeedyPaths_StructureStone";
    _groundTypeStrings[GroundType.StructureIron].Value = "$SpeedyPaths_StructureIron";
    _groundTypeStrings[GroundType.StructureMarble].Value = "$SpeedyPaths_StructureMarble";

    // Biome speed and stamina modifiers
    foreach (var biome in Enum.GetValues(typeof(Heightmap.Biome)).Cast<Heightmap.Biome>())
    {
      _untamedSpeedModifiers[biome].Value = 1f;
      _untamedStaminaModifiers[biome].Value = 1f;
    }

    // Custom patches to disable syncing
    Plugin.Harmony.Patch(
      AccessTools.Method(typeof(Config), nameof(Config.RegisterSyncConfigRPC)),
      prefix: new HarmonyMethod(this.GetType(), nameof(NoOpPrefix))
    );
    Plugin.Harmony.Patch(
      AccessTools.Method(typeof(Config), nameof(Config.RPC_SyncServerConfig)),
      prefix: new HarmonyMethod(this.GetType(), nameof(NoOpPrefix))
    );
    Plugin.Harmony.Patch(
      AccessTools.Method(typeof(Config), nameof(Config.RequestConfigFromServer)),
      prefix: new HarmonyMethod(this.GetType(), nameof(NoOpPrefix))
    );
  }

  private static void NoOpPrefix(ref bool __runOriginal) => __runOriginal = false;
}
