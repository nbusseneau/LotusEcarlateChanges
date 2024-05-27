using System.Collections.Generic;
using LotusEcarlateChanges.Extensions;
using LotusEcarlateChanges.Model.Wrappers;

namespace LotusEcarlateChanges.Model.ManualManagers;

public class ManualPieceManager : ManualManagerBase<PieceWrapper>
{
  private static ManualPieceManager s_instance;
  public static ManualPieceManager Instance { get; } = s_instance ??= new ManualPieceManager();
  private ManualPieceManager() { }

  protected override PieceWrapper Get(string prefabName) => PieceWrapper.Get(ZNetScene.instance?.GetPrefab(prefabName));

  private static ItemWrapper s_hammer;
  public override void RemoveAll(HashSet<string> toRemove)
  {
    foreach (var prefabName in toRemove)
    {
      s_hammer ??= ObjectDB.instance.GetItemPrefab("Hammer").Item();
      if (ZNetScene.instance.GetPrefab(prefabName) is { } piecePrefab)
      {
        ZNetScene.instance.m_prefabs.RemoveAll(prefab => prefab.name == prefabName);
        ZNetScene.instance.m_nonNetViewPrefabs.RemoveAll(prefab => prefab.name == prefabName);
        ZNetScene.instance.m_namedPrefabs.Remove(prefabName.GetStableHashCode());
        s_hammer.Pieces.RemoveAll(prefab => prefab.name == prefabName);
        foreach (var pieces in s_hammer.PieceTable.m_availablePieces) pieces.RemoveAll(piece => piece.name == prefabName);
      }
    }
  }
}
