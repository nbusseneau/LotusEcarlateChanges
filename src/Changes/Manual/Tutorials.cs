using System.Collections.Generic;
using LotusEcarlateChanges.Model.Changes;
using LotusEcarlateChanges.Extensions;
using UnityEngine;

namespace LotusEcarlateChanges.Changes.Manual;

public class Tutorials : ManualChangesBase
{
  private static GameObject s_raven;
  private static Vector3 s_ravenOffset = new(2f, 0.1f, 2f);
  private static readonly Dictionary<string, TutorialData> s_tutorials = new()
  {
    ["blastfurnace"] = new()
    {
      Key = "BlastFurnace",
      Label = "$Tutorial_BlastFurnace_Label",
      Topic = "$Tutorial_BlastFurnace_Topic",
      Text = "$Tutorial_BlastFurnace_Text",
    },
    ["fire_pit"] = new()
    {
      Key = "Campfire",
      Label = "$Tutorial_Campfire_Label",
      Topic = "$Tutorial_Campfire_Topic",
      Text = "$Tutorial_Campfire_Text",
    },
    ["Cart"] = new()
    {
      Key = "Cart",
      Label = "$Tutorial_Cart_Label",
      Topic = "$Tutorial_Cart_Topic",
      Text = "$Tutorial_Cart_Text",
    },
    ["piece_chest_wood"] = new()
    {
      Key = "Chest",
      Label = "$Tutorial_Chest_Label",
      Topic = "$Tutorial_Chest_Topic",
      Text = "$Tutorial_Chest_Text",
    },
  };

  protected override void ApplyInternalDeferred()
  {
    s_raven = ZNetScene.instance.GetPrefab("piece_cartographytable").GetComponentInChildren<GuidePoint>().m_ravenPrefab;
    foreach (var (prefabName, tutorial) in s_tutorials) RegisterTutorial(prefabName, tutorial);
  }

  private static void RegisterTutorial(string prefabName, TutorialData tutorial)
  {
    if (ZNetScene.instance.GetPrefab(prefabName) is not { } targetPrefab)
    {
      Plugin.Logger.LogError($"Did not find any object named {prefabName}.");
      return;
    }

    if (targetPrefab.GetComponentInChildren<GuidePoint>() is not null)
    {
      Plugin.Logger.LogError($"Object {prefabName} already has a {typeof(GuidePoint)} component.");
      return;
    }

    var tutorialKey = $"{Plugin.ModGUID}.Tutorial.{tutorial.Key}";
    GameObject tutorialPrefab = new(tutorialKey);
    tutorialPrefab.transform.SetParent(targetPrefab.transform);
    tutorialPrefab.transform.position = targetPrefab.transform.position + s_ravenOffset;

    var guidePoint = tutorialPrefab.AddComponent<GuidePoint>();
    guidePoint.m_ravenPrefab = s_raven;
    guidePoint.m_text.m_key = tutorialKey;
    guidePoint.m_text.m_label = tutorial.Label;
    guidePoint.m_text.m_topic = tutorial.Topic;
    guidePoint.m_text.m_text = tutorial.Text;
    guidePoint.m_text.m_alwaysSpawn = false;
    guidePoint.m_text.m_munin = false;
    guidePoint.m_text.m_priority = 0;
  }

  private class TutorialData
  {
    public string Key { get; set; }
    public string Topic { get; set; }
    public string Label { get; set; }
    public string Text { get; set; }
  }
}
