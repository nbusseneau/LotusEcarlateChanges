using System.Collections.Generic;
using UnityEngine;

namespace LotusEcarlateChanges.Model.Wrappers;

public abstract class WrapperBase : IWrapper
{
  protected static readonly Dictionary<string, WrapperBase> _cache = [];

  public GameObject Prefab { get; }
  public string Name => this.Prefab.name;

  protected WrapperBase(GameObject prefab) => this.Prefab = prefab;
}
