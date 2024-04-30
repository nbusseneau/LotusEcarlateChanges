using System.Collections.Generic;

namespace LotusEcarlateChanges.Model.Wrappers;

public class Armor(ItemDrop.ItemData.SharedData sharedData)
{
  private readonly ItemDrop.ItemData.SharedData _sharedData = sharedData;

  // Defense
  public float ArmorBase { get => this._sharedData.m_armor; set => this._sharedData.m_armor = value; }
  public float ArmorPerLevel { get => this._sharedData.m_armorPerLevel; set => this._sharedData.m_armorPerLevel = value; }
  public List<HitData.DamageModPair> DamageModifiers { get => this._sharedData.m_damageModifiers; set => this._sharedData.m_damageModifiers = value; }

  // Common
  public float MovementModifier { get => this._sharedData.m_movementModifier; set => this._sharedData.m_movementModifier = value; }
  public float EitrRegenModifier { get => this._sharedData.m_eitrRegenModifier; set => this._sharedData.m_eitrRegenModifier = value; }
  public float Weight { get => this._sharedData.m_weight; set => this._sharedData.m_weight = value; }
  public SE_Stats EquipEffect { get => (SE_Stats)this._sharedData.m_equipStatusEffect; set => this._sharedData.m_equipStatusEffect = value; }
}
