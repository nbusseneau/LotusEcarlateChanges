namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes;

public class DropData(string prefabName, float chance = 100f, int min = 1, int max = 1)
{
  public string PrefabName { get; } = prefabName;
  public float Chance { get; } = chance;
  public int AmountMin { get; } = min;
  public int AmountMax { get; } = max > min ? max : min;

  public DropData(string prefabName, int amount) : this(prefabName, 100f, amount, amount) { }
  public DropData(string prefabName, int min, int max) : this(prefabName, 100f, min, max) { }
}
