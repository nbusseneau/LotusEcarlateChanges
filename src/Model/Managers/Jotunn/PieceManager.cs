using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Jotunn.Utils;
using LotusEcarlateChanges.Model.Wrappers;

namespace LotusEcarlateChanges.Model.Managers.Jotunn;

public class PieceManager(string modGuid) : JotunnManagerBase, IIndexableManager<PieceWrapper>
{
  private static readonly global::Jotunn.Managers.PieceManager s_manager = global::Jotunn.Managers.PieceManager.Instance;
  private readonly IEnumerable<PieceWrapper> _pieces = ModRegistry.GetPieces(modGuid).Select(piece => PieceWrapper.Get(piece.PiecePrefab));

  protected override void ApplyToRemove()
  {
    var toRemove = s_manager.Pieces.Keys.Where(this._toRemove.Contains).ToList();
    foreach (var piece in toRemove) s_manager.RemovePiece(piece);
  }

  protected override void ApplyToKeep()
  {
    var toRemove = s_manager.Pieces.Keys.Where(itemName => !this._toRemove.Contains(itemName)).ToList();
    foreach (var piece in toRemove) s_manager.RemovePiece(piece);
  }

  public PieceWrapper this[string name]
  {
    get
    {
      var customPiece = s_manager.GetPiece(name);
      if (customPiece is null) Plugin.Logger.LogError($"{this.GetType()} did not find any object registered with name {name}");
      return PieceWrapper.Get(customPiece?.PiecePrefab);
    }
  }
  public IEnumerable<PieceWrapper> this[params string[] names] => names.Select(name => this[name]).Where(w => w is not null);
  public IEnumerator<PieceWrapper> GetEnumerator() => _pieces.GetEnumerator();
  IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}
