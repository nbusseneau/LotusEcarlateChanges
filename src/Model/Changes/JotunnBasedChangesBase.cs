using System.Collections.Generic;
using System.Linq;
using LotusEcarlateChanges.Extensions;

namespace LotusEcarlateChanges.Model.Changes;

public abstract class JotunnBasedChangesBase : IChanges
{
  protected Jotunn.Managers.ItemManager ItemManager { get; } = Jotunn.Managers.ItemManager.Instance;
  protected Jotunn.Managers.PieceManager PieceManager { get; } = Jotunn.Managers.PieceManager.Instance;
  protected Jotunn.Managers.CreatureManager CreatureManager { get; } = Jotunn.Managers.CreatureManager.Instance;
  protected Jotunn.Managers.PrefabManager PrefabManager { get; } = Jotunn.Managers.PrefabManager.Instance;

  protected readonly HashSet<string> ToRemove = [];
  protected readonly HashSet<string> ToKeep = [];
  protected void Remove(string prefabName) => this.ToRemove.Add(prefabName);
  protected void Keep(string prefabName) => this.ToKeep.Add(prefabName);

  public void Apply()
  {
    this.ApplyInternal();
    if (this.ToRemove.Any() && this.ToKeep.Any()) Plugin.Logger.LogError("Can't have prefabs to remove and prefabs to keep at the same time.");
    else if (this.ToRemove.Any())
    {
      this.ItemManager.RemoveAll(this.ToRemove.Contains);
      this.PieceManager.RemoveAll(this.ToRemove.Contains);
      this.CreatureManager.RemoveAll(this.ToRemove.Contains);
      this.PrefabManager.RemoveAll(this.ToRemove.Contains);
    }
    else if (this.ToKeep.Any())
    {
      this.ItemManager.RemoveAll(itemName => !this.ToKeep.Contains(itemName));
      this.PieceManager.RemoveAll(pieceName => !this.ToKeep.Contains(pieceName));
      this.CreatureManager.RemoveAll(creatureName => !this.ToKeep.Contains(creatureName));
      this.PrefabManager.RemoveAll(prefabName => !this.ToKeep.Contains(prefabName));
    }
    Jotunn.Managers.PieceManager.OnPiecesRegistered += ApplyInternalDeferred;
  }
  protected abstract void ApplyInternal();
  protected virtual void ApplyInternalDeferred() { }
}
