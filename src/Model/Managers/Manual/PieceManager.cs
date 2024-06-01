using LotusEcarlateChanges.Model.Wrappers;

namespace LotusEcarlateChanges.Model.Managers.Manual;

public class PieceManager : ManualManagerBase<PieceWrapper>
{
  private static readonly PieceManager s_instance;
  public static PieceManager Instance { get; } = s_instance ??= new PieceManager();
  private PieceManager() { }

  protected override PieceWrapper Get(string name) => PieceWrapper.Get(ZNetScene.instance?.GetPrefab(name));

  private static ItemWrapper s_hammer;
  public override void Apply()
  {
    foreach (var name in this._toRemove)
    {
      s_hammer ??= ItemWrapper.Get(ObjectDB.instance.GetItemPrefab("Hammer"));
      if (ZNetScene.instance.GetPrefab(name) is { } piecePrefab)
      {
        ZNetScene.instance.m_prefabs.RemoveAll(prefab => prefab.name == name);
        ZNetScene.instance.m_nonNetViewPrefabs.RemoveAll(prefab => prefab.name == name);
        ZNetScene.instance.m_namedPrefabs.Remove(name.GetStableHashCode());
        s_hammer.Pieces.RemoveAll(prefab => prefab.name == name);
        foreach (var pieces in s_hammer.PieceTable.m_availablePieces) pieces.RemoveAll(piece => piece.name == name);
      }
    }
  }
}
