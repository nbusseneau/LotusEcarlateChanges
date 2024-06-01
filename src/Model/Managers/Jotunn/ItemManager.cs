using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Jotunn.Utils;
using LotusEcarlateChanges.Model.Wrappers;

namespace LotusEcarlateChanges.Model.Managers.Jotunn;

public class ItemManager(string modGuid) : JotunnManagerBase, IIndexableManager<ItemWrapper>
{
  private static readonly global::Jotunn.Managers.ItemManager s_manager = global::Jotunn.Managers.ItemManager.Instance;
  private readonly IEnumerable<ItemWrapper> _items = ModRegistry.GetItems(modGuid).Select(item => ItemWrapper.Get(item.ItemPrefab));

  protected override void ApplyToRemove()
  {
    var toRemove = s_manager.Items.Keys.Where(this._toRemove.Contains).ToList();
    foreach (var item in toRemove) s_manager.RemoveItem(item);
  }

  protected override void ApplyToKeep()
  {
    var toRemove = s_manager.Items.Keys.Where(itemName => !this._toRemove.Contains(itemName)).ToList();
    foreach (var item in toRemove) s_manager.RemoveItem(item);
  }

  public ItemWrapper this[string name]
  {
    get
    {
      var customItem = s_manager.GetItem(name);
      if (customItem is null) Plugin.Logger.LogError($"{this.GetType()} did not find any object registered with name {name}");
      return ItemWrapper.Get(customItem?.ItemPrefab);
    }
  }
  public IEnumerable<ItemWrapper> this[params string[] names] => names.Select(name => this[name]).Where(w => w is not null);
  public IEnumerator<ItemWrapper> GetEnumerator() => _items.GetEnumerator();
  IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}
