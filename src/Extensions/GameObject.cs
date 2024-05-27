using LotusEcarlateChanges.Model.Wrappers;
using UnityEngine;

namespace LotusEcarlateChanges.Extensions;

public static class GameObjectExtensions
{
  private static readonly int s_itemLayer = LayerMask.NameToLayer("item");

  /// <summary>
  /// Kludge to fix the layer on some items e.g. Southsil helmets.
  /// </summary>
  public static void FixItemLayer(this GameObject gameObject) => gameObject.GetComponentInChildren<Collider>().gameObject.layer = s_itemLayer;

  public static ItemWrapper Item(this GameObject gameObject) => ItemWrapper.Get(gameObject);
  public static PieceWrapper Piece(this GameObject gameObject) => PieceWrapper.Get(gameObject);
}
