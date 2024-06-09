using System.Collections.Generic;
using LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes;
using UnityEngine;
using static Humanoid;

namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Tiers;

public interface ITier
{
  public GameObject[] Weapons { get; }
  public GameObject[] Shields { get; }
  public ItemSet[] Sets { get; }
  public List<IArchetype> Archetypes { get; }
  public IArchetype RandomArchetype { get; }
}
