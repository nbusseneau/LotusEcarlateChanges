namespace LotusEcarlateChanges.Model.Wrappers;

public class Set(ItemDrop.ItemData.SharedData sharedData)
{
  private readonly ItemDrop.ItemData.SharedData _sharedData = sharedData;
  public SE_Stats Effect { get => (SE_Stats)this._sharedData.m_setStatusEffect; set => this._sharedData.m_setStatusEffect = value; }
  public string Name
  {
    get => this._sharedData.m_setName;
    set
    {
      this._sharedData.m_setName = value;
      if (this.Effect is not null) this.Effect.name = $"SetEffect_{value}";
    }
  }
  public int Size { get => this._sharedData.m_setSize; set => this._sharedData.m_setSize = value; }
}
