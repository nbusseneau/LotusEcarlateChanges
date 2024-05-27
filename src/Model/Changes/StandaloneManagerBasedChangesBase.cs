using System.Collections.Generic;
using System.Linq;
using LotusEcarlateChanges.Model.StandaloneManagerInterceptors;
using UnityEngine;

namespace LotusEcarlateChanges.Model.Changes;

public abstract class StandaloneManagerBasedChangesBase : IChanges
{
  protected List<IStandaloneManagerInterceptor> Managers = [];
  protected ItemManagerInterceptor<T> RegisterItemManager<T>(List<T> registeredItems, List<GameObject> prefabs, List<GameObject> zNetOnlyPrefabs)
  {
    ItemManagerInterceptor<T> manager = new(registeredItems, prefabs, zNetOnlyPrefabs);
    this.Managers.Add(manager);
    return manager;
  }
  protected PieceManagerInterceptor<T> RegisterPieceManager<T>(List<T> registeredPieces, List<GameObject> piecePrefabs)
  {
    PieceManagerInterceptor<T> manager = new(registeredPieces, piecePrefabs);
    this.Managers.Add(manager);
    return manager;
  }
  protected CreatureManagerInterceptor<T> RegisterCreatureManager<T>(List<T> registeredPieces, List<GameObject> prefabs)
  {
    CreatureManagerInterceptor<T> manager = new(registeredPieces, prefabs);
    this.Managers.Add(manager);
    return manager;
  }

  protected readonly HashSet<string> ToRemove = [];
  protected readonly HashSet<string> ToKeep = [];
  protected void Remove(string prefabName) => this.ToRemove.Add(prefabName);
  protected void Keep(string prefabName) => this.ToKeep.Add(prefabName);

  public void Apply()
  {
    this.ApplyInternal();
    if (this.ToRemove.Any() && this.ToKeep.Any()) Plugin.Logger.LogError("Can't have prefabs to remove and prefabs to keep at the same time.");
    else if (this.ToRemove.Any()) this.Managers.ForEach(m => m.RemoveAll(this.ToRemove));
    else if (this.ToKeep.Any()) this.Managers.ForEach(m => m.KeepOnly(this.ToKeep));
  }
  protected abstract void ApplyInternal();
}
