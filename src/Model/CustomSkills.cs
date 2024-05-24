using Jotunn.Configs;
using Jotunn.Managers;
using UnityEngine;

namespace LotusEcarlateChanges.Model;

public class CustomSkills
{
  public class Identifiers
  {
    public const string TwoHandedAxes = "TwoHandedAxes";
    public const string TwoHandedHammers = "TwoHandedHammers";
    public const string TwoHandedSwords = "TwoHandedSwords";
    public const string Warpikes = "Warpikes";
  }

  public static Skills.SkillType TwoHandedAxes;
  public static Skills.SkillType TwoHandedHammers;
  public static Skills.SkillType TwoHandedSwords;
  public static Skills.SkillType Warpikes;

  public static Skills.SkillType RegisterSkill(string identifier, string name, string description, Sprite icon)
  {
    var skill = new SkillConfig
    {
      Identifier = identifier,
      Name = name,
      Description = description,
      Icon = icon
    };
    return SkillManager.Instance.AddSkill(skill);
  }
}
