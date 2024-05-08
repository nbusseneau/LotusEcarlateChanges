namespace LotusEcarlateChanges.Model;

public class CustomSkills
{
  public class Names
  {
    public const string TwoHandedAxes = "Two-handed axes";
    public const string TwoHandedHammers = "Two-handed hammers";
    public const string TwoHandedSwords = "Two-handed swords";
    public const string Warpikes = "Warpikes";
  }

  public static Skills.SkillType TwoHandedAxes = SkillManager.Skill.fromName(Names.TwoHandedAxes);
  public static Skills.SkillType TwoHandedHammers = SkillManager.Skill.fromName(Names.TwoHandedHammers);
  public static Skills.SkillType TwoHandedSwords = SkillManager.Skill.fromName(Names.TwoHandedSwords);
  public static Skills.SkillType Warpikes = SkillManager.Skill.fromName(Names.Warpikes);
}
