using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using UnityEngine;
using LotusEcarlateChanges.Extensions;
using LotusEcarlateChanges.Model.Reflection.Objects;

namespace LotusEcarlateChanges.Model.Reflection.Managers;

public class ItemManager : ReflectionManagerBase<Item>
{
  private readonly IList _registeredItems;
  private readonly List<GameObject> _prefabs;
  private readonly List<GameObject> _zNetOnlyPrefabs;

  public ItemManager(Assembly assembly, string assemblyNamespace = "ItemManager") : base(assembly, assemblyNamespace)
  {
    var itemType = assembly.GetType($"{assemblyNamespace}.Item");
    var itemPrefabManagerType = assembly.GetType($"{assemblyNamespace}.PrefabManager");

    var registeredItemsField = AccessTools.DeclaredField(itemType, "registeredItems");
    this._registeredItems = (IList)registeredItemsField.GetValue(null);

    var prefabsField = AccessTools.DeclaredField(itemPrefabManagerType, "prefabs");
    this._prefabs = (List<GameObject>)prefabsField.GetValue(null);

    var zNetOnlyPrefabsField = AccessTools.DeclaredField(itemPrefabManagerType, "ZnetOnlyPrefabs");
    this._zNetOnlyPrefabs = (List<GameObject>)zNetOnlyPrefabsField.GetValue(null);
  }

  protected override object GetObjectFromStorage(string name) => this._registeredItems.FindObjectByPrefabName(name);
  protected override ICollection GetAllObjectsFromStorage() => this._registeredItems;

  public override void UnregisterToRemove(HashSet<string> toRemove)
  {
    this._registeredItems.RemoveAllPrefabs(toRemove);
    this._prefabs.RemoveAll(prefab => toRemove.Contains(prefab.name));
    this._zNetOnlyPrefabs.RemoveAll(prefab => toRemove.Contains(prefab.name));
  }

  public override void UnregisterAllExceptToKeep(HashSet<string> toKeep)
  {
    this._registeredItems.RemoveAllExceptPrefabsToKeep(toKeep);
    this._prefabs.RemoveAll(prefab => !toKeep.Contains(prefab.name));
    this._zNetOnlyPrefabs.RemoveAll(prefab => !toKeep.Contains(prefab.name));
  }
}
