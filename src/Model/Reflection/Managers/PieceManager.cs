using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using UnityEngine;
using LotusEcarlateChanges.Extensions;
using LotusEcarlateChanges.Model.Reflection.Objects;

namespace LotusEcarlateChanges.Model.Reflection.Managers;
public class PieceManager : ReflectionManagerBase<BuildPiece>
{
  private readonly IList _registeredPieces;
  private readonly List<GameObject> _prefabs;

  public PieceManager(Assembly assembly, string assemblyNamespace = "PieceManager") : base(assembly)
  {
    var buildPieceType = assembly.GetType($"{assemblyNamespace}.BuildPiece");
    var registeredPiecesField = AccessTools.DeclaredField(buildPieceType, "registeredPieces");
    this._registeredPieces = (IList)registeredPiecesField.GetValue(null);

    var piecePrefabManagerType = assembly.GetType($"{assemblyNamespace}.PiecePrefabManager");
    var piecePrefabsField = AccessTools.DeclaredField(piecePrefabManagerType, "piecePrefabs");
    this._prefabs = (List<GameObject>)piecePrefabsField.GetValue(null);
  }

  protected override object GetObjectFromStorage(string name) => this._registeredPieces.FindObjectByPrefabName(name);
  protected override ICollection GetAllObjectsFromStorage() => this._registeredPieces;

  public override void UnregisterToRemove(HashSet<string> toRemove)
  {
    this._registeredPieces.RemoveAllPrefabs(toRemove);
    this._prefabs.RemoveAll(prefab => toRemove.Contains(prefab.name));
  }

  public override void UnregisterAllExceptToKeep(HashSet<string> toKeep)
  {
    this._registeredPieces.RemoveAllExceptPrefabsToKeep(toKeep);
    this._prefabs.RemoveAll(prefab => !toKeep.Contains(prefab.name));
  }
}
