using System.Collections.Generic;
using LotusEcarlateChanges.Model.Wrappers;

namespace LotusEcarlateChanges.Model.ManualManagers;

public class ManualItemManager : ManualManagerBase<ItemWrapper>
{
  private static ManualItemManager s_instance;
  public static ManualItemManager Instance { get; } = s_instance ??= new ManualItemManager();
  private ManualItemManager() { }

  protected override ItemWrapper Get(string prefabName) => ItemWrapper.Get(ObjectDB.instance?.GetItemPrefab(prefabName));

  public void RegisterStatusEffects()
  {
    foreach (var item in Cache.Values)
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

  public override void RemoveAll(HashSet<string> toRemove)
  {
    foreach (var prefabName in toRemove)
    {
      if (ObjectDB.instance.GetItemPrefab(prefabName) is { } itemPrefab)
      {
        ObjectDB.instance.m_items.RemoveAll(prefab => prefab.name == prefabName);
        ObjectDB.instance.m_itemByHash.Remove(prefabName.GetStableHashCode());
        if (ObjectDB.instance.GetRecipe(itemPrefab.GetComponent<ItemDrop>()?.m_itemData) is { } recipe)
        {
          ObjectDB.instance.m_recipes.Remove(recipe);
        }
      }
    }
  }
}
