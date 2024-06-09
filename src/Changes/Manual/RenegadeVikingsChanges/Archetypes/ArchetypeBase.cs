using System.Collections.Generic;
using System.Linq;

namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes;

public abstract class ArchetypeBase : IArchetype
{
  private static CharacterDrop.Drop BuildDrop(DropData dropData) => new()
  {
    m_prefab = ZNetScene.instance.GetPrefab(dropData.PrefabName),
    m_amountMin = dropData.AmountMin,
    m_amountMax = dropData.AmountMax,
    m_chance = dropData.Chance / 100f,
    m_onePerPlayer = false,
    m_levelMultiplier = false, // we force not to scale because we normalize levels via the config file
    m_dontScale = false,
  };

  private List<CharacterDrop.Drop> _dropsCache;
  protected readonly List<DropData> _drops = [];
  public virtual List<CharacterDrop.Drop> Drops => this._dropsCache ??= _drops.Select(BuildDrop).ToList();
}
