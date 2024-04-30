using System.Collections.Generic;

namespace LotusEcarlateChanges.Model.Manual;

public class ExistingItemManager
{
  protected readonly Dictionary<string, ExistingItem> _modified = [];
  public ExistingItem this[string prefabName]
  {
    get
    {
      if (!_modified.ContainsKey(prefabName))
      {
        var prefab = ObjectDB.instance.GetItemPrefab(prefabName);
        _modified[prefabName] = new(prefab);
      }
      return _modified[prefabName];
    }
  }

  public void PatchModifiedItems()
  {
    foreach (var item in _modified.Values)
    {
      item.Resources?.Save();
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
