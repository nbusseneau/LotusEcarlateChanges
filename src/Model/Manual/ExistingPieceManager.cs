using System;
using System.Collections.Generic;
using System.Linq;

namespace LotusEcarlateChanges.Model.Manual;

public class ExistingPieceManager(ExistingItem item)
{
  private readonly ExistingItem _item = item;
  protected readonly Dictionary<string, ExistingPiece> _modified = [];
  public ExistingPiece this[string prefabName]
  {
    get
    {
      if (!_modified.ContainsKey(prefabName))
      {
        try
        {
          var prefab = _item.Pieces.First(p => p.name == prefabName);
          _modified[prefabName] = new(prefab);
        }
        catch (InvalidOperationException)
        {
          return null;
        }
      }
      return _modified[prefabName];
    }
  }

  public void PatchModifiedPieces()
  {
    foreach (var piece in _modified.Values)
    {
      piece.Resources.Save();
    }
  }
}
