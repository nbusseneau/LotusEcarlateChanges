namespace LotusEcarlateChanges.Model.Wrappers.Nested;

public class Weapon(ItemDrop.ItemData.SharedData sharedData)
{
  private readonly ItemDrop.ItemData.SharedData _sharedData = sharedData;

  // Offense
  public HitData.DamageTypes Damages { get => this._sharedData.m_damages; set => this._sharedData.m_damages = value; }
  public HitData.DamageTypes DamagesPerLevel { get => this._sharedData.m_damagesPerLevel; set => this._sharedData.m_damagesPerLevel = value; }
  public float Knockback { get => this._sharedData.m_attackForce; set => this._sharedData.m_attackForce = value; }
  public float BackstabBonus { get => this._sharedData.m_backstabBonus; set => this._sharedData.m_backstabBonus = value; }
  public Attack PrimaryAttack { get => this._sharedData.m_attack; set => this._sharedData.m_attack = value; }
  public Attack SecondaryAttack { get => this._sharedData.m_secondaryAttack; set => this._sharedData.m_secondaryAttack = value; }
  public SE_Stats AttackEffect { get => (SE_Stats)this._sharedData.m_attackStatusEffect; set => this._sharedData.m_attackStatusEffect = value; }

  // Defense
  public float BlockArmor { get => this._sharedData.m_blockPower; set => this._sharedData.m_blockPower = value; }
  public float BlockArmorPerLevel { get => this._sharedData.m_blockPowerPerLevel; set => this._sharedData.m_blockPowerPerLevel = value; }
  public float BlockForce { get => this._sharedData.m_deflectionForce; set => this._sharedData.m_deflectionForce = value; }
  public float BlockForcePerLevel { get => this._sharedData.m_deflectionForcePerLevel; set => this._sharedData.m_deflectionForcePerLevel = value; }
  public float ParryBonus { get => this._sharedData.m_timedBlockBonus; set => this._sharedData.m_timedBlockBonus = value; }

  // Common
  public float MovementModifier { get => this._sharedData.m_movementModifier; set => this._sharedData.m_movementModifier = value; }
  public float Weight { get => this._sharedData.m_weight; set => this._sharedData.m_weight = value; }
  public Skills.SkillType SkillType { get => this._sharedData.m_skillType; set => this._sharedData.m_skillType = value; }
  public SE_Stats EquipEffect { get => (SE_Stats)this._sharedData.m_equipStatusEffect; set => this._sharedData.m_equipStatusEffect = value; }
}
