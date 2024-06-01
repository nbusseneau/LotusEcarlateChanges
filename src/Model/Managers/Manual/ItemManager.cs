using LotusEcarlateChanges.Model.Wrappers;

namespace LotusEcarlateChanges.Model.Managers.Manual;

public class ItemManager : ManualManagerBase<ItemWrapper>
{
  private static readonly ItemManager s_instance;
  public static ItemManager Instance { get; } = s_instance ??= new ItemManager();
  private ItemManager() { }

  protected override ItemWrapper Get(string name) => ItemWrapper.Get(ObjectDB.instance?.GetItemPrefab(name));

  public override void Apply()
  {
    foreach (var name in this._toRemove)
    {
      if (ObjectDB.instance.GetItemPrefab(name) is { } itemPrefab)
      {
        ObjectDB.instance.m_items.RemoveAll(prefab => prefab.name == name);
        ObjectDB.instance.m_itemByHash.Remove(name.GetStableHashCode());
        if (ObjectDB.instance.GetRecipe(itemPrefab.GetComponent<ItemDrop>()?.m_itemData) is { } recipe)
        {
          ObjectDB.instance.m_recipes.Remove(recipe);
        }
      }
    }
    this.RegisterStatusEffects();
  }

  private void RegisterStatusEffects()
  {
    foreach (var item in _wrappersCache.Values)
    {
      RegisterStatusEffect(item.SharedData.m_attackStatusEffect);
      RegisterStatusEffect(item.SharedData.m_consumeStatusEffect);
      RegisterStatusEffect(item.SharedData.m_equipStatusEffect);
      RegisterStatusEffect(item.SharedData.m_setStatusEffect);
    }
  }

  private void RegisterStatusEffect(StatusEffect statusEffect)
  {
    if (statusEffect is not null && !ObjectDB.instance.GetStatusEffect(statusEffect.name.GetStableHashCode()))
    {
      ObjectDB.instance.m_StatusEffects.Add(statusEffect);
    }
  }
}
