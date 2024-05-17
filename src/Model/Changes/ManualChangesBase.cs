using System.Collections.Generic;
using HarmonyLib;
using LotusEcarlateChanges.Model.Manual;

namespace LotusEcarlateChanges.Model.Changes;

public abstract class ManualChangesBase : IChanges
{
  private static readonly HashSet<ManualChangesBase> _instances = [];
  protected static ManualItemManager ItemManager { get; } = ManualItemManager.Instance;
  protected static ManualPieceManager PieceManager { get; } = ManualPieceManager.Instance;

  protected readonly HashSet<string> toRemove = [];
  protected void Remove(string prefabName) => this.toRemove.Add(prefabName);

  public void Apply()
  {
    _instances.Add(this);
    this.ApplyInternal();
  }
  protected virtual void ApplyInternal() { }

  protected static void ApplyDeferred()
  {
    if (ObjectDB.instance.GetItemPrefab("Wood") is null) return; // safeguard until ObjectDB is actually ready
    foreach (var instance in _instances)
    {
      instance.ApplyInternalDeferred();
      ItemManager.RemoveAll(instance.toRemove);
      PieceManager.RemoveAll(instance.toRemove);
    }
    ItemManager.RegisterStatusEffects();
  }
  protected virtual void ApplyInternalDeferred() { }

  static ManualChangesBase()
  {
    Plugin.Harmony.Patch(
      AccessTools.Method(typeof(ObjectDB), nameof(ObjectDB.Awake)),
      postfix: new HarmonyMethod(typeof(ManualChangesBase), nameof(ApplyDeferred)) { priority = -100 }
    );
    // Plugin.Harmony.Patch(
    //   AccessTools.Method(typeof(ObjectDB), nameof(ObjectDB.CopyOtherDB)),
    //   postfix: new HarmonyMethod(typeof(ManualChangesBase), nameof(ApplyDeferred)) { priority = -100 }
    // );
  }
}
