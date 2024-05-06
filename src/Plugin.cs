using System.Collections.Generic;
using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Jotunn.Utils;
using LocalizationManager;
using LotusEcarlateChanges.Changes;
using LotusEcarlateChanges.Model;

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
[BepInDependency("redseiko.valheim.potterybarn", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency("Soloredis.RtDBiomes", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency("southsil.SouthsilArmor", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency("Therzie.Monstrum", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency("Therzie.Warfare", BepInDependency.DependencyFlags.HardDependency)]
[BepInDependency(Jotunn.Main.ModGuid, BepInDependency.DependencyFlags.HardDependency)]
[NetworkCompatibility(CompatibilityLevel.ClientMustHaveMod, VersionStrictness.Minor)]
public class Plugin : BaseUnityPlugin
{
  private const string ModGUID = "nbusseneau.LotusEcarlateChanges";
  private const string ModName = "LotusEcarlateChanges";
  private const string ModVersion = "0.5.0";

  public static new ManualLogSource Logger;
  public static Harmony Harmony;

  public void Awake()
  {
    Localizer.Load();
    Logger = base.Logger;

    List<IChanges> patches = [
      // Reflection patches
      new Backpacks(),
      new CapeAndTorchResistanceChanges(),
      new ClayBuildPieces(),
      new CoreWoodPieces(),
      new FallDamageForCreatures(),
      new FineWoodBuildPieces(),
      new MonsterLabZ(),
      new Monstrum(),
      new SouthsilArmor(),
      new Warfare(),

      // Manual patches
      new BalrondShipyard(),
      new Clutter(),
      new MoreGates(),
      new PotteryBarn(),
      new RtDBiomes(),
      new Vanilla(),
      new VanillaArmors(),
    ];

    Harmony = new(ModGUID);
    patches.ForEach(patch => patch.Apply());
    var assembly = Assembly.GetExecutingAssembly();
    Harmony.PatchAll(assembly);
  }

  public void OnDestroy() => Config.Save();
}
