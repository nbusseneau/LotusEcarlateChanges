using System.Collections.Generic;
using LotusEcarlateChanges.Extensions;
using LotusEcarlateChanges.Model.Wrappers.Nested;
using UnityEngine;

namespace LotusEcarlateChanges.Model.Wrappers;

public class ItemWrapper : PrefabWrapperBase
{
  public ItemDrop.ItemData ItemData { get; }
  public ItemDrop.ItemData.SharedData SharedData { get; }
  public PieceTable PieceTable { get; }
  public List<GameObject> Pieces { get; }
  private Recipe _recipe;
  public Recipe Recipe
  {
    get
    {
      if (_recipe is not null) return _recipe;
      if (ObjectDB.instance.GetRecipe(this.ItemData) is { } recipe) return _recipe = recipe;
      return null;
    }
  }
  private ResourcesWrapper _resources;
  public ResourcesWrapper Resources
  {
    get
    {
      if (_resources is not null) return _resources;
      if (this.Recipe is not null) return _resources = new(this.Recipe);
      return null;
    }
  }
  public Sprite Icon => this.ItemData.GetIcon();

  private readonly ArmorWrapper _armor;
  public ArmorWrapper Armor { get => this._armor; set => this._armor.CopyProperties(value); }
  private readonly FoodWrapper _food;
  public FoodWrapper Food { get => this._food; set => this._food.CopyProperties(value); }
  private readonly SetWrapper _set;
  public SetWrapper Set { get => this._set; set => this._set.CopyProperties(value); }
  private readonly WeaponWrapper _weapon;
  public WeaponWrapper Weapon { get => this._weapon; set => this._weapon.CopyProperties(value); }

  protected ItemWrapper(GameObject prefab) : base(prefab)
  {
    this.ItemData = this.Prefab.GetComponent<ItemDrop>().m_itemData;
    this.SharedData = this.ItemData.m_shared;
    this.PieceTable = this.SharedData.m_buildPieces;
    this.Pieces = this.PieceTable?.m_pieces;

    this._armor = new(this.SharedData);
    this._food = new(this.SharedData);
    this._set = new(this.SharedData);
    this._weapon = new(this.SharedData);
  }

  public static ItemWrapper Get(GameObject prefab)
  {
    if (prefab is null) return null;
    var isCached = s_wrappersCache.TryGetValue(prefab.name, out var wrapper);
    if (!isCached) wrapper = s_wrappersCache[prefab.name] = new ItemWrapper(prefab);
    return (ItemWrapper)wrapper;
  }
}
