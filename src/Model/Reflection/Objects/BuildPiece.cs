using HarmonyLib;
using UnityEngine;
using LotusEcarlateChanges.Extensions;
using LotusEcarlateChanges.Model.Wrappers;
using LotusEcarlateChanges.Model.Reflection.Objects.Nested;

namespace LotusEcarlateChanges.Model.Reflection.Objects;

public class BuildPiece : ReflectionObjectBase
{
  public GameObject Prefab { get; }
  public override string UniqueName => this.Prefab.name;
  public Piece Piece { get; }

  private readonly BuildingPieceCategory _category;
  public int Category { get => this._category.Get(); set => this._category.Set(value); }
  public string CustomCategory { get => this._category.GetCustom(); }

  public RequiredResourcesList RequiredItems { get; }
  public PieceTool Tool { get; }

  private readonly Comfort _comfort;
  public Comfort Comfort { get => this._comfort; set => this._comfort.CopyProperties(value); }

  public BuildPiece(object buildPiece) : base(buildPiece)
  {
    this._category = new(AccessTools.Field(buildPiece.GetType(), "Category").GetValue(buildPiece));
    this.RequiredItems = new(AccessTools.Field(buildPiece.GetType(), "RequiredItems").GetValue(buildPiece));
    this.Tool = new(AccessTools.Field(buildPiece.GetType(), "Tool").GetValue(buildPiece));

    this.Prefab = (GameObject)AccessTools.Field(buildPiece.GetType(), "Prefab").GetValue(buildPiece);
    this.Piece = this.Prefab.GetComponent<Piece>();
    this._comfort = new(this.Piece);
  }
}
