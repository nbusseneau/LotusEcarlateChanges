using System.Collections.Generic;
using HarmonyLib;
using LotusEcarlateChanges.Model.Managers.Manual;

namespace LotusEcarlateChanges.Model.Changes;

public abstract class ManualChangesBase : IChanges
{
  private static readonly HashSet<ManualChangesBase> s_instances = [];
  protected ItemManager ItemManager => ItemManager.Instance;
  protected PieceManager PieceManager => PieceManager.Instance;

  public void Apply()
  {
    s_instances.Add(this);
    this.ApplyInternal();
  }
  protected virtual void ApplyInternal() { }

  protected static void ApplyOnObjectDBAwake()
  {
    if (ObjectDB.instance.GetItemPrefab("Wood") is null) return; // safeguard until ObjectDB is actually ready
    foreach (var instance in s_instances) instance.ApplyOnObjectDBAwakeInternal();
    ItemManager.Instance.Apply();
    PieceManager.Instance.Apply();
  }

  /// <summary>
  /// Idempotent changes only, as this will be called mutliple times.
  /// </summary>
  protected virtual void ApplyOnObjectDBAwakeInternal() { }

  static ManualChangesBase()
  {
    Plugin.Harmony.Patch(
      AccessTools.Method(typeof(ObjectDB), nameof(ObjectDB.Awake)),
      postfix: new HarmonyMethod(typeof(ManualChangesBase), nameof(ApplyOnObjectDBAwake)) { priority = -100 }
    );
  }
}
