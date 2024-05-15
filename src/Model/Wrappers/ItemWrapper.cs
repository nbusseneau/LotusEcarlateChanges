using HarmonyLib;
using LotusEcarlateChanges.Extensions;
using LotusEcarlateChanges.Model.Wrappers.Nested;
using UnityEngine;

namespace LotusEcarlateChanges.Model.Wrappers;

public class ItemWrapper : WrapperBase
{
  public ItemDrop.ItemData ItemData { get; }
  public ItemDrop.ItemData.SharedData SharedData { get; }

  private readonly Armor _armor;
  public Armor Armor { get => this._armor; set => this._armor.CopyProperties(value); }
  private readonly Food _food;
  public Food Food { get => this._food; set => this._food.CopyProperties(value); }
  private readonly Set _set;
  public Set Set { get => this._set; set => this._set.CopyProperties(value); }
  private readonly Weapon _weapon;
  public Weapon Weapon { get => this._weapon; set => this._weapon.CopyProperties(value); }

  protected ItemWrapper(GameObject prefab) : base(prefab)
  {
    this.ItemData = this.Prefab.GetComponent<ItemDrop>().m_itemData;
    this.SharedData = this.ItemData.m_shared;

    this._armor = new(this.SharedData);
    this._food = new(this.SharedData);
    this._set = new(this.SharedData);
    this._weapon = new(this.SharedData);
  }

  public static ItemWrapper Get(GameObject prefab)
  {
    var wrapper = _cache.GetValueSafe(prefab.name) ?? (_cache[prefab.name] = new ItemWrapper(prefab));
    return (ItemWrapper)wrapper;
  }
}
