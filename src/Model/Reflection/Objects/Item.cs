using HarmonyLib;
using UnityEngine;
using LotusEcarlateChanges.Extensions;
using LotusEcarlateChanges.Model.Wrappers;
using LotusEcarlateChanges.Model.Reflection.Objects.Nested;

namespace LotusEcarlateChanges.Model.Reflection.Objects;

public class Item : ReflectionObjectBase
{
  public GameObject Prefab { get; }
  public override string UniqueName => this.Prefab.name;
  public ItemDrop.ItemData ItemData { get; }
  public ItemDrop.ItemData.SharedData SharedData { get; }

  public LocalizeKey Name { get; }
  public LocalizeKey Description { get; }

  public RequiredResourceList RequiredItems { get; }
  public RequiredResourceList RequiredUpgradeItems { get; }
  public CraftingStationList Crafting { get; }
  public DropTargets DropsFrom { get; }

  private readonly Armor _armor;
  public Armor Armor { get => this._armor; set => this._armor.CopyProperties(value); }
  private readonly Food _food;
  public Food Food { get => this._food; set => this._food.CopyProperties(value); }
  private readonly Set _set;
  public Set Set { get => this._set; set => this._set.CopyProperties(value); }
  private readonly Weapon _weapon;
  public Weapon Weapon { get => this._weapon; set => this._weapon.CopyProperties(value); }

  public Item(object item) : base(item)
  {
    this.Prefab = (GameObject)AccessTools.Field(item.GetType(), "Prefab").GetValue(item);
    this.ItemData = this.Prefab.GetComponent<ItemDrop>().m_itemData;
    this.SharedData = this.ItemData.m_shared;

    this.Name = new(AccessTools.Property(item.GetType(), "Name").GetValue(item));
    this.Description = new(AccessTools.Property(item.GetType(), "Description").GetValue(item));

    this.RequiredItems = new(AccessTools.Property(item.GetType(), "RequiredItems").GetValue(item));
    this.RequiredUpgradeItems = new(AccessTools.Property(item.GetType(), "RequiredUpgradeItems").GetValue(item));
    this.Crafting = new(AccessTools.Property(item.GetType(), "Crafting").GetValue(item));
    this.DropsFrom = new(AccessTools.Field(item.GetType(), "DropsFrom").GetValue(item));

    this._armor = new(this.SharedData);
    this._food = new(this.SharedData);
    this._set = new(this.SharedData);
    this._weapon = new(this.SharedData);
  }
}
