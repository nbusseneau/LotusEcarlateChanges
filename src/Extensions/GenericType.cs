using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using LotusEcarlateChanges.Model.Wrappers;
using UnityEngine;

namespace LotusEcarlateChanges.Extensions;

public static class GenericTypeExtensions
{
  private static readonly Dictionary<object, GameObject> _cache = [];
  public static GameObject Prefab<T>(this T container) => _cache.GetValueSafe(container) ?? (_cache[container] = (GameObject)AccessTools.Field(container.GetType(), "Prefab").GetValue(container));

  public static PieceWrapper Piece<T>(this T container) => container.Prefab().Piece();
  public static ItemWrapper Item<T>(this T container) => container.Prefab().Item();

  public static void CopyProperties<T>(this T targetObject, T sourceObject)
  {
    foreach (var property in targetObject.GetType().GetProperties().Where(p => p.CanWrite))
    {
      property.SetValue(targetObject, property.GetValue(sourceObject));
    }
  }
}
