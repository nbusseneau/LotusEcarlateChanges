using System.Collections.Generic;
using UnityEngine;

namespace LotusEcarlateChanges.Model.Wrappers;

public abstract class PrefabWrapperBase(GameObject prefab)
{
  protected static readonly Dictionary<string, PrefabWrapperBase> s_wrappersCache = [];

  public GameObject Prefab { get; } = prefab;
  public string PrefabName => this.Prefab.name;
}
