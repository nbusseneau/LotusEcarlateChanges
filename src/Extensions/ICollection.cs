using System.Collections;
using HarmonyLib;
using UnityEngine;

namespace LotusEcarlateChanges.Extensions;

public static class ICollectionExtensions
{
  public static object FindObjectByPrefabName(this ICollection collection, string prefabName)
  {
    foreach (var item in collection)
    {
      var prefab = (GameObject)AccessTools.Field(item.GetType(), "Prefab").GetValue(item);
      if (prefab.name == prefabName) return item;
    }
    return null;
  }
}
