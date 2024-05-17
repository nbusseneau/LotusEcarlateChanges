using System.Collections.Generic;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Jotunn.Utils;
using LocalizationManager;
using LotusEcarlateChanges.Changes.Jotunn;
using LotusEcarlateChanges.Changes.Manager;
using LotusEcarlateChanges.Changes.Manual;
using LotusEcarlateChanges.Model.Changes;

namespace LotusEcarlateChanges;

[BepInPlugin(ModGUID, ModName, ModVersion)]
[BepInDependency("balrond.astafaraios.BalrondShipyard", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency("blacks7ar.ClayBuildPieces", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency("blacks7ar.CoreWoodPieces", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency("blacks7ar.FineWoodBuildPieces", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency("com.drakemods.Moregates", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency("com.plumga.Clutter", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency("fall_damage_for_creatures", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency("goldenrevolver.CapeAndTorchResistanceChanges", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency("MonsterLabZ", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency("org.bepinex.plugins.backpacks", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency("southsil.SouthsilArmor", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency("Therzie.Monstrum", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency("Therzie.Warfare", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency(Jotunn.Main.ModGuid, BepInDependency.DependencyFlags.HardDependency)]
[NetworkCompatibility(CompatibilityLevel.ClientMustHaveMod, VersionStrictness.Minor)]
public class Plugin : BaseUnityPlugin
{
  private const string ModGUID = "nbusseneau.LotusEcarlateChanges";
  private const string ModName = "LotusEcarlateChanges";
  private const string ModVersion = "0.5.1";

  public static new ManualLogSource Logger;
  public static Harmony Harmony = new(ModGUID);

  public void Awake()
  {
    Localizer.Load();
    Logger = base.Logger;

    List<IChanges> changesList = [
      // Jotunn plugins
      new Clutter(),
      new MoreGates(),

      // Manager plugins
      new Backpacks(),
      new ClayBuildPieces(),
      new CoreWoodPieces(),
      new FineWoodBuildPieces(),
      new MonsterLabZ(),
      new Monstrum(),
      new SouthsilArmor(),
      new Warfare(),

      // Manual plugins
      new BalrondShipyard(),
      new CapeAndTorchResistanceChanges(),
      new FallDamageForCreatures(),
      new VanillaMisc(),
      new VanillaArmors(),
    ];

    changesList.ForEach(changes => changes.Apply());
  }
}
