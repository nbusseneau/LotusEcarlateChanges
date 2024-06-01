using LotusEcarlateChanges.Model.Managers.Jotunn;

namespace LotusEcarlateChanges.Model.Changes;

public abstract class JotunnBasedChangesBase(string modGuid = null) : IChanges
{
  protected ItemManager ItemManager { get; } = !string.IsNullOrEmpty(modGuid) ? new(modGuid) : null;
  protected PieceManager PieceManager { get; } = !string.IsNullOrEmpty(modGuid) ? new(modGuid) : null;

  public void Apply()
  {
    this.ApplyInternal();
    ItemManager?.Apply();
    PieceManager?.Apply();
    Jotunn.Managers.PieceManager.OnPiecesRegistered += ApplyInternalDeferred;
  }
  protected abstract void ApplyInternal();
  protected virtual void ApplyInternalDeferred() { }
}
