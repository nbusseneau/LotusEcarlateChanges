using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using LotusEcarlateChanges.Model.Reflection.Objects;

namespace LotusEcarlateChanges.Model.Reflection.Managers;

public class SkillManager : ReflectionManagerBase<Skill>
{
  private readonly IDictionary _skills;
  private readonly IDictionary _skillByName;

  protected override object GetObjectFromStorage(string name) => this._skillByName[name];
  protected override ICollection GetAllObjectsFromStorage() => this._skills.Values;

  public SkillManager(Assembly assembly, string assemblyNamespace = "SkillManager") : base(assembly, assemblyNamespace)
  {
    var skillType = assembly.GetType($"{assemblyNamespace}.Skill");
    var skillsField = AccessTools.DeclaredField(skillType, "skills");
    this._skills = (IDictionary)skillsField.GetValue(null);

    var skillByNameField = AccessTools.DeclaredField(skillType, "skillByName");
    this._skillByName = (IDictionary)skillByNameField.GetValue(null);
  }

  public override void UnregisterToRemove(HashSet<string> toRemove)
  {
    List<object> skillsToRemove = [];
    foreach (string skillName in this._skillByName.Keys)
    {
      if (toRemove.Contains(skillName)) skillsToRemove.Add(this._skillByName[skillName]);
    }
    this.DoRemove(skillsToRemove);
  }

  public override void UnregisterAllExceptToKeep(HashSet<string> toKeep)
  {
    List<object> skillsToRemove = [];
    foreach (string skillName in this._skillByName.Keys)
    {
      if (!toKeep.Contains(skillName)) skillsToRemove.Add(this._skillByName[skillName]);
    }
    this.DoRemove(skillsToRemove);
  }

  private void DoRemove(List<object> skillsToRemove)
  {
    List<object> skillTypesToRemove = [];
    foreach (var skillType in this._skills.Keys)
    {
      if (skillsToRemove.Contains(this._skills[skillType])) skillTypesToRemove.Add(skillType);
    }
    skillTypesToRemove.ForEach(this._skills.Remove);
  }
}
