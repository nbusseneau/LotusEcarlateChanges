using System.Collections.Generic;
using LotusEcarlateChanges.Model.Managers;
using LotusEcarlateChanges.Model.Managers.Standalone;
using UnityEngine;

namespace LotusEcarlateChanges.Model.Changes;

public abstract class StandaloneManagerBasedChangesBase : IChanges
{
  protected List<IManager> _managers { get; } = [];
  protected ItemManager<T> RegisterItemManager<T>(List<T> registeredItems, List<GameObject> prefabs, List<GameObject> zNetOnlyPrefabs)
  {
    ItemManager<T> manager = new(registeredItems, prefabs, zNetOnlyPrefabs);
    this._managers.Add(manager);
    return manager;
  }
  protected PieceManager<T> RegisterPieceManager<T>(List<T> registeredPieces, List<GameObject> piecePrefabs)
  {
    PieceManager<T> manager = new(registeredPieces, piecePrefabs);
    this._managers.Add(manager);
    return manager;
  }
  protected CreatureManager<T> RegisterCreatureManager<T>(List<T> registeredPieces, List<GameObject> prefabs)
  {
    CreatureManager<T> manager = new(registeredPieces, prefabs);
    this._managers.Add(manager);
    return manager;
  }

  public void Apply()
  {
    this.ApplyInternal();
    this._managers.ForEach(manager => manager.Apply());
  }
  protected abstract void ApplyInternal();
}
