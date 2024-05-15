namespace LotusEcarlateChanges.Model.Wrappers.Nested;

public class Food(ItemDrop.ItemData.SharedData sharedData)
{
  private readonly ItemDrop.ItemData.SharedData _sharedData = sharedData;
  public float Health { get => this._sharedData.m_food; set => this._sharedData.m_food = value; }
  public float Stamina { get => this._sharedData.m_foodStamina; set => this._sharedData.m_foodStamina = value; }
  public float Eitr { get => this._sharedData.m_foodEitr; set => this._sharedData.m_foodEitr = value; }
  public float Duration { get => this._sharedData.m_foodBurnTime; set => this._sharedData.m_foodBurnTime = value; }
  public float Regen { get => this._sharedData.m_foodRegen; set => this._sharedData.m_foodRegen = value; }
}
