using UnityEngine;

namespace LotusEcarlateChanges.Model.Manual;

public class ExistingPiece
{
  public GameObject Prefab { get; }
  public Piece Piece { get; }
  public Wrappers.Resources Resources { get; }

  public ExistingPiece(GameObject prefab)
  {
    this.Prefab = prefab;
    this.Piece = this.Prefab.GetComponent<Piece>();
    this.Resources = new(this.Piece);
  }
}
