using System.Collections.Generic;
using LotusEcarlateChanges.Extensions;
using LotusEcarlateChanges.Model.Wrappers;

namespace LotusEcarlateChanges.Model.Manual;

public class ManualPieceManager : ManualManagerBase<PieceWrapper>
{
  private static ManualPieceManager _instance;
  public static ManualPieceManager Instance { get; } = _instance ??= new ManualPieceManager();
  private ManualPieceManager() { }

  protected override PieceWrapper Get(string prefabName) => PieceWrapper.Get(ZNetScene.instance?.GetPrefab(prefabName));

  private static ItemWrapper hammer;
  public override void RemoveAll(HashSet<string> toRemove)
  {
    foreach (var prefabName in toRemove)
    {
      hammer ??= ObjectDB.instance.GetItemPrefab("Hammer").Item();
      if (ZNetScene.instance.GetPrefab(prefabName) is { } piecePrefab)
      {
        ZNetScene.instance.m_prefabs.RemoveAll(prefab => prefab.name == prefabName);
        ZNetScene.instance.m_nonNetViewPrefabs.RemoveAll(prefab => prefab.name == prefabName);
        ZNetScene.instance.m_namedPrefabs.Remove(prefabName.GetStableHashCode());
        hammer.Pieces.RemoveAll(prefab => prefab.name == prefabName);
        foreach (var pieces in hammer.PieceTable.m_availablePieces) pieces.RemoveAll(piece => piece.name == prefabName);
      }
    }
  }
}
