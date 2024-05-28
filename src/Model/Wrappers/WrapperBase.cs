using System.Collections.Generic;
using UnityEngine;

namespace LotusEcarlateChanges.Model.Wrappers;

public abstract class WrapperBase(GameObject prefab) : IWrapper
{
  protected static readonly Dictionary<string, WrapperBase> WrappersCache = [];

  public GameObject Prefab { get; } = prefab;
  public string PrefabName => this.Prefab.name;
}
