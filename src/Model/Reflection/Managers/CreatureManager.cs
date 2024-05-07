using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using UnityEngine;
using LotusEcarlateChanges.Extensions;
using LotusEcarlateChanges.Model.Reflection.Objects;

namespace LotusEcarlateChanges.Model.Reflection.Managers;

public class CreatureManager : ReflectionManagerBase<Creature>
{
  private readonly IList _registeredCreatures;
  private readonly List<GameObject> _prefabs;

  public CreatureManager(Assembly assembly, string assemblyNamespace = "CreatureManager") : base(assembly, assemblyNamespace)
  {
    var creatureType = assembly.GetType($"{assemblyNamespace}.Creature");
    var registeredCreaturesField = AccessTools.DeclaredField(creatureType, "registeredCreatures");
    this._registeredCreatures = (IList)registeredCreaturesField.GetValue(null);

    var creaturePrefabManagerType = assembly.GetType($"{assemblyNamespace}.PrefabManager");
    var prefabsField = AccessTools.DeclaredField(creaturePrefabManagerType, "prefabs");
    this._prefabs = (List<GameObject>)prefabsField.GetValue(null);

  }

  protected override object GetObjectFromStorage(string name) => this._registeredCreatures.FindObjectByPrefabName(name);
  protected override ICollection GetAllObjectsFromStorage() => this._registeredCreatures;

  public override void UnregisterToRemove(HashSet<string> toRemove)
  {
    this._registeredCreatures.RemoveAllPrefabs(toRemove);
    this._prefabs.RemoveAll(prefab => toRemove.Contains(prefab.name));
  }

  public override void UnregisterAllExceptToKeep(HashSet<string> toKeep)
  {
    this._registeredCreatures.RemoveAllExceptPrefabsToKeep(toKeep);
    this._prefabs.RemoveAll(prefab => !toKeep.Contains(prefab.name));
  }
}
