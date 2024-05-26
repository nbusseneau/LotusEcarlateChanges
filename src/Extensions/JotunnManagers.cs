using System;
using System.Collections.Generic;
using System.Linq;
using LotusEcarlateChanges.Model.Wrappers;

namespace LotusEcarlateChanges.Extensions;

public static class JotunnManagersExtensions
{
  public static IEnumerable<ItemWrapper> GetAll(this Jotunn.Managers.ItemManager itemManager, IEnumerable<string> prefabNames) => prefabNames.Select(itemName => itemManager.GetItem(itemName).Item());
  public static IEnumerable<(ItemWrapper, T)> GetAll<T>(this Jotunn.Managers.ItemManager itemManager, Dictionary<string, T> prefabNamesDict) => prefabNamesDict.Select(kvp => (itemManager.GetItem(kvp.Key).Item(), kvp.Value));
  public static void RemoveAll(this Jotunn.Managers.ItemManager itemManager, Predicate<string> match)
  {
    var toRemove = itemManager.Items.Keys.Where(itemName => match(itemName)).ToList();
    foreach (var item in toRemove) itemManager.RemoveItem(item);
  }

  public static IEnumerable<PieceWrapper> GetAll(this Jotunn.Managers.PieceManager pieceManager, IEnumerable<string> prefabNames) => prefabNames.Select(pieceName => pieceManager.GetPiece(pieceName).Piece());
  public static IEnumerable<(PieceWrapper, T)> GetAll<T>(this Jotunn.Managers.PieceManager pieceManager, Dictionary<string, T> prefabNamesDict) => prefabNamesDict.Select(kvp => (pieceManager.GetPiece(kvp.Key).Piece(), kvp.Value));
  public static void RemoveAll(this Jotunn.Managers.PieceManager pieceManager, Predicate<string> match)
  {
    var toRemove = pieceManager.Pieces.Keys.Where(pieceName => match(pieceName)).ToList();
    foreach (var piece in toRemove) pieceManager.RemovePiece(piece);
  }

  public static void RemoveAll(this Jotunn.Managers.CreatureManager creatureManager, Predicate<string> match)
  {
    var toRemove = creatureManager.Creatures.Where(creature => match(creature.Prefab.name)).ToList();
    foreach (var creature in toRemove) creatureManager.RemoveCreature(creature);
  }

  public static void RemoveAll(this Jotunn.Managers.PrefabManager prefabManager, Predicate<string> match)
  {
    var toRemove = prefabManager.Prefabs.Keys.Where(prefabName => match(prefabName)).ToList();
    foreach (var prefab in toRemove) prefabManager.DestroyPrefab(prefab);
  }
}
