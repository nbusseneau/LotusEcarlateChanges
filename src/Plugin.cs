using System.Collections.Generic;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Jotunn.Utils;
using LotusEcarlateChanges.Changes.JotunnBased;
using LotusEcarlateChanges.Changes.Manual;
using LotusEcarlateChanges.Changes.StandaloneManagerBased;
using LotusEcarlateChanges.Model.Changes;

namespace LotusEcarlateChanges;

[BepInPlugin(ModGUID, ModName, ModVersion)]
[BepInDependency("balrond.astafaraios.BalrondContainers", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency("balrond.astafaraios.BalrondHumanoidRandomizer", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency("balrond.astafaraios.BalrondShipyard", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency("blacks7ar.ClayBuildPieces", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency("blacks7ar.CoreWoodPieces", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency("blacks7ar.DarkWoodFurnitures", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency("blacks7ar.FineWoodBuildPieces", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency("blacks7ar.FineWoodFurnitures", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency("blacks7ar.RefinedStonePieces", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency("blacks7ar.SimpleElevators", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency("com.orianaventure.mod.WorldAdvancementProgression", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency("com.plumga.Clutter", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency("fall_damage_for_creatures", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency("goldenrevolver.CapeAndTorchResistanceChanges", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency("neobotics.valheim_mod.maxaxe", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency("nex.SpeedyPaths", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency("shudnal.MoreGatesExtended", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency("southsil.SouthsilArmor", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency("Therzie.Monstrum", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency("Therzie.Warfare", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency(Jotunn.Main.ModGuid, BepInDependency.DependencyFlags.HardDependency)]
[NetworkCompatibility(CompatibilityLevel.ClientMustHaveMod, VersionStrictness.Minor)]
public class Plugin : BaseUnityPlugin
{
  public const string ModGUID = "nbusseneau.LotusEcarlateChanges";
  private const string ModName = "LotusEcarlateChanges";
  private const string ModVersion = "0.7.4";

  public static new ManualLogSource Logger { get; private set; }
  public static Harmony Harmony { get; } = new(ModGUID);

  public void Awake()
  {
    Logger = base.Logger;

    List<IChanges> changesList = [
      // Jotunn-based changes
      new Clutter(),
      new CustomSkills(),
      new MoreGates(),

      // Standalone manager-based changes
      new ClayBuildPieces(),
      new CoreWoodPieces(),
      new DarkWoodFurnitures(),
      new FineWoodBuildPieces(),
      new FineWoodFurnitures(),
      new Monstrum(),
      new RefinedStonePieces(),
      new SimpleElevators(),
      new SouthsilArmor(),
      new Warfare(),

      // Manual changes
      new BalrondContainers(),
      new BalrondHumanoidRandomizer(),
      new BalrondShipyard(),
      new CapeAndTorchResistanceChanges(),
      new CustomKeyHints(),
      new FallDamageForCreatures(),
      new Lightsources(),
      new SpeedyPaths(),
      new Tutorials(),
      new VanillaMisc(),
      new VanillaArmors(),
      new VanillaWeapons(),
      new WorldAdvancementProgression(),
    ];

    changesList.ForEach(changes => changes.Apply());
  }
}
