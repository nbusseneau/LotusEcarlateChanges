using System.Collections.Generic;
using System.Linq;
using LotusEcarlateChanges.Model.Manager;
using UnityEngine;

namespace LotusEcarlateChanges.Model.Changes;

public abstract class ManagerChangesBase : IChanges
{
  protected List<IManager> _managers = [];
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

  protected readonly HashSet<string> toRemove = [];
  protected readonly HashSet<string> toKeep = [];
  protected void Remove(string prefabName) => this.toRemove.Add(prefabName);
  protected void Keep(string prefabName) => this.toKeep.Add(prefabName);

  public void Apply()
  {
    this.ApplyInternal();
    if (this.toRemove.Any() && this.toKeep.Any()) Plugin.Logger.LogError("Can't have prefabs to remove and prefabs to keep at the same time.");
    else if (this.toRemove.Any()) this._managers.ForEach(m => m.RemoveAll(this.toRemove));
    else if (this.toKeep.Any()) this._managers.ForEach(m => m.KeepOnly(this.toKeep));
  }
  protected abstract void ApplyInternal();
}
