using TMPro;
using UnityEngine;

namespace LotusEcarlateChanges.Extensions;

public static class GameObjectExtensions
{
  private static readonly int s_itemLayer = LayerMask.NameToLayer("item");

  /// <summary>
  /// Kludge to fix the layer on some items e.g. Southsil helmets.
  /// </summary>
  public static void FixItemLayer(this GameObject gameObject) => gameObject.GetComponentInChildren<Collider>().gameObject.layer = s_itemLayer;

  public static GameObject Find(this GameObject gameObject, string name) => gameObject.transform.Find(name).gameObject;
  public static void SetText(this GameObject gameObject, string text) => gameObject.GetComponentInChildren<TextMeshProUGUI>().SetText(text);
}
