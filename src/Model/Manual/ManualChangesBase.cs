using System.Collections.Generic;
using HarmonyLib;
using LotusEcarlateChanges.Model.Changes;

namespace LotusEcarlateChanges.Model.Manual;

public abstract class ManualChangesBase : IChanges
{
  private static readonly HashSet<ManualChangesBase> _instances = [];
  private static bool alreadyPatched = false;
  protected ExistingItemManager ItemManager { get; } = new();
  protected List<ExistingPieceManager> PieceManagers { get; } = [];

  protected ManualChangesBase() => _instances.Add(this);

  public void Apply()
  {
    if (alreadyPatched) return;
    alreadyPatched = true;

    Plugin.Harmony.Patch(
      AccessTools.Method(typeof(ObjectDB), nameof(ObjectDB.Awake)),
      postfix: new HarmonyMethod(typeof(ManualChangesBase), nameof(PatchObjectDB)) { priority = Priority.Last }
    );
    Plugin.Harmony.Patch(
      AccessTools.Method(typeof(ObjectDB), nameof(ObjectDB.CopyOtherDB)),
      postfix: new HarmonyMethod(typeof(ManualChangesBase), nameof(PatchObjectDB)) { priority = Priority.Last }
    );
  }

  protected ExistingPieceManager GetPieceManager(ExistingItem item)
  {
    ExistingPieceManager pieceManager = new(item);
    PieceManagers.Add(pieceManager);
    return pieceManager;
  }

  protected static void PatchObjectDB()
  {
    if (ObjectDB.instance.GetItemPrefab("Wood") == null) return; // skip if not loaded yet
    foreach (var instance in _instances)
    {
      instance.ApplyChangesInternal();
      instance.ItemManager.PatchModifiedItems();
      instance.PieceManagers.ForEach(m => m.PatchModifiedPieces());
    }
    ObjectDB.instance.UpdateItemHashes();
  }

  protected abstract void ApplyChangesInternal();
}
