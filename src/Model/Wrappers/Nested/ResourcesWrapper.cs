using System.Collections.Generic;
using System.Linq;

namespace LotusEcarlateChanges.Model.Wrappers.Nested;

public class ResourcesWrapper
{
  private readonly Piece _piece;
  private readonly Recipe _recipe;
  private readonly Dictionary<string, Piece.Requirement> _resources;

  public ResourcesWrapper(Piece piece)
  {
    _piece = piece;
    _resources = piece.m_resources.ToDictionary(r => r.m_resItem.name);
  }

  public ResourcesWrapper(Recipe recipe)
  {
    _recipe = recipe;
    _resources = recipe.m_resources.ToDictionary(r => r.m_resItem.name);
  }

  private void Save()
  {
    if (_piece is not null) _piece.m_resources = [.. _resources.Values];
    if (_recipe is not null) _recipe.m_resources = [.. _resources.Values];
  }

  private void Add(string itemName, int amount)
  {
    var isAlreadyPresent = _resources.TryGetValue(itemName, out var requirement);
    if (!isAlreadyPresent)
    {
      requirement = new() { m_resItem = ObjectDB.instance.GetItemPrefab(itemName).GetComponent<ItemDrop>() };
      this._resources[itemName] = requirement;
    }
    requirement.m_amount = amount;
  }

  public void Add(string itemName, int amount, bool recover = true)
  {
    this.Add(itemName, amount);
    _resources[itemName].m_recover = recover;
    this.Save();
  }

  public void Add(string itemName, int amount, int amountPerLevel)
  {
    this.Add(itemName, amount);
    _resources[itemName].m_amountPerLevel = amountPerLevel;
    this.Save();
  }

  public void Clear()
  {
    _resources.Clear();
    this.Save();
  }
}
