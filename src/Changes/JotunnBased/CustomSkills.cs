using Jotunn.Configs;
using Jotunn.Managers;
using LotusEcarlateChanges.Model.Changes;
using UnityEngine;

namespace LotusEcarlateChanges.Changes.JotunnBased;

public class CustomSkills : JotunnBasedChangesBase
{
  public static Skills.SkillType TwoHandedAxes { get; private set; }
  public static Skills.SkillType TwoHandedHammers { get; private set; }
  public static Skills.SkillType TwoHandedSwords { get; private set; }

  protected override void ApplyInternal()
  {
    TwoHandedAxes = Register("TwoHandedAxes", "$CustomSkills_TwoHandedAxesSkill_Name", "$CustomSkills_TwoHandedAxesSkill_Description");
    TwoHandedHammers = Register("TwoHandedHammers", "$CustomSkills_TwoHandedHammersSkill_Name", "$CustomSkills_TwoHandedHammersSkill_Description");
    TwoHandedSwords = Register("TwoHandedSwords", "$CustomSkills_TwoHandedSwordsSkill_Name", "$CustomSkills_TwoHandedSwordsSkill_Description");
  }

  private static Skills.SkillType Register(string identifier, string name, string description)
  {
    var skill = new SkillConfig
    {
      Identifier = identifier,
      Name = name,
      Description = description,
    };
    return SkillManager.Instance.AddSkill(skill);
  }

  public static void SetIcon(Skills.SkillType skill, Sprite icon) => SkillManager.Instance.CustomSkills[skill].Icon = icon;
}
