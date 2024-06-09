extern alias RenegadeVikings;

using System.Collections.Generic;
using System.Linq;
using LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes;
using LotusEcarlateChanges.Model.Managers.Manual;
using UnityEngine;
using static Humanoid;

namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Tiers;

public abstract class TierBase : ITier
{
  private static GameObject[] GetItemArray(params string[] names) => names.Select(name => ItemManager.Instance[name].Prefab).ToArray();
  private static ItemSet GetItemSet(params string[] names) => new() { m_items = GetItemArray(names) };

  private GameObject[] _weaponsCache;
  protected string[] _weapons;
  public GameObject[] Weapons => this._weaponsCache ??= GetItemArray(this._weapons);

  private GameObject[] _shieldsCache;
  protected string[] _shields;
  public GameObject[] Shields => this._shieldsCache ??= GetItemArray(this._shields);


  private ItemSet[] _setsCache;
  protected string[][] _sets;
  public ItemSet[] Sets => this._setsCache ??= this._sets.Select(GetItemSet).ToArray();

  protected List<IArchetype> _archetypes;
  public List<IArchetype> Archetypes => this._archetypes;

  public IArchetype RandomArchetype => this.Archetypes[RenegadeVikings.Random.Next(this.Archetypes.Count)];
}
