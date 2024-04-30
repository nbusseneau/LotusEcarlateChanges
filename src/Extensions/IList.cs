using System.Collections;
using System.Collections.Generic;
using HarmonyLib;
using UnityEngine;

namespace LotusEcarlateChanges.Extensions;

public static class IListExtensions
{
  public static void RemoveAllPrefabs(this IList list, HashSet<string> toRemove)
  {
    var itemsToRemove = new HashSet<object>();
    foreach (var item in list)
    {
      var prefab = (GameObject)AccessTools.Field(item.GetType(), "Prefab").GetValue(item);
      if (toRemove.Contains(prefab.name)) itemsToRemove.Add(item);
    }
    foreach (var item in itemsToRemove) list.Remove(item);
  }

  public static void RemoveAllExceptPrefabsToKeep(this IList list, HashSet<string> toKeep)
  {
    var itemsToRemove = new HashSet<object>();
    foreach (var item in list)
    {
      var prefab = (GameObject)AccessTools.Field(item.GetType(), "Prefab").GetValue(item);
      if (!toKeep.Contains(prefab.name)) itemsToRemove.Add(item);
    }
    foreach (var item in itemsToRemove) list.Remove(item);
  }
}
