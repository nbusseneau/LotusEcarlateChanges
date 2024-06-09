namespace LotusEcarlateChanges.Changes.Manual.RenegadeVikingsChanges.Archetypes.Mistlands;

public class SapRunner : MistlandsArchetypeBase
{
  private static readonly SapRunner s_instance;
  public static SapRunner Instance { get; } = s_instance ??= new SapRunner();
  private SapRunner()
  {
    this._drops.AddRange([
      // juicy roots
      new("Sap", 40, 80),
      new("DvergrNeedle"),
    ]);
  }
}
