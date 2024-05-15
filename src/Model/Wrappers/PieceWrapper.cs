using HarmonyLib;
using LotusEcarlateChanges.Extensions;
using LotusEcarlateChanges.Model.Wrappers.Nested;
using UnityEngine;

namespace LotusEcarlateChanges.Model.Wrappers;

public class PieceWrapper : WrapperBase
{
  public Piece Piece { get; }

  private readonly Comfort _comfort;
  public Comfort Comfort { get => this._comfort; set => this._comfort.CopyProperties(value); }

  protected PieceWrapper(GameObject prefab) : base(prefab)
  {
    this.Piece = this.Prefab.GetComponent<Piece>();
    this._comfort = new(this.Piece);
  }

  public static PieceWrapper Get(GameObject prefab)
  {
    var wrapper = _cache.GetValueSafe(prefab.name) ?? (_cache[prefab.name] = new PieceWrapper(prefab));
    return (PieceWrapper)wrapper;
  }
}
