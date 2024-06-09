using System.Collections.Generic;

namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes;

public interface IArchetype
{
  public List<CharacterDrop.Drop> Drops { get; }
}
