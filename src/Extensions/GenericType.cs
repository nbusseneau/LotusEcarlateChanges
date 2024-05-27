using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using Jotunn.Entities;
using LotusEcarlateChanges.Model.Wrappers;
using UnityEngine;

namespace LotusEcarlateChanges.Extensions;

public static class GenericTypeExtensions
{
  private static readonly Dictionary<object, GameObject> s_cache = [];
  public static GameObject Prefab<T>(this T container)
  {
    var isCached = s_cache.TryGetValue(container, out var prefab);
    if (!isCached)
    {
      if (container is CustomItem customItem) prefab ??= s_cache[container] = customItem.ItemPrefab;
      else if (container is CustomPiece customPiece) prefab ??= s_cache[container] = customPiece.PiecePrefab;
      else prefab ??= s_cache[container] = (GameObject)AccessTools.Field(container.GetType(), "Prefab")?.GetValue(container);
    }
    return prefab;
  }

  public static ItemWrapper Item<T>(this T container) => container.Prefab().Item();
  public static PieceWrapper Piece<T>(this T container) => container.Prefab().Piece();

  public static void CopyProperties<T>(this T targetObject, T sourceObject)
  {
    foreach (var property in targetObject.GetType().GetProperties().Where(p => p.CanWrite))
    {
      property.SetValue(targetObject, property.GetValue(sourceObject));
    }
  }
}
