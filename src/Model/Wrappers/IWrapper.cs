using UnityEngine;

namespace LotusEcarlateChanges.Model.Wrappers;

public interface IWrapper
{
  public GameObject Prefab { get; }
  public string PrefabName { get; }
}
