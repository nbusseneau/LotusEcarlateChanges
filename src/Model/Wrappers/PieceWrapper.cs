using LotusEcarlateChanges.Extensions;
using LotusEcarlateChanges.Model.Wrappers.Nested;
using UnityEngine;

namespace LotusEcarlateChanges.Model.Wrappers;

public class PieceWrapper : PrefabWrapperBase
{
  public Piece Piece { get; }

  public CraftingStation CraftingStation { get => this.Piece.m_craftingStation; set => this.Piece.m_craftingStation = value; }
  public Piece.PieceCategory Category { get => this.Piece.m_category; set => this.Piece.m_category = value; }
  private readonly ComfortWrapper _comfort;
  public ComfortWrapper Comfort { get => this._comfort; set => this._comfort.CopyProperties(value); }
  public ResourcesWrapper Resources { get; }

  protected PieceWrapper(GameObject prefab) : base(prefab)
  {
    this.Piece = this.Prefab.GetComponent<Piece>();
    this._comfort = new(this.Piece);
    this.Resources = new(this.Piece);
  }

  public static PieceWrapper Get(GameObject prefab)
  {
    if (prefab is null) return null;
    var isCached = s_wrappersCache.TryGetValue(prefab.name, out var wrapper);
    if (!isCached) wrapper = s_wrappersCache[prefab.name] = new PieceWrapper(prefab);
    return (PieceWrapper)wrapper;
  }
}
