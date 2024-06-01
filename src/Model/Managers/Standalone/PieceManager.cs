using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LotusEcarlateChanges.Model.Wrappers;
using UnityEngine;

namespace LotusEcarlateChanges.Model.Managers.Standalone;

public class PieceManager<T>(List<T> registeredPieces, List<GameObject> piecePrefabs) : PrefabManagerBase<T>(registeredPieces, piecePrefabs), IIndexableManager<(T BuildPiece, PieceWrapper Wrapper)>
{
  public (T BuildPiece, PieceWrapper Wrapper) this[string name]
  {
    get
    {
      var obj = this.GetObject(name);
      return (obj, PieceWrapper.Get(this.GetPrefab(obj)));
    }
  }
  public IEnumerable<(T BuildPiece, PieceWrapper Wrapper)> this[params string[] names] => names.Select(name => this[name]).Where(t => t.BuildPiece is not null);
  public IEnumerator<(T BuildPiece, PieceWrapper Wrapper)> GetEnumerator() => this._registeredObjects.Select(obj => (obj, PieceWrapper.Get(this.GetPrefab(obj)))).GetEnumerator();
  IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}
