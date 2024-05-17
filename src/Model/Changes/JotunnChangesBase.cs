using System.Collections.Generic;
using System.Linq;
using LotusEcarlateChanges.Extensions;

namespace LotusEcarlateChanges.Model.Changes;

public abstract class JotunnChangesBase : IChanges
{
  protected Jotunn.Managers.ItemManager ItemManager { get; } = Jotunn.Managers.ItemManager.Instance;
  protected Jotunn.Managers.PieceManager PieceManager { get; } = Jotunn.Managers.PieceManager.Instance;
  protected Jotunn.Managers.CreatureManager CreatureManager { get; } = Jotunn.Managers.CreatureManager.Instance;
  protected Jotunn.Managers.PrefabManager PrefabManager { get; } = Jotunn.Managers.PrefabManager.Instance;

  protected readonly HashSet<string> toRemove = [];
  protected readonly HashSet<string> toKeep = [];
  protected void Remove(string prefabName) => this.toRemove.Add(prefabName);
  protected void Keep(string prefabName) => this.toKeep.Add(prefabName);

  public void Apply()
  {
    this.ApplyInternal();
    if (this.toRemove.Any() && this.toKeep.Any()) Plugin.Logger.LogError("Can't have prefabs to remove and prefabs to keep at the same time.");
    else if (this.toRemove.Any())
    {
      this.ItemManager.RemoveAll(this.toRemove.Contains);
      this.PieceManager.RemoveAll(this.toRemove.Contains);
      this.CreatureManager.RemoveAll(this.toRemove.Contains);
      this.PrefabManager.RemoveAll(this.toRemove.Contains);
    }
    else if (this.toKeep.Any())
    {
      this.ItemManager.RemoveAll(itemName => !this.toKeep.Contains(itemName));
      this.PieceManager.RemoveAll(pieceName => !this.toKeep.Contains(pieceName));
      this.CreatureManager.RemoveAll(creatureName => !this.toKeep.Contains(creatureName));
      this.PrefabManager.RemoveAll(prefabName => !this.toKeep.Contains(prefabName));
    }
    Jotunn.Managers.PieceManager.OnPiecesRegistered += ApplyInternalDeferred;
  }
  protected abstract void ApplyInternal();
  protected abstract void ApplyInternalDeferred();
}
