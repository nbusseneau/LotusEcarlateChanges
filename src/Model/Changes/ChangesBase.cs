using System.Collections.Generic;
using System.Linq;
using LotusEcarlateChanges.Model.Managers;
using UnityEngine;

namespace LotusEcarlateChanges.Model.Changes;

public abstract class ChangesBase : IChanges
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

  protected HashSet<string> ToRemove { get; } = [];
  protected HashSet<string> ToKeep { get; } = [];
  protected void Remove(string prefabName) => this.ToRemove.Add(prefabName);
  protected void Keep(string prefabName) => this.ToKeep.Add(prefabName);

  protected abstract void ApplyChangesInternal();
  public void Apply()
  {
    this.ApplyChangesInternal();
    if (this.ToRemove.Any()) this._managers.ForEach(m => m.RemoveAll(this.ToRemove));
    if (this.ToKeep.Any()) this._managers.ForEach(m => m.KeepOnly(this.ToKeep));
  }
}
