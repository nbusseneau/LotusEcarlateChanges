using System.Collections.Generic;
using System.Linq;

namespace LotusEcarlateChanges.Model.Wrappers;

public class Resources
{
  private readonly Piece _piece;
  private readonly Recipe _recipe;
  private readonly Dictionary<string, Piece.Requirement> _resources;

  public Resources(Piece piece)
  {
    _piece = piece;
    _resources = piece.m_resources.ToDictionary(r => r.m_resItem.name);
  }

  public Resources(Recipe recipe)
  {
    _recipe = recipe;
    _resources = recipe.m_resources.ToDictionary(r => r.m_resItem.name);
  }

  public void Add(string itemName, int amount, bool recover = true)
  {
    if (!_resources.ContainsKey(itemName))
    {
      this._resources[itemName] = new()
      {
        m_resItem = ObjectDB.instance.GetItemPrefab(itemName).GetComponent<ItemDrop>()
      };
    }
    _resources[itemName].m_amount = amount;
    _resources[itemName].m_recover = recover;
  }

  public void Add(string itemName, int amount, int amountPerLevel)
  {
    if (!_resources.ContainsKey(itemName))
    {
      this._resources[itemName] = new()
      {
        m_resItem = ObjectDB.instance.GetItemPrefab(itemName).GetComponent<ItemDrop>()
      };
    }
    _resources[itemName].m_amount = amount;
    _resources[itemName].m_amountPerLevel = amountPerLevel;
  }

  public void Clear() => _resources.Clear();

  public void Save()
  {
    if (_piece is not null) _piece.m_resources = [.. _resources.Values];
    if (_recipe is not null) _recipe.m_resources = [.. _resources.Values];
  }
}
