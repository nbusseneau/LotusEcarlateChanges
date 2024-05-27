extern alias CapeAndTorchResistanceChanges;

using CapeAndTorchResistanceChanges::CapeAndTorchResistanceChanges;
using static CapeAndTorchResistanceChanges::CapeAndTorchResistanceChanges.CapeAndTorchResistanceChangesPlugin;
using HarmonyLib;
using LotusEcarlateChanges.Model.Changes;

namespace LotusEcarlateChanges.Changes.Manual;

public class CapeAndTorchResistanceChanges : ManualChangesBase
{
  public static readonly HitData.DamageType Water = (HitData.DamageType)NewResistances.NewDamageTypes.Water;
  public static readonly HitData.DamageType Cold = (HitData.DamageType)NewResistances.NewDamageTypes.Cold;

  protected override void ApplyInternal()
  {
    // Enforce settings
    TeleportInstantlyUpdatesWeather.Value = TeleportChange.InstantlyUpdateWeatherAndClearWetAndColdDebuff;
    TeleportGrantsTemporaryWetAndColdImmunity.Value = false;
    EnableCapeChanges.Value = CapeChanges.Disabled;
    EnableTorchChanges.Value = TorchChanges.ResistanceChangesAndDurability;
    EnableTrollArmorSetBonusChange.Value = false;
    TrollCapeWaterResistance.Value = WaterResistance.ImmuneExceptSwimming;
    LoxCapeColdResistance.Value = ColdResistance.Immune;
  }
}
