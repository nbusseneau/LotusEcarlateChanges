using System.Collections.Generic;
using UnityEngine;
using LotusEcarlateChanges.Extensions;
using LotusEcarlateChanges.Model.Wrappers;

namespace LotusEcarlateChanges.Model.Manual;

public class ExistingItem
{
  public GameObject Prefab { get; }
  public ItemDrop.ItemData ItemData { get; }
  public ItemDrop.ItemData.SharedData SharedData { get; }

  public Wrappers.Resources _resources;
  public Wrappers.Resources Resources
  {
    get
    {
      if (_resources is not null) return _resources;
      if (ObjectDB.instance.GetRecipe(this.ItemData) is { } recipe) return _resources = new(recipe);
      return null;
    }
  }

  public List<GameObject> Pieces { get => this.SharedData.m_buildPieces?.m_pieces; }

  private readonly Armor _armor;
  public Armor Armor { get => this._armor; set => this._armor.CopyProperties(value); }
  private readonly Food _food;
  public Food Food { get => this._food; set => this._food.CopyProperties(value); }
  private readonly Set _set;
  public Set Set { get => this._set; set => this._set.CopyProperties(value); }
  private readonly Weapon _weapon;
  public Weapon Weapon { get => this._weapon; set => this._weapon.CopyProperties(value); }

  public ExistingItem(GameObject prefab)
  {
    this.Prefab = prefab;
    this.ItemData = this.Prefab.GetComponent<ItemDrop>().m_itemData;
    this.SharedData = this.ItemData.m_shared;

    this._armor = new(this.SharedData);
    this._food = new(this.SharedData);
    this._set = new(this.SharedData);
    this._weapon = new(this.SharedData);
  }
}
